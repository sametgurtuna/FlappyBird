using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public bool gameStarted = false;
    [SerializeField] private GameObject gameStartUI;
    [SerializeField] private GameObject gameUI;


    void Start()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && !gameStarted)
        {
            StartGame();
        }
    }

    void StartGame()
    {
        Time.timeScale = 1;
        gameStartUI.SetActive(false);
        gameUI.SetActive(true);
        gameStarted = true;
    }


}
