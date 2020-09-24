using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowMinigame : MonoBehaviour, IMinigame
{

    public MinigameType minigame { get; set; }
    public Action<IMinigame, bool> OnMinigameFinished { get; set; }

    private void Awake()
    {
    }

    public void WinMinigame()
    {
        Debug.Log("won");
        OnMinigameFinished(this, true);
    }

    public void DestroyMinigame()
    {
        Destroy(gameObject);
    }
}
