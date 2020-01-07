using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRecenter : MonoBehaviour
{

    private GameObject mainCamera;
    private static float nextPositionX;
    private static float nextPositionY;
    public float travellingSpeed = 1f;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
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
                go.GetComponent<EnemySpawner>().Invoke("ActivateSpawn",0.5f);
            }
        }
    }

    void Update()
    {
        if(mainCamera.transform.position.x < nextPositionX)
        {
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, new Vector3(nextPositionX, nextPositionY, mainCamera.transform.position.z), travellingSpeed * Time.deltaTime);
            if (mainCamera.transform.position.x >= nextPositionX)
            {
                mainCamera.transform.position = new Vector3(nextPositionX, nextPositionY, mainCamera.transform.position.z);
            }
        }
        else if(mainCamera.transform.position.x > nextPositionX)
        {
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, new Vector3(nextPositionX, nextPositionY, mainCamera.transform.position.z), travellingSpeed * Time.deltaTime);
            if (mainCamera.transform.position.x <= nextPositionX)
            {
                mainCamera.transform.position = new Vector3(nextPositionX, nextPositionY, mainCamera.transform.position.z);
            }
        }


        if (mainCamera.transform.position.y < nextPositionY)
        {
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, new Vector3(nextPositionX, nextPositionY, mainCamera.transform.position.z), travellingSpeed * Time.deltaTime);
            if (mainCamera.transform.position.y >= nextPositionY)
            {
                mainCamera.transform.position = new Vector3(nextPositionX, nextPositionY, mainCamera.transform.position.z);
            }
        }
        else if (mainCamera.transform.position.y > nextPositionY)
        {
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, new Vector3(nextPositionX, nextPositionY, mainCamera.transform.position.z), travellingSpeed * Time.deltaTime);
            if (mainCamera.transform.position.y <= nextPositionY)
            {
                mainCamera.transform.position = new Vector3(nextPositionX, nextPositionY, mainCamera.transform.position.z);
            }
        }
    }
}
