using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShurikenBehaviour : MonoBehaviour
{
    public GameObject UIshuriken;
    bool buttonDown = false;


    void Update()
    {
        if (Input.GetButton("RangeAttack"))
        {
            UIshuriken.SetActive(true);
        }
        else
        {
            UIshuriken.SetActive(false);
        }

        
    }
}
