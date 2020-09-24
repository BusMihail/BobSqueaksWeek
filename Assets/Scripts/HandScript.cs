using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    // store how much the mouse has moved since the last frame
    public Vector3 mouseDelta = Vector3.zero;

    private Vector3 lastMousePosition = Vector3.zero;

    public ToiletScript game;
    public float mouseSensitivity = 0.5f;
    private float time = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mouseDelta = Input.mousePosition - lastMousePosition;
        lastMousePosition = Input.mousePosition;

        if (time > 0)
            time -= Time.deltaTime;
        else
            GetComponent<Rigidbody2D>().velocity = mouseDelta*mouseSensitivity;
    }
}
