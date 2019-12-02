using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOpacityManager : MonoBehaviour
{

    public GameObject menuFX;
    public GameObject fridgeFX;
    private Color lowOpacity;

    // Start is called before the first frame update
    void Start()
    {
        lowOpacity = new Color(1f, 1f, 1f, 0.5f);
        fridgeFX.GetComponent<SpriteRenderer>().color = lowOpacity;
        menuFX.GetComponent<SpriteRenderer>().color = lowOpacity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetOpacity(GameObject sprite)
    {
        sprite.GetComponent<SpriteRenderer>().color = lowOpacity;
    }

    public void IncreaseOpacity(GameObject sprite)
    {
        //float alpha = 0.5f;
        //alpha += Time.deltaTime * 3;
        sprite.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }
}
