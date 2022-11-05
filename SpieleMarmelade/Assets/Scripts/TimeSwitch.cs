using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSwitch : MonoBehaviour
{
    [SerializeField] GameObject pastLevel;
    [SerializeField] GameObject futureLevel;

    [Header("Sounds")]
    [SerializeField] private GameObject pastMusic;
    [SerializeField] private GameObject futureMusic;
    private AudioSource pastMusicAudioSource;
    private AudioSource futureMusicAudioSource;
    [SerializeField] private GameObject transitionSound;

    private enum TimeState {past, future};
    private TimeState timeState;

    private void Start()
    {
        pastMusicAudioSource = pastMusic.GetComponent<AudioSource>();
        futureMusicAudioSource = futureMusic.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SwitchTimeState();
        }
    }

    private void SwitchTimeState()
    {
        switch (timeState)
        {
            case TimeState.past:
                //Environment
                pastLevel.SetActive(false);
                futureLevel.SetActive(true);
                
                //Sounds and Music
                StartCoroutine(MusicTransition(pastMusicAudioSource, futureMusicAudioSource));
                transitionSound.SetActive(false);
                transitionSound.SetActive(true);
                
                timeState = TimeState.future;
                break;
            
            case TimeState.future:
                //Environment
                pastLevel.SetActive(true);
                futureLevel.SetActive(false);
                
                //Sounds and Music
                StartCoroutine(MusicTransition(futureMusicAudioSource, pastMusicAudioSource));
                transitionSound.SetActive(false);
                transitionSound.SetActive(true);
                
                timeState = TimeState.past;
                break;
        }
    }

    private IEnumerator MusicTransition(AudioSource current, AudioSource next)
    {
        while (current.volume > 0)
        {
            current.volume -= 0.001f;
            next.volume += 0.001f;
            yield return new WaitForSeconds(0.01f);
        }
    }
}