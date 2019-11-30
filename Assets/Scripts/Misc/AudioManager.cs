using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip mainTheme;
    public AudioSource musicSource;
    private AudioLowPassFilter lowPassFilter;
    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = mainTheme;
        musicSource.Play();
        lowPassFilter = GetComponent<AudioLowPassFilter>();
        lowPassFilter.cutoffFrequency = 1000;
        lowPassFilter.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoundCutoffOn()
    {
        lowPassFilter.enabled = true;
    }

    public void SoundCutoffOff()
    {
        lowPassFilter.enabled = false;
    }
}
