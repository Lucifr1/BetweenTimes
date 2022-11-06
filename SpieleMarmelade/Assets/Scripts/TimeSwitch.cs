using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class TimeSwitch : MonoBehaviour
{
    [SerializeField] private float CooldownTime;
    private float currentCooldownTime;
    
    [SerializeField] GameObject pastLevel;
    [SerializeField] GameObject futureLevel;

    [Header("Sounds")]
    [SerializeField] private GameObject pastMusic;
    [SerializeField] private GameObject futureMusic;
    private AudioSource pastMusicAudioSource;
    private AudioSource futureMusicAudioSource;
    [SerializeField] private GameObject transitionSound;

    [SerializeField] private Animator animator;
    public GameObject glitch;

    private enum TimeState {past, future};
    private TimeState timeState;

    private void Start()
    {
        pastMusicAudioSource = pastMusic.GetComponent<AudioSource>();
        futureMusicAudioSource = futureMusic.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (currentCooldownTime > 0)
        {
            currentCooldownTime -= Time.deltaTime;
            return;
        }

        if (Input.GetButtonDown("TimeShift"))
        {
            SwitchTimeState();
        }
    }
    
    public void SwitchTimeState()
    {
        currentCooldownTime = CooldownTime;
        
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
                
                Debug.Log("halli hallo sind wir hier? uwu");
                animator.SetBool("pastTime", false);
                glitch.GetComponent<Glitch>().StartGlitch();
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
                
                animator.SetBool("pastTime", true);
                glitch.GetComponent<Glitch>().StartGlitch();
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