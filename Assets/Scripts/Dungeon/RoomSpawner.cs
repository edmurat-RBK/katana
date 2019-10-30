using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public enum Direction
    {
        NORTH = 0,
        EAST = 1,
        SOUTH = 2,
        WEST = 3,
        NONE = 4
    }

    public Direction openDoor;
    private RoomTemplates templates;

    
    private bool spawned = false;

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    void Spawn()
    {
        if (!spawned)
        {
            switch (openDoor)
            {
                case Direction.NORTH:
                    Instantiate(templates.southDoor[Random.Range(0, templates.southDoor.Length)], transform.position, Quaternion.identity);
                    Debug.Log("Instanciate South-doored room");
                    break;
                case Direction.EAST:
                    Instantiate(templates.westDoor[Random.Range(0, templates.westDoor.Length)], transform.position, Quaternion.identity);
                    Debug.Log("Instanciate West-doored room");
                    break;
                case Direction.SOUTH:
                    Instantiate(templates.northDoor[Random.Range(0, templates.northDoor.Length)], transform.position, Quaternion.identity);
                    Debug.Log("Instanciate North-doored room");
                    break;
                case Direction.WEST:
                    Instantiate(templates.eastDoor[Random.Range(0, templates.eastDoor.Length)], transform.position, Quaternion.identity);
                    Debug.Log("Instanciate East-doored room");
                    break;
                default:
                    // Do nothing
                    break;
            }
            spawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Spawn Point") && other.GetComponent<RoomSpawner>().spawned)
        {
            Destroy(gameObject);
        }
    }

}
