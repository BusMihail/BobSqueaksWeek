using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvents : MonoBehaviour
{
    public static event Action<MinigameType> OnDisplayRequest;

    public static event Action<MinigameType> OnEndRequest;

    public static event Action<MinigameType> OnStartFlickering;

    public static event Action<float> OnSanityUpdate;

    public static event Action<string> OnDisplayDialogue;

    public static event Action<bool> OnToggleDialogueUI;

    public static event Action OnStartTimer;

    public static event Action OnFadeToBlack;

    public static event Action OnFadeToWhite;

    public static void DisplayRequest(MinigameType type)
    {
        OnDisplayRequest?.Invoke(type);
    }

    public static void EndRequest(MinigameType type)
    {
        OnEndRequest?.Invoke(type);
    }

    public static void SanityUpdate(float value)
    {
        OnSanityUpdate?.Invoke(value);
    }

    public static void StartFlickering(MinigameType type)
    {
        OnStartFlickering?.Invoke(type);
    }    

    public static void DisplayDialogue(string dialogue)
    {
        OnDisplayDialogue?.Invoke(dialogue);
    }

    public static void ToggleDialogueUI(bool value)
    {
        OnToggleDialogueUI?.Invoke(value);
    }

    public static void StartTimer()
    {
        OnStartTimer?.Invoke();
    }

    public static void FadeToBlack()
    {
        OnFadeToBlack?.Invoke();
    }

    public static void FadeToWhite()
    {
        OnFadeToWhite?.Invoke();
    }
}
