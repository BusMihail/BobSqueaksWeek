using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMinigame 
{
    MinigameType minigame { get; set; }

    Action<IMinigame, bool> OnMinigameFinished { get; set; }

    void DestroyMinigame();
}
