using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    public int roomDistance = 0;
    public static int instanceCount = 0;
    public int id = 0;

    public bool northDoor = false;
    public bool eastDoor = false;
    public bool southDoor = false;
    public bool westDoor = false;

    public bool originNorth = false;
    public bool originEast = false;
    public bool originSouth = false;
    public bool originWest = false;

    private RoomTemplate template;

    private bool spawned = false;


    void Start()
    {
        template = GameObject.FindGameObjectWithTag("Template").GetComponent<RoomTemplate>();
        instanceCount++;

        id = instanceCount;
        Invoke("CreateSpawnpointAround", 0.05f);
        Invoke("SpawnRoom", 0.05f * (template.maximumDistance + 5));
    }

    void CreateSpawnpointAround()
    {
        if (!spawned)
        {
            if (northDoor)
            {
                GameObject newInstance = Instantiate(template.spawnpointPrefab, new Vector3(transform.position.x, transform.position.y + 4.48f, 0f), Quaternion.identity);
                newInstance.GetComponent<RoomSpawner>().roomDistance = roomDistance + 1;
                newInstance.GetComponent<RoomSpawner>().originSouth = true;
                float rdm1 = Random.Range(0f, 1f);
                if((0f <= rdm1 && rdm1 < template.ratio1Door) || (roomDistance+1 == template.maximumDistance))
                {
                    newInstance.GetComponent<RoomSpawner>().southDoor = true;
                }
                else if(template.ratio1Door <= rdm1 && rdm1 < template.ratio1Door+template.ratio2Door)
                {
                    float rdm2 = Random.Range(0f, 1f);
                    if(0f <= rdm2 && rdm2 < 0.334f)
                    {
                        newInstance.GetComponent<RoomSpawner>().northDoor = true;
                        newInstance.GetComponent<RoomSpawner>().southDoor = true;
                    }
                    else if(0.334f <= rdm2 && rdm2 < 0.667f)
                    {
                        newInstance.GetComponent<RoomSpawner>().southDoor = true;
                        newInstance.GetComponent<RoomSpawner>().eastDoor = true;
                    }
                    else
                    {
                        newInstance.GetComponent<RoomSpawner>().southDoor = true;
                        newInstance.GetComponent<RoomSpawner>().westDoor = true;
                    }
                }
                else if (template.ratio1Door+template.ratio2Door <= rdm1 && rdm1 < template.ratio1Door+template.ratio2Door+template.ratio3Door)
                {
                    float rdm2 = Random.Range(0f, 1f);
                    if (0f <= rdm2 && rdm2 < 0.334f)
                    {
                        newInstance.GetComponent<RoomSpawner>().northDoor = true;
                        newInstance.GetComponent<RoomSpawner>().southDoor = true;
                        newInstance.GetComponent<RoomSpawner>().eastDoor = true;
                    }
                    else if (0.334f <= rdm2 && rdm2 < 0.667f)
                    {
                        newInstance.GetComponent<RoomSpawner>().northDoor = true;
                        newInstance.GetComponent<RoomSpawner>().southDoor = true;
                        newInstance.GetComponent<RoomSpawner>().westDoor = true;
                    }
                    else
                    {
                        newInstance.GetComponent<RoomSpawner>().southDoor = true;
                        newInstance.GetComponent<RoomSpawner>().eastDoor = true;
                        newInstance.GetComponent<RoomSpawner>().westDoor = true;
                    }
                }
                else
                {
                    newInstance.GetComponent<RoomSpawner>().northDoor = true;
                    newInstance.GetComponent<RoomSpawner>().eastDoor = true;
                    newInstance.GetComponent<RoomSpawner>().southDoor = true;
                    newInstance.GetComponent<RoomSpawner>().westDoor = true;
                }
            }

            if (eastDoor)
            {
                GameObject newInstance = Instantiate(template.spawnpointPrefab, new Vector3(transform.position.x + 7.04f, transform.position.y, 0f), Quaternion.identity);
                newInstance.GetComponent<RoomSpawner>().roomDistance = roomDistance + 1;
                newInstance.GetComponent<RoomSpawner>().originWest = true;
                float rdm1 = Random.Range(0f, 1f);
                if ((0f <= rdm1 && rdm1 < template.ratio1Door) || (roomDistance + 1 == template.maximumDistance))
                {
                    newInstance.GetComponent<RoomSpawner>().westDoor = true;
                }
                else if (template.ratio1Door <= rdm1 && rdm1 < template.ratio1Door + template.ratio2Door)
                {
                    float rdm2 = Random.Range(0f, 1f);
                    if (0f <= rdm2 && rdm2 < 0.334f)
                    {
                        newInstance.GetComponent<RoomSpawner>().northDoor = true;
                        newInstance.GetComponent<RoomSpawner>().westDoor = true;
                    }
                    else if (0.334f <= rdm2 && rdm2 < 0.667f)
                    {
                        newInstance.GetComponent<RoomSpawner>().southDoor = true;
                        newInstance.GetComponent<RoomSpawner>().westDoor = true;
                    }
                    else
                    {
                        newInstance.GetComponent<RoomSpawner>().eastDoor = true;
                        newInstance.GetComponent<RoomSpawner>().westDoor = true;
                    }
                }
                else if (template.ratio1Door + template.ratio2Door <= rdm1 && rdm1 < template.ratio1Door + template.ratio2Door + template.ratio3Door)
                {
                    float rdm2 = Random.Range(0f, 1f);
                    if (0f <= rdm2 && rdm2 < 0.334f)
                    {
                        newInstance.GetComponent<RoomSpawner>().northDoor = true;
                        newInstance.GetComponent<RoomSpawner>().southDoor = true;
                        newInstance.GetComponent<RoomSpawner>().westDoor = true;
                    }
                    else if (0.334f <= rdm2 && rdm2 < 0.667f)
                    {
                        newInstance.GetComponent<RoomSpawner>().northDoor = true;
                        newInstance.GetComponent<RoomSpawner>().eastDoor = true;
                        newInstance.GetComponent<RoomSpawner>().westDoor = true;
                    }
                    else
                    {
                        newInstance.GetComponent<RoomSpawner>().southDoor = true;
                        newInstance.GetComponent<RoomSpawner>().eastDoor = true;
                        newInstance.GetComponent<RoomSpawner>().westDoor = true;
                    }
                }
                else
                {
                    newInstance.GetComponent<RoomSpawner>().northDoor = true;
                    newInstance.GetComponent<RoomSpawner>().eastDoor = true;
                    newInstance.GetComponent<RoomSpawner>().southDoor = true;
                    newInstance.GetComponent<RoomSpawner>().westDoor = true;
                }
            }

            if (southDoor)
            {
                GameObject newInstance = Instantiate(template.spawnpointPrefab, new Vector3(transform.position.x, transform.position.y - 4.48f, 0f), Quaternion.identity);
                newInstance.GetComponent<RoomSpawner>().roomDistance = roomDistance + 1;
                newInstance.GetComponent<RoomSpawner>().originNorth = true;
                float rdm1 = Random.Range(0f, 1f);
                if ((0f <= rdm1 && rdm1 < template.ratio1Door) || (roomDistance + 1 == template.maximumDistance))
                {
                    newInstance.GetComponent<RoomSpawner>().northDoor = true;
                }
                else if (template.ratio1Door <= rdm1 && rdm1 < template.ratio1Door + template.ratio2Door)
                {
                    float rdm2 = Random.Range(0f, 1f);
                    if (0f <= rdm2 && rdm2 < 0.334f)
                    {
                        newInstance.GetComponent<RoomSpawner>().northDoor = true;
                        newInstance.GetComponent<RoomSpawner>().westDoor = true;
                    }
                    else if (0.334f <= rdm2 && rdm2 < 0.667f)
                    {
                        newInstance.GetComponent<RoomSpawner>().northDoor = true;
                        newInstance.GetComponent<RoomSpawner>().eastDoor = true;
                    }
                    else
                    {
                        newInstance.GetComponent<RoomSpawner>().northDoor = true;
                        newInstance.GetComponent<RoomSpawner>().southDoor = true;
                    }
                }
                else if (template.ratio1Door + template.ratio2Door <= rdm1 && rdm1 < template.ratio1Door + template.ratio2Door + template.ratio3Door)
                {
                    float rdm2 = Random.Range(0f, 1f);
                    if (0f <= rdm2 && rdm2 < 0.334f)
                    {
                        newInstance.GetComponent<RoomSpawner>().northDoor = true;
                        newInstance.GetComponent<RoomSpawner>().southDoor = true;
                        newInstance.GetComponent<RoomSpawner>().westDoor = true;
                    }
                    else if (0.334f <= rdm2 && rdm2 < 0.667f)
                    {
                        newInstance.GetComponent<RoomSpawner>().northDoor = true;
                        newInstance.GetComponent<RoomSpawner>().eastDoor = true;
                        newInstance.GetComponent<RoomSpawner>().westDoor = true;
                    }
                    else
                    {
                        newInstance.GetComponent<RoomSpawner>().northDoor = true;
                        newInstance.GetComponent<RoomSpawner>().southDoor = true;
                        newInstance.GetComponent<RoomSpawner>().eastDoor = true;
                    }
                }
                else
                {
                    newInstance.GetComponent<RoomSpawner>().northDoor = true;
                    newInstance.GetComponent<RoomSpawner>().eastDoor = true;
                    newInstance.GetComponent<RoomSpawner>().southDoor = true;
                    newInstance.GetComponent<RoomSpawner>().westDoor = true;
                }
            }

            if (westDoor)
            {
                GameObject newInstance = Instantiate(template.spawnpointPrefab, new Vector3(transform.position.x - 7.04f, transform.position.y, 0f), Quaternion.identity);
                newInstance.GetComponent<RoomSpawner>().roomDistance = roomDistance + 1;
                newInstance.GetComponent<RoomSpawner>().originEast = true;
                float rdm1 = Random.Range(0f, 1f);
                if ((0f <= rdm1 && rdm1 < template.ratio1Door) || (roomDistance + 1 == template.maximumDistance))
                {
                    newInstance.GetComponent<RoomSpawner>().eastDoor = true;
                }
                else if (template.ratio1Door <= rdm1 && rdm1 < template.ratio1Door + template.ratio2Door)
                {
                    float rdm2 = Random.Range(0f, 1f);
                    if (0f <= rdm2 && rdm2 < 0.334f)
                    {
                        newInstance.GetComponent<RoomSpawner>().northDoor = true;
                        newInstance.GetComponent<RoomSpawner>().eastDoor = true;
                    }
                    else if (0.334f <= rdm2 && rdm2 < 0.667f)
                    {
                        newInstance.GetComponent<RoomSpawner>().southDoor = true;
                        newInstance.GetComponent<RoomSpawner>().eastDoor = true;
                    }
                    else
                    {
                        newInstance.GetComponent<RoomSpawner>().eastDoor = true;
                        newInstance.GetComponent<RoomSpawner>().westDoor = true;
                    }
                }
                else if (template.ratio1Door + template.ratio2Door <= rdm1 && rdm1 < template.ratio1Door + template.ratio2Door + template.ratio3Door)
                {
                    float rdm2 = Random.Range(0f, 1f);
                    if (0f <= rdm2 && rdm2 < 0.334f)
                    {
                        newInstance.GetComponent<RoomSpawner>().northDoor = true;
                        newInstance.GetComponent<RoomSpawner>().southDoor = true;
                        newInstance.GetComponent<RoomSpawner>().eastDoor = true;
                    }
                    else if (0.334f <= rdm2 && rdm2 < 0.667f)
                    {
                        newInstance.GetComponent<RoomSpawner>().northDoor = true;
                        newInstance.GetComponent<RoomSpawner>().eastDoor = true;
                        newInstance.GetComponent<RoomSpawner>().westDoor = true;
                    }
                    else
                    {
                        newInstance.GetComponent<RoomSpawner>().westDoor = true;
                        newInstance.GetComponent<RoomSpawner>().southDoor = true;
                        newInstance.GetComponent<RoomSpawner>().eastDoor = true;
                    }
                }
                else
                {
                    newInstance.GetComponent<RoomSpawner>().northDoor = true;
                    newInstance.GetComponent<RoomSpawner>().eastDoor = true;
                    newInstance.GetComponent<RoomSpawner>().southDoor = true;
                    newInstance.GetComponent<RoomSpawner>().westDoor = true;
                }
            }

            spawned = true;
        }
    }

    void SpawnRoom()
    {
        if (northDoor && !eastDoor && !southDoor && !westDoor)
        {
            Instantiate(template.north[Random.Range(0, template.north.Length)], transform.position, Quaternion.identity);
        }
        else if (!northDoor && eastDoor && !southDoor && !westDoor)
        {
            Instantiate(template.east[Random.Range(0, template.east.Length)], transform.position, Quaternion.identity);
        }
        else if (!northDoor && !eastDoor && southDoor && !westDoor)
        {
            Instantiate(template.south[Random.Range(0, template.south.Length)], transform.position, Quaternion.identity);
        }
        else if (!northDoor && !eastDoor && !southDoor && westDoor)
        {
            Instantiate(template.west[Random.Range(0, template.west.Length)], transform.position, Quaternion.identity);
        }
        else if (northDoor && eastDoor && !southDoor && !westDoor)
        {
            Instantiate(template.northEast[Random.Range(0, template.northEast.Length)], transform.position, Quaternion.identity);
        }
        else if (northDoor && !eastDoor && !southDoor && westDoor)
        {
            Instantiate(template.northWest[Random.Range(0, template.northWest.Length)], transform.position, Quaternion.identity);
        }
        else if (northDoor && !eastDoor && southDoor && !westDoor)
        {
            Instantiate(template.northSouth[Random.Range(0, template.northSouth.Length)], transform.position, Quaternion.identity);
        }
        else if (!northDoor && eastDoor && !southDoor && westDoor)
        {
            Instantiate(template.eastWest[Random.Range(0, template.eastWest.Length)], transform.position, Quaternion.identity);
        }
        else if (!northDoor && eastDoor && southDoor && !westDoor)
        {
            Instantiate(template.southEast[Random.Range(0, template.southEast.Length)], transform.position, Quaternion.identity);
        }
        else if (!northDoor && !eastDoor && southDoor && westDoor)
        {
            Instantiate(template.southWest[Random.Range(0, template.southWest.Length)], transform.position, Quaternion.identity);
        }
        else if (northDoor && eastDoor && southDoor && !westDoor)
        {
            Instantiate(template.northSouthEast[Random.Range(0, template.northSouthEast.Length)], transform.position, Quaternion.identity);
        }
        else if (northDoor && eastDoor && !southDoor && westDoor)
        {
            Instantiate(template.northEastWest[Random.Range(0, template.northEastWest.Length)], transform.position, Quaternion.identity);
        }
        else if (northDoor && !eastDoor && southDoor && westDoor)
        {
            Instantiate(template.northSouthWest[Random.Range(0, template.northSouthWest.Length)], transform.position, Quaternion.identity);
        }
        else if (!northDoor && eastDoor && southDoor && westDoor)
        {
            Instantiate(template.southEastWest[Random.Range(0, template.southEastWest.Length)], transform.position, Quaternion.identity);
        }
        else if (northDoor && eastDoor && southDoor && westDoor)
        {
            Instantiate(template.northEastSouthWest[Random.Range(0, template.northEastSouthWest.Length)], transform.position, Quaternion.identity);
        }
        //Destroy(gameObject);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Spawnpoint") && other.GetComponent<RoomSpawner>().spawned)
        {
            if (other.GetComponent<RoomSpawner>().id < id)
            {
                if(originNorth) { other.GetComponent<RoomSpawner>().northDoor = true; }
                else if (originEast) { other.GetComponent<RoomSpawner>().eastDoor = true; }
                else if (originSouth) { other.GetComponent<RoomSpawner>().southDoor = true; }
                else if (originWest) { other.GetComponent<RoomSpawner>().westDoor = true; }

                Destroy(gameObject);
            }
        }
    }
}
