/*
NO LONGER USED

*/
using System.Collections;
using UnityEngine;

public class AmbientMusicManager : MonoBehaviour
{
    private AudioSource audioSource;  // The AudioSource component
    public AudioClip victoryClip; // Reference to the new AudioClip you want to play
    public AudioClip loseClip;
    private VolumeControl volumeControl;
    

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        volumeControl = GameObject.FindGameObjectWithTag("VolumeControl").GetComponent<VolumeControl>();

        // Start playing the intro
        SetVolume();
    }

    public void ChangeVolume(float newVolume) {
        volumeControl.volume = newVolume;
        SetVolume();
    }

    public float GetVolume() {
        return volumeControl.volume;
    }

    public void PlayVictory()
    {
        audioSource.Stop();
        audioSource.clip = victoryClip;
        audioSource.Play();
    }

    public void PlayLoss()
    {
        audioSource.Stop();
        audioSource.clip = loseClip;
        audioSource.Play();
    }

    public void SetVolume() {
        audioSource.volume = volumeControl.volume;
    }
}
