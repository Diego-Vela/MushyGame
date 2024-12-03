using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public double musicDuration;
    public double goalTime;
    public AudioSource[] _audioSource; // Ensure two audio sources are assigned in the Inspector
    public int audioToggle = 0;
    public AudioClip clip;
    public AudioClip loseClip;
    private VolumeControl volumeControl;

    private void Start() {
        volumeControl = GameObject.FindGameObjectWithTag("VolumeControl")?.GetComponent<VolumeControl>();
        goalTime = AudioSettings.dspTime;
        SetVolume();
    }


    private void Update() {
        if (clip != null && AudioSettings.dspTime >= goalTime - 1) {
            PlayScheduledClip();
        }
    }

    private void PlayScheduledClip() {
        _audioSource[audioToggle].clip = this.clip;
        _audioSource[audioToggle].PlayScheduled(goalTime);

        musicDuration = (double)clip.samples / clip.frequency;
        goalTime += musicDuration;

        audioToggle = 1 - audioToggle;
    }

    private void SetVolume()
    {
        foreach (AudioSource music in _audioSource)
        {
            music.volume = volumeControl.volume;
        }
    }

    public void ChangeClip(AudioClip newClip) {
        this.clip = newClip;
    } 

public void PlayLoss()
{
    foreach (AudioSource music in _audioSource) {
        music.Stop();
    }
    ChangeClip(loseClip);
    goalTime = AudioSettings.dspTime;
    _audioSource[audioToggle].Play();
}
}
