using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour
{
    public PlayerController playerController;
    public TMP_Text livesText;
    public TMP_Text coinsText;

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + playerController.lives;
        coinsText.text = "Coins: " + playerController.totalCoins;
    }
}
