using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioManager instance;
    public AudioSource level1Music, level2Music, bossMusic, victoryMusic, loseMusic, mainMenuMusic;
    public AudioSource[] audioSFX;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    void Start()
    {
        MainMenuMusic();
    }

    void StopAllMusic()
    {
        level1Music.Stop();
        level2Music.Stop();
        bossMusic.Stop();
        victoryMusic.Stop();
        loseMusic.Stop();
        mainMenuMusic.Stop();
    }
    public void MainMenuMusic()
    {
        StopAllMusic();
        mainMenuMusic.Play();
    }
    public void LevelMusic()
    {
       
        StopAllMusic();
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        if (sceneIndex == 2)//Level 1
        {
            level1Music.volume = 0.7f;
            level1Music.Play();
        } else if(sceneIndex == 3)//Level 2
        {
            level2Music.volume = 0.7f;
            level2Music.Play();
        }
        
    }
    public void BossMusicStart()
    {
        
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (sceneIndex == 2)//Level 1
        {
            level1Music.volume = 1;
        }
        else if (sceneIndex == 3)//Level 2
        {
            level2Music.volume = 1;
        }

    }
    public void BossMusicStop()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (sceneIndex == 2)//Level 1
        {
            level1Music.volume = 0.7f;
        }
        else if (sceneIndex == 3)//Level 2
        {
            level2Music.volume = 0.7f;
        }
    }
    public void VictoryMusic()
    {
        StopAllMusic();
        victoryMusic.Play();
    }
    public void LoseMusic()
    {
        StopAllMusic();
        loseMusic.Play();
    }
    public void PlaySFX(int sfx)
    {
        audioSFX[sfx].Play();
    }
}
