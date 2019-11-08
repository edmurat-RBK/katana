using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplate : MonoBehaviour
{
    public int maximumDistance = 10;
    public float ratio1Door = 0.2f;
    public float ratio2Door = 0.5f;
    public float ratio3Door = 0.2f;
    public float ratio4Door = 0.1f;
    public GameObject spawnpointPrefab;

    public GameObject basketPrefab;

    public GameObject[] north;
    public GameObject[] east;
    public GameObject[] south;
    public GameObject[] west;

    public GameObject[] northEast;
    public GameObject[] northSouth;
    public GameObject[] northWest;
    public GameObject[] southEast;
    public GameObject[] southWest;
    public GameObject[] eastWest;

    public GameObject[] northSouthEast;
    public GameObject[] northSouthWest;
    public GameObject[] northEastWest;
    public GameObject[] southEastWest;

    public GameObject[] northEastSouthWest;
}
