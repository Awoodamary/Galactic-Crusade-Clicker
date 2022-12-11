using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Math = System.Math;

public class panelUpgrade : MonoBehaviour
{
    public int number;
    public GameObject fon;
    public TextMeshProUGUI textDesc;
    public TextMeshProUGUI textValue;
    public TextMeshProUGUI textCost;
    private bool OnOff = true;


    private void Awake()
    {
        playerManager._panelUpgrade[number] = this;
    }
    private void Update()
    {
        textDesc.text = allTextManager.upgradeDesc[number];
        textValue.text = $"{playerManager.upgradeBonus[number]}% => <#19D424>{playerManager.upgradeBonus[number] + playerManager.upgradeBonusPerLevel[number]}%";
        if(number == 2)
            textValue.text = $"{playerManager.Reduction_1((1d - 1d * Math.Pow(0.95d, playerManager.upgradeLevel[2])) * 100d)}% => <#19D424>{playerManager.Reduction_1((1d - 1d * Math.Pow(0.95d, playerManager.upgradeLevel[2] + 1)) * 100d)}%";
        
        if (playerManager.money > playerManager.upgradeCost[number])
        {
            textCost.text = $"<sprite=0>{playerManager.Reduction_0(playerManager.upgradeCost[number])}";
            if (OnOff == true)
            {
                OnOff = false;
                fon.SetActive(false);
            }
                
        }
        else
        {
            textCost.text = $"<sprite=0><#E3160A>{playerManager.Reduction_0(playerManager.upgradeCost[number])}";
            if (OnOff == false)
            {
                OnOff = true;
                fon.SetActive(true);
            }
        }       
    }

    private void OnMouseUpAsButton()
    {
        if (playerManager.money > playerManager.upgradeCost[number])
        {
            playerManager.money -= playerManager.upgradeCost[number];
            playerManager.upgradeLevel[number] += 1;
            playerManager.UpdateStatsShip();
            playerManager.UpdatePanelShip();
        }
    }
}
