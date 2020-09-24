using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private float maxSanity = 100;
    [SerializeField]
    private float sanity = 100;

    [SerializeField]
    private int day = 1;
    [SerializeField]
    private int maxDays = 5;
    [SerializeField]
    private int levelTime = 120;
    [SerializeField]
    private bool freezeGame;
    [SerializeField]
    private bool dayStarted;

    public float TimeUntilNewRequest = 15f;

    public float[] RequestTimes = null;
    public int[] LevelTimes = null;
 
    private UIManager uiManager;

    public float Sanity { get { return sanity; }  set { sanity = Mathf.Clamp(value, 0, maxSanity); } }
    public int Day { get { return day; } set { day = value; } }
    public int LevelTime { get { return levelTime; } set { levelTime = value; } }
    public bool FreezeGame { get { return freezeGame; } set { freezeGame = value; } }
    public bool DayStarted { get { return dayStarted; } set { dayStarted = value; } }

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

        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        sanity = maxSanity;
        //StartDay();
    }

    private void Update()
    {
        if (sanity <= 0)
        {
            sanity = maxSanity;
            SoundManager.Instance.PlayLose();
            // Lose
            uiManager.ActivateBadEnd();
        }
    }

    public void ResetGame()
    {
        Day = 1;
        sanity = maxSanity;
        freezeGame = false;
        dayStarted = false;
        SceneManager.LoadScene(0);
    }

    public void StartDay()
    {
        if (day <= maxDays)
        {
            SoundManager.Instance.PlayAlarm();
            TimeUntilNewRequest = RequestTimes[day - 1];
            LevelTime = LevelTimes[day - 1];
            sanity = maxSanity;
            UIEvents.ToggleDialogueUI(true);
            DialogueSystem.Instance.StartDialogue(day, true);
            FreezeGame = true;
        }
        else
        {
            Debug.Log("win");
            SoundManager.Instance.PlayWin();
            uiManager.ActivateGoodEnd();
        }
    }

    private void NextDay()
    {
        UIEvents.FadeToWhite();

        // Update Variables before next day
        //
        //
        Day++;

        Invoke("StartDay", 3f);
    }

    #region CalledFromOutside
    // Called at the end of a day when the timer ends
    public void TimerEnded()
    {
        FreezeGame = true;
        DayStarted = false;

        DialogueSystem.Instance.StartDialogue(day, false);
    }

    // Called from Dialogue System after beginning day dialogue
    public void DialogueEnded()
    {
        UIEvents.StartTimer();
        UIEvents.ToggleDialogueUI(false);
        FreezeGame = false;
        DayStarted = true;
    }

    // Called from Dialogue System after end of day dialogue
    public void EndDay()
    {
        UIEvents.FadeToBlack();
        UIEvents.ToggleDialogueUI(false);

        Invoke("NextDay", 3f);
    }
    #endregion
}
