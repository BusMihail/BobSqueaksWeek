using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject endingGood;
    public GameObject endingBad;
    public GameObject intro;


    public void ActivateGoodEnd()
    {
        endingGood.SetActive(true);
    }

    public void ActivateBadEnd()
    {
        endingBad.SetActive(true);
    }

    public void ActivateIntro()
    {
        intro.SetActive(true);
    }

    public void CloseAll()
    {
        endingGood.SetActive(false);
        endingBad.SetActive(false);
        intro.SetActive(false);
    }

    public void StartGame()
    {
        GameManager.Instance.StartDay();
    }

    public void ResetGame()
    {
        GameManager.Instance.ResetGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
