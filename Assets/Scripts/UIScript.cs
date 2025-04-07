using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour
{
    public PlayerController playerController;
    public TMP_Text healthText;
    public TMP_Text coinsText;

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + playerController.Health;
        coinsText.text = "Coins: " + playerController.totalCoins;
    }
}
