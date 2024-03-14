using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource source;

    public AudioClip clock1;
    public AudioClip clock2;
    public AudioClip tuning;
    public AudioClip speech;
    
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayClock1()
    {
        source.PlayOneShot(clock1);
    }

    public void PlayClock2()
    {
        source.PlayOneShot(clock2);
    }

    public void PlayTuning()
    {
        source.PlayOneShot(tuning);
        
    }

    public void PlaySpeech()
    {
        source.PlayOneShot(speech);
    }

    public void Stop()
    {
        source.Stop();
    }




}
