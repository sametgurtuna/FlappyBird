using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DurationBoost : MonoBehaviour
{
    [SerializeField] private int baseCost = 500;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private GameObject ClockImage;
    [SerializeField] private GameObject BuyedClock;
    private ShieldPowerUp shieldPowerUp;

    public AudioSource cashSound;

    private bool isBuyed = false;

    private const string IsBuyedKey = "IsDurationBoostBuyed";

    private void Start()
    {
        isBuyed = PlayerPrefs.GetInt(IsBuyedKey, 0) == 1;
        if (isBuyed)
        {
            ClockImage.SetActive(false);
            BuyedClock.SetActive(true);
            shieldPowerUp = FindObjectOfType<ShieldPowerUp>();

        }

        UpdateScoreText();
    }
    private bool CanAfford()
    {

        return Score.instance.GetCurrentScore() >= baseCost;
    }
    private void DecreaseCoin()
    {
        Score.instance.DecreaseScore(baseCost);
    }
    private void UpdateScoreText()
    {
        scoreText.text = Score.instance.GetCurrentScore().ToString();
    }

    public void BuyDurationPowerUp()
    {
        if (CanAfford() && isBuyed == false)
        {
            DecreaseCoin();
            UpdateScoreText();
            cashSound.Play();
            isBuyed = true;
            ClockImage.SetActive(false);
            BuyedClock.SetActive(true);

            shieldPowerUp = FindObjectOfType<ShieldPowerUp>();
            if (shieldPowerUp != null)
            {
                shieldPowerUp.SetShieldDuration(12f);
            }

            PlayerPrefs.SetInt(IsBuyedKey, 1);
            PlayerPrefs.Save();
        }
        else if (isBuyed == true)
        {
            Debug.Log("Zaten satýn alýndý!");
        }
        else
        {
            Debug.Log("Yetersiz coin!");
        }

    }
}