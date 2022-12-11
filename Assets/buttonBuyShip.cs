using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonBuyShip : MonoBehaviour
{
    public int number;

    public Button _button;
    public GameObject _text;

    private bool buttonOnOff = true;
    private Vector3 posCur;

    private Vector3 textUp;
    private Vector3 textDown;

    private void Start()
    {
        textUp = _text.transform.localPosition;
        textDown = _text.transform.localPosition;
        textDown.y -= 2;
    }

    private void Update()
    {
        if (playerManager.money >= playerManager.costShip[number])
        {
            if (buttonOnOff == false)
            {
                _button.interactable = true;
                buttonOnOff = true;
            }
        }
        else
        {
            if (buttonOnOff == true)
            {
                _button.interactable = false;
                buttonOnOff = false;
            }
        }
    }


    private void OnMouseDown()
    {
        if (buttonOnOff == true)
            _text.transform.localPosition = textDown;
    }
    private void OnMouseUp()
    {
        _text.transform.localPosition = textUp;
    }



    private void OnMouseEnter()
    {
        posCur = transform.position;
        posCur.x += 2f;
        posCur.y += 1f;
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

            if (playerManager.levelShip[number] == 1)
            {
                playerManager.SpawnNewShip();
            }
        }
    }
}
