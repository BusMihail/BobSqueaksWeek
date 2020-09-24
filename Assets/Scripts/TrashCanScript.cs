using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanScript : MonoBehaviour
{
    private ToiletScript toiletScript;

    private void Awake()
    {
        toiletScript = GetComponentInParent<ToiletScript>();    
    }

    public void TrashCanClicked()
    {
        if (toiletScript.canMode)
        {
            // trashcan clicked
            toiletScript.ThrowCan();
        }
    }


}
