using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MarketManager : MonoBehaviour
{
    [SerializeField] private int baseCost = 50;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI costText;
    public AudioSource cashSound;

    private const string CostKey = "Cost";
    private int cost;

    private void Start()
    {
        LoadCost();

        UpdateScoreText();
    }

    public void OnButtonClick()
    {

        if (CanAfford())
        {
            DecreaseCoin();
            UpdateScoreText();
            Score.instance.PurchaseCoinMultiplier();
            IncreaseCost();
            cashSound.Play();

        }
        else
        {
            Debug.Log("Yetersiz coin!");
        }
    }

    private bool CanAfford()
    {

        return Score.instance.GetCurrentScore() >= cost;
    }

    private void DecreaseCoin()
    {
        Score.instance.DecreaseScore(cost);
    }



    private void UpdateScoreText()
    {
        scoreText.text = Score.instance.GetCurrentScore().ToString();
    }

    private void IncreaseCost()
    {
        cost = Mathf.RoundToInt(cost * 1.2f); costText.text = cost.ToString();
        SaveCost();
    }
    private void SaveCost()
    {
        PlayerPrefs.SetInt(CostKey, cost);
        PlayerPrefs.Save();
    }

    private void LoadCost()
    {
       
        if (PlayerPrefs.HasKey(CostKey))
        {
            cost = PlayerPrefs.GetInt(CostKey);
            costText.text = cost.ToString();
        }
        else
        {
            cost = baseCost; 
            SaveCost();
        }
    }
}