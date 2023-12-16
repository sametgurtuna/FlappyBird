using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinTxt;

    private int currentCoin = 0;

    public static Score instance;

    private int coinMultiplier = 1;

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

    private void Start()
    {
        LoadGameData();
        UpdateCoinText();
    }

    public void AddScore()
    {
        currentCoin += coinMultiplier;
        SaveGameData();

        UpdateCoinText();
    }

    public int GetCurrentScore()
    {
        return currentCoin;
    }

    private void LoadGameData()
    {
        if (PlayerPrefs.HasKey("Coin"))
        {
            currentCoin = PlayerPrefs.GetInt("Coin");
        }

        if (PlayerPrefs.HasKey("Multiplier"))
        {
            coinMultiplier = PlayerPrefs.GetInt("Multiplier");
        }
    }

    private void SaveGameData()
    {
        PlayerPrefs.SetInt("Coin", currentCoin);
        PlayerPrefs.SetInt("Multiplier", coinMultiplier);
        PlayerPrefs.Save();
    }

    private void SaveCoin()
    {
        PlayerPrefs.SetInt("Coin", currentCoin);
        PlayerPrefs.Save();
    }

    private void LoadCoin()
    {
        if (PlayerPrefs.HasKey("Coin"))
        {
            currentCoin = PlayerPrefs.GetInt("Coin");
        }
    }

    private void UpdateCoinText()
    {
        coinTxt.text = GetCurrentScore().ToString();
    }

    public void DecreaseScore(int amount)
    {
        currentCoin -= amount;
        SaveCoin();
        UpdateCoinText();
    }



    public void  PurchaseCoinMultiplier()
    {
        coinMultiplier++;
    }
}
