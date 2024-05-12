using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource levelMusic;
    public AudioSource GameOverMusic;
    
    public bool levelSong = true;
    public bool GameOverSong = false;

   
    public void LevelMusic()
    {
        levelSong = true;
        GameOverSong = false;
        levelMusic.Play();
    }

    public void GameOverSound()
    {
        if (levelMusic.isPlaying)
            levelSong = false;
        {
            levelMusic.Stop();
        }

        if(!GameOverMusic.isPlaying&& GameOverSong == false)
        {
            GameOverMusic.Play();
            GameOverSong = true;
        }
    }
}
