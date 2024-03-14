using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVActivator : MonoBehaviour
{
    SoundManager soundManager;
    TVScreenManager tvImage;
    float timer = 0;
    float delay = 0;
    private bool timerstarted = false;
    private bool hasSpeechPlayed = false;
    private bool hasClockPlayed = false;
    private bool tuningIsPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        tvImage = FindAnyObjectByType<TVScreenManager>();
        soundManager = FindAnyObjectByType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerstarted)
        {
            timer += Time.deltaTime;
        }



        if (timerstarted && timer >= delay && hasSpeechPlayed == false)
        {
            if (tuningIsPlaying)
            {
                soundManager.Stop();
                tuningIsPlaying=false;
            }

            soundManager.PlaySpeech();
            hasSpeechPlayed=true;
        }

        if (timerstarted && timer >= delay && hasClockPlayed == false)
        {
            if (tvImage.selectedScreen == 1 || tvImage.selectedScreen == 2)
            {
                if (tuningIsPlaying)
                {
                    soundManager.Stop();
                    tuningIsPlaying = false;
                }
                soundManager.PlayClock1();
                hasClockPlayed=true;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        tvImage.SelectRandomScreen();
        PlayerPrefs.SetInt("screen", tvImage.selectedScreen);
        timerstarted = true;
        delay = 2f;
        soundManager.PlayTuning();
        tuningIsPlaying = true;
        
    }



    

}
