using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRecenter : MonoBehaviour
{

    private GameObject camera;

    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            camera.transform.position = new Vector3(transform.position.x, transform.position.y,camera.transform.position.z);
        }
    }
}
