using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class Reviving : MonoBehaviour
{
    [SerializeField] private int baseCost = 1000;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI costText;
    

    private const string CostKey = "Cost";
    private int cost;

    public AudioSource cashSound;

    private Fly fly;
    void Start()
    {
        LoadCost();

        UpdateScoreText();

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
        cost = Mathf.RoundToInt(cost * 1.3f); costText.text = cost.ToString();
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
            baseCost = PlayerPrefs.GetInt(CostKey);
            costText.text = baseCost.ToString();
        }
        else
        {
            cost = baseCost;
            SaveCost();
        }
    }

    public void AddHeart()
    {
        if (CanAfford())
        {
            DecreaseCoin();
            UpdateScoreText();
            fly.reviveCount++;
            IncreaseCost();
            cashSound.Play();

        }
        else
        {
            Debug.Log("Yetersiz coin!");
        }
    }
}
