using System.Collections;
using UnityEngine;

public class AmbientMusicManager : MonoBehaviour
{
    public static AmbientMusicManager instance;  // Singleton instance

    public AudioClip introClip;  // The intro audio clip
    public AudioClip loopClip;   // The loopable audio clip
    private AudioSource audioSource;  // The AudioSource component

    private void Awake()
    {

        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Start playing the intro
        PlayIntroAndLoop();
    }

    // Play the intro clip, then transition to the loopable clip
    void PlayIntroAndLoop()
    {
        if (introClip != null && loopClip != null)
        {
            // Play the intro clip
            audioSource.clip = introClip;
            audioSource.Play();

            // Schedule the loop clip to play after the intro finishes
            StartCoroutine(PlayLoopAfterIntro(introClip.length));
        }
        else
        {
            Debug.LogError("Intro or Loop clip is missing! Please assign the audio clips.");
        }
    }

    // Coroutine to handle transitioning from intro to loop
    IEnumerator PlayLoopAfterIntro(float delay)
    {
        // Wait for the intro to finish
        yield return new WaitForSeconds(delay);

        // Switch to the loopable clip and set it to loop
        audioSource.clip = loopClip;
        audioSource.loop = true;
        audioSource.Play();
    }
}
