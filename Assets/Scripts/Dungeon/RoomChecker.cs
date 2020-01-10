using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomChecker : MonoBehaviour
{

    private BoxCollider2D roomCheckerCollider;
    private ContactFilter2D enemySpawnerFilter;
    private ContactFilter2D enemyFilter;
    public LayerMask enemySpawnerLayer;
    public LayerMask enemyLayer;
    private BoxCollider2D[] checkerResults;
    private BoxCollider2D[] spawnerResults;
    bool checking = true;
    private GameObject gameManager;
    private GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        manager = gameManager.GetComponent<GameManager>();
        roomCheckerCollider = GetComponent<BoxCollider2D>();
        enemySpawnerFilter.SetLayerMask(enemySpawnerLayer);
        enemyFilter.SetLayerMask(enemyLayer);
        checkerResults = new BoxCollider2D[150];
        spawnerResults = new BoxCollider2D[1000];
        StartCoroutine(RoomCheck());

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(roomCheckerCollider.OverlapCollider(enemySpawnerFilter, spawnerResults));
    }

    IEnumerator RoomCheck()
    {
        while (checking)
        {
            yield return new WaitForSeconds(2f);
            if (roomCheckerCollider.OverlapCollider(enemySpawnerFilter, spawnerResults) == 0 && roomCheckerCollider.OverlapCollider(enemyFilter, checkerResults) == 0)
            {
                yield return new WaitForSeconds(5f);
                Debug.Log("Il y a plus de mobs");
                if (manager.restartCounter < 3)
                {
                    manager.restartCounter++;
                    SceneManager.LoadScene("SandboxScene");
                    for(int i = 0; i<3; i++)
                    {
                        gameManager.GetComponent<GameManager>().fridgeInventory.Add(Item.LEMON);
                    }
                }
                else
                {
                    SceneManager.LoadScene("HubScene");
                    manager.restartCounter = 0;
                }   
            }
            else 
            {
                Debug.Log("Il reste des mobs");

            }
            
        }
        
          
    }
}
