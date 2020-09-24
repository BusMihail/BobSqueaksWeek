using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutUI : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private float fadeDuration = 3f;

    private void Awake()
    {
        image = GetComponent<Image>();

        UIEvents.OnFadeToBlack += FadeToBlack;
        UIEvents.OnFadeToWhite += FadeToWhite;
    }

    private void OnDestroy()
    {
        UIEvents.OnFadeToBlack -= FadeToBlack;
        UIEvents.OnFadeToWhite -= FadeToWhite;
    }

    private void FadeToWhite()
    {
        StartCoroutine(FadeToWhiteC(fadeDuration));
    }

    private void FadeToBlack()
    {
        StartCoroutine(FadeToBlackC(fadeDuration));
    }

    private IEnumerator FadeToBlackC(float duration)
    {
        float curDuration = duration;
        while (curDuration > 0)
        {
            float value = Map(curDuration, 0, duration, 1, 0);

            
            image.color = new Color(0,0,0, value);
            yield return null;
            curDuration -= Time.deltaTime;
        }

    }

    private IEnumerator FadeToWhiteC(float duration)
    {
        float curDuration = duration;
        while (curDuration > 0)
        {
            float value = Map(curDuration, 0, duration, 0, 1);

            image.color = new Color(0, 0, 0, value);
            yield return null;
            curDuration -= Time.deltaTime;
        }
    }

    private float Map(float x, float in_min, float in_max, float out_min, float out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }
}
