using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityUI : MonoBehaviour
{
    [SerializeField]
    private Image fillBar = null;
    [SerializeField]
    private Image icon = null;

    [SerializeField]
    private Sprite[] sprites = new Sprite[4];

    [SerializeField]
    private Color StartColor = Color.green;
    [SerializeField]
    private Color EndColor = Color.red;

    private void Awake()
    {
        UIEvents.OnSanityUpdate += UpdateSanityDisplay;
    }

    private void OnDestroy()
    {
        UIEvents.OnSanityUpdate -= UpdateSanityDisplay;
    }

    private void UpdateSanityDisplay(float value)
    {
        float fillValue = value / 100;

        fillBar.fillAmount = fillValue;
        fillBar.color = Color.Lerp(EndColor, StartColor, fillValue);

        if (fillValue >= 0.75f)
        {
            icon.sprite = sprites[0];
        }
        else if (fillValue >= 0.5f)
        {
            icon.sprite = sprites[1];
        }
        else if (fillValue >= 0.25f)
        {
            icon.sprite = sprites[2];
        }
        else
        {
            icon.sprite = sprites[3];
        }
    }
}
