using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumeFx : MonoBehaviour
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void GetAnimationEvent(string eventMessage)
    {
        if(eventMessage.Equals("FxEnded"))
        {
            anim.SetBool("isConsuming", false);
        }
    }
}
