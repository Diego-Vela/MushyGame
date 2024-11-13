using System.Collections;
using UnityEngine;

public class AmbientMusicManager : MonoBehaviour
{
    public static AmbientMusicManager instance;  // Singleton instance

    public AudioClip introClip;  // The intro audio clip
    public AudioClip loopClip;   // The loopable audio clip
    private AudioSource audioSource;  // The AudioSource component
    public AudioClip victoryClip; // Reference to the new AudioClip you want to play
    public AudioClip loseClip;

    private Coroutine introCoroutine; // Reference to the running coroutine

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
            introCoroutine = StartCoroutine(PlayLoopAfterIntro(introClip.length));
        }
        else
        {
            Debug.LogError("Intro or Loop clip is missing! Please assign the audio clips.");
        }
    }

    // Method to change the current audio clip
    public void ChangeMusicClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayVictory()
    {
        StopCoroutine(introCoroutine);
        ChangeMusicClip(victoryClip); // Pass the new clip
    }

    // Coroutine to handle transitioning from intro to loop
    IEnumerator PlayLoopAfterIntro(float delay)
    {
        // Wait for the intro to finish
        yield return new WaitForSeconds(delay);

        // Switch to the loopable clip and set it to loop
        ChangeMusicClip(loopClip);
    }

    public void PlayLoss()
    {
        StopCoroutine(introCoroutine);
        ChangeMusicClip(loseClip); // Pass the new clip
    }
}
