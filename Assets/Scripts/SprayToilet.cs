using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayToilet : MonoBehaviour
{
    private ToiletScript toiletScript;

    private void Awake()
    {
        toiletScript = transform.parent.GetComponentInParent<ToiletScript>();
    }

    public void UseSpray()
    {
        if (toiletScript.canMode)
        {
            print("Toilet Clicked");
            toiletScript.SprayToilet();
        }
    }
}
