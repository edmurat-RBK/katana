using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShurikenBehaviour : MonoBehaviour
{
    public GameObject UIshuriken;
    bool buttonDown = false;


    void Update()
    {
        if (Mathf.Abs(Input.GetAxis("RangeAttack")) == 1)
        {
            UIshuriken.SetActive(true);
        }
        else
        {
            UIshuriken.SetActive(false);
        }

        
    }
}
