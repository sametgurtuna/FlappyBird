using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    public static GameManagement instance;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject gameUI;


    private bool isGamePaused = false;

    public AudioSource backgroundMusic;

    public Button soundOnButton;
    public Button soundOffButton;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }


    public void GameOver()
    {
        gameOverUI.SetActive(true);
        gameUI.SetActive(false);
        Time.timeScale = 0;

        //Debug.Log("Game Over");
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Debug.Log("Restart");
    }

    public void Market()
    {
        //Debug.Log("Market");
        SceneManager.LoadScene("Market");
    }

    public void Quit()
    {
        //Debug.Log("Quit");
        Application.Quit();
    }

    public void Play()
    {
        //Debug.Log("Play");
        SceneManager.LoadScene("Game");
    }

    public void MuteBacgkroundMusic()
    {
        if (backgroundMusic.isPlaying)
        {
            backgroundMusic.Stop();
            soundOnButton.gameObject.SetActive(false);
            soundOffButton.gameObject.SetActive(true);
        }
    }
    public void UnMuteBackgroundMusic()
    {
        if (!backgroundMusic.isPlaying)
        {
            backgroundMusic.Play();
            soundOffButton.gameObject.SetActive(false);
            soundOnButton.gameObject.SetActive(true);
        }
    }


    public void TogglePause()
    {
        isGamePaused = !isGamePaused;

        if (isGamePaused)
        {
            Time.timeScale = 0f;
            AudioListener.pause = true;
        }
        else
        {
            Time.timeScale = 1f;
            AudioListener.pause = false;

        }
    }

}
