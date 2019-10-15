using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    private bool canBePickedUp;
    private bool isCarrying;
    //private bool candrop
    Transform picker;
    // Start is called before the first frame update
    void Start()
    {
        canBePickedUp = false;
        isCarrying = false; 
        picker = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        PickUp();
        Drop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canBePickedUp = true; 
        Debug.Log("I can be picked up");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canBePickedUp = false;
        Debug.Log("I can't be picked up anymore");
    }

    private void PickUp()
    {
        if(canBePickedUp && Input.GetAxis("Pick") == 1 && isCarrying == false)
        {
            transform.SetParent(picker);     
        }

        if (Input.GetAxis("Pick") == 0)
        {
            isCarrying = true ;
        }
    }

    private void Drop()
    {
        if (isCarrying == true && Input.GetAxis("Pick") == 1)
        {
            transform.parent = null;
        }

    }

}
