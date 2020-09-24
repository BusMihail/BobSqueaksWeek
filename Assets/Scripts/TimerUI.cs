using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI dayText = null;
    [SerializeField]
    private TextMeshProUGUI timeText = null;

    [SerializeField]
    RectTransform timerTransform = null;

    private void Awake()
    {
        UIEvents.OnStartTimer += StartTimer;
    }

    private void OnDestroy()
    {
        UIEvents.OnStartTimer -= StartTimer;
    }

    public void StartTimer()
    {
        StartCoroutine(Timer(GameManager.Instance.LevelTime));
    }

    IEnumerator Timer(int time)
    {
        dayText.text = "Day " + GameManager.Instance.Day;
        while (time > 0)
        {
            int minutes = time / 60;
            int seconds = time % 60;

            string display = minutes >= 10 ? minutes + ":" : "0" + minutes + ":";
            display += seconds >= 10 ? seconds + "" : "0" + seconds;
            timeText.text = display;

            float angle = Map(time, 0, GameManager.Instance.LevelTime, 90, -90);
            timerTransform.rotation = Quaternion.Euler(0, 0, angle);

            yield return new WaitForSeconds(1);
            time -= 1;
        }

        GameManager.Instance.TimerEnded();
    }

    private  float Map(float x, float in_min, float in_max, float out_min, float out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }
}
