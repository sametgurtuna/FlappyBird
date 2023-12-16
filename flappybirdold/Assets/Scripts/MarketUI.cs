using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MarketUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textObject;

    private void Start()
    {
        DisplayCoin();
    }

    private void DisplayCoin()
    {
        Score gameScore = Score.instance;

        if (gameScore != null)
        {
            int currentCoin = gameScore.GetCurrentScore();
            textObject.text = currentCoin.ToString();
        }
    }
}
