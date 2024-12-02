using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour
{
    public double musicDuration;
    public double goalTime;
    public AudioSource[] _audioSource;
    public int audioToggle;
    public AudioClip clip;
    public float fadeDuration = 1f;
    private double volume;
    private bool isFading = false;

    private void Start() {
        audioToggle = 0;
    }

    private void Update() {

        if (clip != null && AudioSettings.dspTime > goalTime - 1) {
            PlayScheduledClip();
        }
    }

    private void PlayMusic() {
        goalTime = AudioSettings.dspTime;
        _audioSource[audioToggle].clip = clip;
        _audioSource[audioToggle].Play();

        audioToggle = 1 - audioToggle;

    }

    private void PlayScheduledClip() {
        _audioSource[audioToggle].clip = clip;
        if (isFading) {return;}
        else {
            _audioSource[audioToggle].PlayScheduled(goalTime);

            musicDuration = (double)clip.samples / clip.frequency;
            goalTime = goalTime + musicDuration;

            audioToggle = 1 - audioToggle;
        }
    }

    public void ChangeClip(AudioClip newClip) {
        Debug.Log($"{newClip}");
        this.clip = newClip;
    }

    /*public IEnumerator FadeOutAndSwitchClip(AudioClip newClip) {
        isFading = true;
        float startVolume = _audioSource[audioToggle].volume;

        if (fadeDuration > 0f) {
            while (_audioSource[audioToggle].volume > 0) {
                _audioSource[audioToggle].volume -= startVolume * Time.deltaTime/fadeDuration;
                yield return null;
            } 
        } else {
            _audioSource[audioToggle].volume -= startVolume;
        }


        _audioSource[audioToggle].Stop();
        ChangeClip(newClip);
        _audioSource[audioToggle].volume = startVolume;
        PlayMusic();
        isFading = false;
    }*/
}
