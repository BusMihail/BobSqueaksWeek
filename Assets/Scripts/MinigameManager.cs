using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MinigameType { Laptop, Stove, Toilet, Window }

public class MinigameManager : MonoBehaviour
{
    public List<Minigame> minigames = new List<Minigame>(); 

    public static MinigameManager Instance { get; set; }

    private Interactable currentInteractable = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadMinigame(MinigameType game, Interactable interactable)
    {
        GameObject prefab = GetMinigameOfType(game).minigamePrefab;
        GameObject instance = Instantiate(prefab);
        IMinigame iminigame = instance.GetComponent<IMinigame>();
        iminigame.minigame = game;
        iminigame.OnMinigameFinished += MinigameFinished;
        print("subscribed");

        GameManager.Instance.FreezeGame = true;
        currentInteractable = interactable;
    }

    private void MinigameFinished(IMinigame minigame, bool win)
    {
        print("Destroyed");
        minigame.DestroyMinigame();

        Minigame minigameValues = GetMinigameOfType(minigame.minigame);
        float sanityAmount;
        if (win)
        {
            sanityAmount = minigameValues.sanityGain;
        }
        else
        {
            sanityAmount = minigameValues.sanityLoss;
        }
        currentInteractable.InMinigame = false;

        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        GameManager.Instance.FreezeGame = false;
        GameManager.Instance.Sanity += sanityAmount;
        UIEvents.EndRequest(minigame.minigame);
        UIEvents.SanityUpdate(GameManager.Instance.Sanity);
    }

    public Minigame GetMinigameOfType(MinigameType type)
    {
        return minigames.Find(t => t.MinigameType == type);
    }

    public void UnlockMinigame(MinigameType game)
    {
        minigames.Find(t => t.MinigameType == game).canBeRequested = true;
    }

    public void LockMinigame(MinigameType game)
    {
        minigames.Find(t => t.MinigameType == game).canBeRequested = false;
    }

    public int GetUnlockedMinigames()
    {
        int i = 0;

        foreach (var minigame in minigames)
        {
            if (minigame.canBeRequested)
                i++;
        }

        return i;
    }

}
