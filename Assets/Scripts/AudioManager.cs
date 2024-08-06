using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource soundSource;

    public AudioClip[] music;
    public AudioClip jump;
    public AudioClip death;
    public AudioClip collect;

    private void Start()
    {
        musicSource.clip = music[UnityEngine.Random.Range(0, music.Length)];
        musicSource.Play();
    }

    public void PlaySound(AudioClip clip) 
    {
        soundSource.PlayOneShot(clip);
    }
}
