using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Minigame
{
    public MinigameType MinigameType;

    public bool canBeRequested;

    public float timeToStart;
    public float timeToComplete;

    public float sanityLoss;
    public float sanityGain;

    public GameObject minigamePrefab;

}
