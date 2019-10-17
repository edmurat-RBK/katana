using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    private bool canBePickedUp;
    private bool isCarrying;
<<<<<<< HEAD
=======
    private bool candrop;
>>>>>>> pre-prod
    Transform picker;
    private Renderer rend;
     

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
        StartCoroutine("LootPerish");
        PickAndDrop();
        Consume();
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

  
     void PickAndDrop()
     {
        if(Input.GetButtonDown("Pick"))
        {
            if(isCarrying == false && canBePickedUp)
            {
                transform.position = picker.position;
                transform.SetParent(picker);
                isCarrying = true;
            }

            else
            {
                transform.parent = null;
                isCarrying = false ;
            }
        }
     }

    private void Consume()
    {
        if(Input.GetButtonDown("Consume") && isCarrying)
        {
            Destroy(gameObject);
            //add effect !
        }

    }

    IEnumerator LootPerish()
    {
        yield return new WaitForSeconds(5);
        if (isCarrying == false)
        {
            Destroy(gameObject);
        }       
    }
     
   

}
