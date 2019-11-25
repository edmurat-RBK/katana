using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRecenter : MonoBehaviour
{

    private GameObject mainCamera;
    private static float nextPositionX;
    private static float nextPositionY;
    private float travellingSpeed;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        travellingSpeed = 0.08f;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            nextPositionX = transform.position.x;
            nextPositionY = transform.position.y;

            GameObject parent = transform.parent.gameObject;
            Transform[] tsfm = parent.GetComponentsInChildren<Transform>();
            List<GameObject> children = new List<GameObject>();
            foreach(Transform child in tsfm)
            {
                if (child.tag == "EnemySpawner")
                { 
                    children.Add(child.gameObject);
                }
            }

            foreach(GameObject go in children)
            {
                go.GetComponent<EnemySpawner>().ActivateSpawn();
                Destroy(go);
            }
        }
    }

    void Update()
    {
        if(mainCamera.transform.position.x < nextPositionX)
        {
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x + travellingSpeed, mainCamera.transform.position.y, mainCamera.transform.position.z);
            if(mainCamera.transform.position.x >= nextPositionX)
            {
                mainCamera.transform.position = new Vector3(nextPositionX, nextPositionY, mainCamera.transform.position.z);
            }
        }
        else if(mainCamera.transform.position.x > nextPositionX)
        {
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x - travellingSpeed, mainCamera.transform.position.y, mainCamera.transform.position.z);
            if (mainCamera.transform.position.x <= nextPositionX)
            {
                mainCamera.transform.position = new Vector3(nextPositionX, nextPositionY, mainCamera.transform.position.z);
            }
        }


        if (mainCamera.transform.position.y < nextPositionY)
        {
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y + travellingSpeed, mainCamera.transform.position.z);
            if (mainCamera.transform.position.y >= nextPositionY)
            {
                mainCamera.transform.position = new Vector3(nextPositionX, nextPositionY, mainCamera.transform.position.z);
            }
        }
        else if (mainCamera.transform.position.y > nextPositionY)
        {
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y - travellingSpeed, mainCamera.transform.position.z);
            if (mainCamera.transform.position.y <= nextPositionY)
            {
                mainCamera.transform.position = new Vector3(nextPositionX, nextPositionY, mainCamera.transform.position.z);
            }
        }
    }
}
