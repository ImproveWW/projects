using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{   //[SerializeField] private Text textOpen;
    //[SerializeField] private ClickerManager ClickerManager;
    [SerializeField] private string saveIndex;
    [SerializeField] private int baseCost;
    [SerializeField] private int clickBonus;
    [SerializeField] private Button currentButton;
    [SerializeField] private Text costText;
    [SerializeField] private Text levelText;
    [SerializeField] private Text _clicksScore;



    private int currentLevelUpgrade;
    private int activeButton = 1;
    private int cost;

    private void CountMoney()
    {

    }

    public event Action Down;

    private int _clicks;

    public int Clicks => _clicks;

    private void OnEnable()
    {
        Down += OnDown;
    }

    private void OnDisable()
    {
        Down -= OnDown;
    }

    private void OnMouseDown()
    {
        Down?.Invoke();
        _clicks++;
    }

    private void OnDown()
    {
        _clicksScore.text = Clicks.ToString();
    }


    public void PandaBuy(int num)
    {
        _clicks -= num;
    }


    private void Start()
    {
        currentLevelUpgrade = 0;
        baseCost = 50;
        cost = baseCost;
    }

    private void Update()
    {
       if (activeButton == 0)
       {
          if (Clicks >= baseCost)
          {
                PlayerPrefs.SetInt("ActiveButton" + saveIndex, 1);
                UpdateText();
          }
       }

        if (Clicks < cost && activeButton == 1)
        {
            {
                currentButton.interactable = false;
            }
        }
        else
        {
            currentButton.interactable = true;
        }
    }

    private void UpdateText()
    {
        if (activeButton == 1)
        {
            currentButton.interactable = false;
        }
        else
        {
            currentButton.interactable = true;
        }
        
        //textOpen.text = baseCost.ToString();
        //currentLevelUpgrade = PlayerPrefs.GetInt("saveIndex" +  saveIndex, currentLevelUpgrade);
        cost = (int)Mathf.Round(baseCost * Mathf.Pow(1.5f, currentLevelUpgrade));


        costText.text = cost.ToString();
        levelText.text = (currentLevelUpgrade).ToString();
    }

    public void BuyClick()
    {
        if (Clicks >= cost)
        {
            currentLevelUpgrade += 1;
            cost = (int)Mathf.Round(baseCost * Mathf.Pow(1.5f, currentLevelUpgrade));
            PlayerPrefs.SetInt("saveIndex" + saveIndex, currentLevelUpgrade);
            PlayerPrefs.SetInt("cost" + saveIndex, cost);
            UpdateText();
        }

        
    }




}

