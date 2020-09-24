using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MinigameRequester : MonoBehaviour
{

    public List<Interactable> interactables = new List<Interactable>();

    private bool dayReset;

    private void Awake()
    {
        interactables = GetComponentsInChildren<Interactable>().ToList();
    }

    private void Start()
    {
        StartCoroutine(RequestMinigameCoroutine());
    }

    private void Update()
    {
        if (GameManager.Instance.DayStarted == false && !dayReset)
        {
            dayReset = true;
            foreach (Interactable i in interactables)
            {
                i.SetInteractable(false);
            }
        }
    }

    public void RequestMinigame()
    {
        Minigame minigame = RollMinigame();

        var interactables = GetAllAvailableInteractablesForMinigame(minigame.MinigameType);

        // second roll
        if (interactables.Count == 0)
        {
            minigame = RollMinigame();
            interactables = GetAllAvailableInteractablesForMinigame(minigame.MinigameType);

            if (interactables.Count == 0)
                return;
        }

        int randomInteractible = Random.Range(0, interactables.Count);
        Interactable interactable = interactables[randomInteractible];
        interactable.SetInteractable(true);

        print("Dispalying minigame" + minigame.MinigameType);
        UIEvents.DisplayRequest(minigame.MinigameType);
        StartCoroutine(TimeToStartMinigame(interactable, minigame.timeToStart, randomInteractible));
    }

    private IEnumerator RequestMinigameCoroutine()
    {
        while (true)
        {
            if (GameManager.Instance.DayStarted)
            {
                dayReset = false;
                print("Requesting Minigame");
                RequestMinigame();

            }
            yield return new WaitForSeconds(GameManager.Instance.TimeUntilNewRequest);
        }
    }

    private IEnumerator TimeToStartMinigame(Interactable interactable, float time, int index)
    {
        bool startedCountdown = false;
        while (time > 0)
        {
            // Stop countdown if player has started the minigame
            if (interactable.MinigameStarted)
            {
                interactable.MinigameStarted = false;
                yield break;
            }

            if (time <= 5.5 && !startedCountdown)
            {
                startedCountdown = true;
                UIEvents.StartFlickering(interactable.minigame);
            }

            time -= Time.deltaTime;
            yield return null;
        }

        print("request expired " + interactable.minigame);
        float sanityAmount = MinigameManager.Instance.GetMinigameOfType(interactable.minigame).sanityLoss;
        GameManager.Instance.Sanity += sanityAmount;
        UIEvents.SanityUpdate(GameManager.Instance.Sanity);
        UIEvents.EndRequest(interactable.minigame);
        interactable.SetInteractable(false);

    }

    private List<Interactable> GetAllAvailableInteractablesForMinigame(MinigameType minigameType)
    {
        return interactables.FindAll(t => t.minigame == minigameType && t.IsInteractable == false && t.InMinigame == false);
    }

    private Minigame RollMinigame()
    {
        int minigames = MinigameManager.Instance.GetUnlockedMinigames();
        int randomMinigame = Random.Range(0, minigames);
        return MinigameManager.Instance.minigames[randomMinigame];
    }
}
