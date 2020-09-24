using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasWheelScript : MonoBehaviour
{
    public Canvas canvas;
    public Text check1;
    public Text check2;
    public Text check3;
    public Text check4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name.Equals("Button1"))
            ChangeCheck(check1, true);
        else if (collision.gameObject.name.Equals("Button2"))
            ChangeCheck(check2, true);
        else if (collision.gameObject.name.Equals("Button3"))
            ChangeCheck(check3, true);
        else if (collision.gameObject.name.Equals("Button4"))
            ChangeCheck(check4, true);

        if (check1.text.Equals(check2.text) && check2.text.Equals(check3.text) && check1.text.Equals("O"))
            if(check4.text.Equals("O"))
                canvas.GetComponent<StoveScript>().WinMinigame();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name.Equals("Button1"))
            ChangeCheck(check1, false);
        else if (collision.gameObject.name.Equals("Button2"))
            ChangeCheck(check2, false);
        else if (collision.gameObject.name.Equals("Button3"))
            ChangeCheck(check3, false);
        else if (collision.gameObject.name.Equals("Button4"))
            ChangeCheck(check4, false);
    }

    void ChangeCheck(Text check, bool isOK)
    {
        if (isOK)
        {
            check.text = "O";
            check.color = Color.green;
        }
        else
        {
            check.text = "X";
            check.color = Color.red;
        }
    }

}
