using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance;

    [SerializeField]
    private Day[] days; // days and list of messages

    private Queue<Message> messagesQueue = new Queue<Message>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }    
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartDialogue(int day, bool beginning)
    {
        Message[] mesasges = beginning ? days[day - 1].dayBeginning : days[day - 1].dayEnding;

        foreach(Message m in mesasges)
        {
            messagesQueue.Enqueue(m);
        }

        UIEvents.ToggleDialogueUI(true);
        StartCoroutine(NextMessage(beginning));
    }

    // If there is a message in the queue
    private IEnumerator NextMessage(bool beginning)
    {
        if (messagesQueue.Count != 0)
        {
            Message m = messagesQueue.Dequeue();
            UIEvents.DisplayDialogue(m.message);

            yield return new WaitForSeconds(m.displayTimeSeconds);

            StartCoroutine(NextMessage(beginning));
        }
        else
        {
            // End of Day
            if (beginning)
            {
                GameManager.Instance.DialogueEnded();
            }
            else
            {
                GameManager.Instance.EndDay();
            }
        }
    }

    [System.Serializable]
    public struct Day
    {
        public Message[] dayBeginning;
        public Message[] dayEnding;
    }

    [System.Serializable]
    public struct Message
    {
        public string characterName;
        public string message;
        public float displayTimeSeconds;
        public Sprite characterSprite;

    }
}
