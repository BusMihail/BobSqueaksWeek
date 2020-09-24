using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameTimer : MonoBehaviour
{
    IMinigame minigame;

    private void Awake()
    {
        minigame = GetComponent<IMinigame>();

        Debug.Log(minigame);
    }

    private void Start()
    {
        StartCoroutine(Timer(MinigameManager.Instance.GetMinigameOfType(minigame.minigame).timeToComplete));
    }

    private void Update()
    {
        if (GameManager.Instance.DayStarted == false)
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    private IEnumerator Timer(float time)
    {
        while (time > 0)
        {

            time -= Time.deltaTime;
            yield return null;
        }

        Debug.Log("Minigame Failed");
        // minigame failed
        minigame.OnMinigameFinished(minigame, false);
    }
}
