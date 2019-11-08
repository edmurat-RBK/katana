using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonProjectile : MonoBehaviour
{

    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private Transform origin;
    [SerializeField] private GameObject target;


    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, origin.position) >= maxDistance)//mort par distance
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
