using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowScript : MonoBehaviour
{
    public WindowMinigame windowMinigame;

    bool isHeld = false;
    private Vector3 lastPos;
    public Vector3 delta;
    bool holdable = true;
    Rigidbody2D rb;

    private void Awake()
    {
        windowMinigame = GetComponentInParent<WindowMinigame>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Basically while the game isnt finished
        if (holdable)
        {
            delta = Input.mousePosition - lastPos;
            lastPos = Input.mousePosition;

            if (Input.GetMouseButtonDown(0))
            {
                isHeld = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                isHeld = false;
            }

            if (isHeld) 
            {
                if (delta.y < 0)
                    rb.velocity += new Vector2(0, delta.y);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Bottom"))
        {
            if (UnityEngine.Random.Range(0f, 1f) >= 0.275)
            {
                rb.velocity = new Vector2(0, UnityEngine.Random.Range(125f, 200f));
            }
            else
            {
                rb.velocity = Vector3.zero;
                holdable = false;
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
                GetComponent<AudioSource>().Play();
                //GAME
                //IS
                //WIN
                windowMinigame.WinMinigame();
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
        }

    }
}
