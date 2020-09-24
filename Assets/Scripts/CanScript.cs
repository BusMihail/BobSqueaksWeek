using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class CanScript : MonoBehaviour
{
    public ToiletScript game;

    public bool isFull;

    private void Awake()
    {
        game = transform.parent.parent.GetComponent<ToiletScript>();
    }

    public void TakeCan()
    {
        game.TakeCan(this);
    }
}
