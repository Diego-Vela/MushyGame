using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioClipManager : MonoBehaviour
{
    private MusicManager musicManager;
    public AudioClip[] audioClips;

    void Start()
    {
        musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
        Debug.Log(musicManager);
        PlayBackgroundClips();
    }
    private void PlayBackgroundClips() {
        for(int i = 0; i < audioClips.Length; i++) {
                musicManager.ChangeClip(audioClips[i]);
        }
    }
}
