using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorCoins : MonoBehaviour
{
    public Canvas mainCanvas;
    public Canvas CoinsEffect;
    public Image inventory;
    
    public Text coinsText;
    public static StorCoins instance;

    int coins = 0;

    #region Instance Awake
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    #endregion
    
    private void Start()
    {
        if(coinsText != null)
            coinsText.text = coins.ToString("0000");

        if (inventory != null)
        {
            inventory.enabled = false;
        }
    }

    private void Update()
    {
        if (IsButtleSceneBool.GetindexxBattleScene())
        {
            mainCanvas.enabled = false;
            CoinsEffect.enabled = false;
        }
        else
        {
            mainCanvas.enabled = true;
        }
        
    }
    
    public void GiveMoneyToPlayer(int amount)
    {
        coins += amount;
        Debug.Log("my store is " + coins);
        DisplayCoins();
    }

    void DisplayCoins()
    {
        coinsText.text = coins.ToString("0000");
    }

    public void OnInventiry()
    {
        inventory.enabled = true;
    }
    
    public void OFFInventiry()
    {
        inventory.enabled = false;
    }
}
