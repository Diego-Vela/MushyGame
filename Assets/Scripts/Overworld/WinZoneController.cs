using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZoneController : MonoBehaviour
{
    public WinMenuController winMenu; 
    public AmbientMusicManager music;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the collider is the player
        if (other.CompareTag("Player"))
        {
            music.PlayVictory();
            winMenu.winMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}

