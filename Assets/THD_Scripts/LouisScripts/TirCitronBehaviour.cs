using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirCitronBehaviour : MonoBehaviour
{
    [SerializeField]
    private float DieDist = 10f;

    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, transform.parent.position) >= DieDist)//mort par distance
        {
            Destroy(gameObject);
        }
    }
}
