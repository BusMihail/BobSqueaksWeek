using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField]
    [Range(0,0.1f)]
    private float letterPause;

    [SerializeField]
    private TextMeshProUGUI dialogueText;
    [SerializeField]
    private Image character;

    public static bool skipped = false;
    
    private string textToDisplay;

    private GameObject holder;


    void Awake()
    {
        UIEvents.OnDisplayDialogue += DisplayText;
        UIEvents.OnToggleDialogueUI += ToggleUI;
        holder = transform.GetChild(0).gameObject;
    }

    private void OnDestroy()
    {
        UIEvents.OnDisplayDialogue -= DisplayText;
        UIEvents.OnToggleDialogueUI -= ToggleUI;
    }

    public void DisplayText(string text)
    {
        textToDisplay = text;
        skipped = false;
        StartCoroutine(TextCoroutine(letterPause));
    }

    private IEnumerator TextCoroutine(float textSpeed)
    {
        string text = "";

        foreach (char letter in textToDisplay)
        {
            text += letter;
            dialogueText.text = text;
            yield return new WaitForSeconds(textSpeed);
        }

    }

    private void ToggleUI(bool value)
    {
        holder.SetActive(value);
    }
}
