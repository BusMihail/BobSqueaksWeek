using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoveScript : MonoBehaviour, IMinigame
{

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    public MinigameType minigame { get; set; }
    public Action<IMinigame, bool> OnMinigameFinished { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        System.Random rnd = new System.Random();
        button1.transform.Rotate(new Vector3(0, 0, 90 * rnd.Next(0, 4)));
        button2.transform.Rotate(new Vector3(0, 0, 90 * rnd.Next(0, 4)));
        button3.transform.Rotate(new Vector3(0, 0, 90 * rnd.Next(0, 4)));
        button4.transform.Rotate(new Vector3(0, 0, 90 * rnd.Next(0, 4)));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            button1.transform.Rotate(new Vector3(0, 0, -90));
            button2.transform.Rotate(new Vector3(0, 0, 90));
            button3.transform.Rotate(new Vector3(0, 0, 90));
            button4.transform.Rotate(new Vector3(0, 0, 90));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            button2.transform.Rotate(new Vector3(0, 0, -90));
            button3.transform.Rotate(new Vector3(0, 0, 90));
            button4.transform.Rotate(new Vector3(0, 0, 90));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            button3.transform.Rotate(new Vector3(0, 0, -90));
            button4.transform.Rotate(new Vector3(0, 0, 90));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            button4.transform.Rotate(new Vector3(0, 0, 90));
        }
    }

    public void WinMinigame()
    {
        //MINIGAME
        //IS
        //WON
        OnMinigameFinished(this, true);
        Debug.Log("OMG CE DESTEPT ESTI");
    }

    public void DestroyMinigame()
    {
        Destroy(gameObject);
    }

    public void ItClicked(int button)
    {
        if (button == 1)
        {
            button1.transform.Rotate(new Vector3(0, 0, -90));
            button2.transform.Rotate(new Vector3(0, 0, 90));
            button3.transform.Rotate(new Vector3(0, 0, 90));
            button4.transform.Rotate(new Vector3(0, 0, 90));
        }
        else if (button == 2)
        {
            button2.transform.Rotate(new Vector3(0, 0, -90));
            button3.transform.Rotate(new Vector3(0, 0, 90));
            button4.transform.Rotate(new Vector3(0, 0, 90));
        }
        else if (button == 3)
        {
            button3.transform.Rotate(new Vector3(0, 0, -90));
            button4.transform.Rotate(new Vector3(0, 0, 90));
        }
        else if (button == 4)
        {
            button4.transform.Rotate(new Vector3(0, 0, 90));
        }
    }
}
