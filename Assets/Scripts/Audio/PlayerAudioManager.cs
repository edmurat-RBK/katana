using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    public AudioSource soundSource;
    public AudioClip dashSound;
    public AudioClip shurikenSound;
    public AudioClip attackSound;
    public AudioClip pickupSound;
    public AudioClip bonusSound;
    public AudioClip throwSound;
    public AudioClip hitSound;
    public AudioClip stepSound;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayClip(AudioClip clip, float volume)
    {
        float pitch = Random.Range(0.8f, 1.2f);
        soundSource.pitch = pitch;
        soundSource.volume = volume;
        soundSource.clip = clip;
        soundSource.Play();
    }

    public void PlayClipDelay(AudioClip clip, float delay)
    {
        float pitch = Random.Range(0.8f, 1.2f);
        soundSource.pitch = pitch;
        soundSource.clip = clip;
        soundSource.PlayDelayed(delay);
    }
}
