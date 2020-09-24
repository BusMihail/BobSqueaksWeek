using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequestUI : MonoBehaviour
{
    public MinigameType minigameType { get; set; }
    public bool isUsed { get; set; }

    [SerializeField]
    private Image minigameImage;
    [SerializeField]
    private Image backgroundImage;

    private void Awake()
    {
        minigameImage = transform.GetChild(0).GetComponent<Image>();
        minigameImage.enabled = false;
        backgroundImage = GetComponent<Image>();
        backgroundImage.enabled = false;
    }

    public void DisplayRequest(Sprite sprite)
    {
        minigameImage.sprite = sprite;
        minigameImage.enabled = true;
        backgroundImage.enabled = true;
    }

    public void EndRequest()
    {
        minigameImage.enabled = false;
        backgroundImage.enabled = false;
    }

    public void ActivateFlickering()
    {
        StartCoroutine(Flicker(5));
    }

    private IEnumerator Flicker(float time)
    {
        while (time > 0)
        {
            minigameImage.enabled = !minigameImage.enabled;
            backgroundImage.enabled = !backgroundImage.enabled;
            yield return new WaitForSecondsRealtime(0.5f);

            time -= 0.5f;
        }
    }
}
