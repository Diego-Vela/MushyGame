using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioClipManager : MonoBehaviour
{
    private MusicManager musicManager;
    public AudioClip[] clips;

    void Start()
    {
        musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
        StartCoroutine(SetClips());
    }

    private IEnumerator SetClips() {
        for (int i = 0; i  < clips.Length; i++) {
            if (i == 0) {
                musicManager.ChangeClip(clips[i]);
            } else {
                yield return new WaitForSeconds(1.5f);
                musicManager.ChangeClip(clips[i]);
            }
        }
    }

}
