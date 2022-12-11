using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class panelShip : MonoBehaviour
{
    
    public TextMeshProUGUI textStats;
    public TextMeshProUGUI textCost;
    public int number;

    public GameObject fon;

    private bool buttonOnOff = false;

    private void Awake()
    {
        playerManager._panelShip[number] = this;
    }

    void Update()
    {
        textStats.text = $"<#A8A975>{allTextManager.spaceShipName[number]}</color>\n";
        textStats.text += $"Dmg: {playerManager.Reduction_0(playerManager.shipDamage[number])} => <#19D424>{playerManager.Reduction_0(playerManager.shipDamageUp[number])}";
        

        
        if (playerManager.money >= playerManager.costShip[number])
        {
            textCost.text = $"<sprite=0><#C0B01C>{playerManager.Reduction_0(playerManager.costShip[number])}";
            if (buttonOnOff == false)
            {
                fon.SetActive(false);
                buttonOnOff = true;
            }
        }
        else
        {
            textCost.text = $"<sprite=0><#E3160A>{playerManager.Reduction_0(playerManager.costShip[number])}";
            if (buttonOnOff == true)
            {
                fon.SetActive(true);
                buttonOnOff = false;
            }
        }

    }
   



    public void OnMouseUpAsButton()
    {
        if (buttonOnOff == true)
        {


            playerManager.money -= playerManager.costShip[number];
            playerManager.levelShip[number] += playerManager.xBuyShip[number];
            if (number < 9 && playerManager.levelShip[number + 1] == 0)
            {
                playerManager.UpdatePanelShip();
            }
            playerManager.UpdateStatsShip();

            playerManager.SpawnNewShip();
        }
    }
}
