using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonMnoj : MonoBehaviour
{
    public int number;



    public Button _button;
    private bool onOff = true;


    void Update()
    {
        if (playerManager.xBuy == number)
        {
            if (onOff == false)
            {
                _button.interactable = true;
                onOff = true;
            }
        }
        else
        {
            if (onOff == true)
            {
                _button.interactable = false;
                onOff = false;
            }
        }
    }





    private void OnMouseDown()
    {
        if (playerManager.xBuy != number)
        {
            playerManager.xBuy = number;
            playerManager.UpdateStatsShip();
            
        }
    }
}
