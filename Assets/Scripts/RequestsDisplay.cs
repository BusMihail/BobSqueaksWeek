using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RequestsDisplay : MonoBehaviour
{
    // Minigame sprites in order of minigame types
    [SerializeField]
    private Sprite[] sprites;

    private List<RequestUI> requests;


    private void Awake()
    {
        requests = GetComponentsInChildren<RequestUI>().ToList();

        UIEvents.OnDisplayRequest += DisplayRequest;
        UIEvents.OnEndRequest += EndRequest;
        UIEvents.OnStartFlickering += ActivateRequestFlicker;
    }

    private void OnDestroy()
    {
        UIEvents.OnDisplayRequest -= DisplayRequest;
        UIEvents.OnEndRequest -= EndRequest;
        UIEvents.OnStartFlickering -= ActivateRequestFlicker;
    }

    private void DisplayRequest(MinigameType minigame)
    {
        RequestUI request = requests.Find(t => t.isUsed == false);
        if (request != null)
        {
            request.minigameType = minigame;
            request.isUsed = true;
            request.DisplayRequest(sprites[(int)minigame]);
        }
        else
        {
            Debug.Log("no requestUI available");
        }
    }

    private void ActivateRequestFlicker(MinigameType minigame)
    {
        RequestUI request = requests.Find(t => t.minigameType == minigame);
        if (request != null)
        {
            request.ActivateFlickering();
        }
        else
        {
            Debug.Log("request not nound");
        }
    }

    private void EndRequest(MinigameType minigame)
    {
        RequestUI request = requests.Find(t => t.minigameType == minigame);
        if (request != null)
        {
            request.isUsed = false;
            request.EndRequest();
        }
        else
        {
            Debug.Log("request not found");
        }
    }

}
