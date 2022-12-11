using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetButtonYesNo : MonoBehaviour
{
    public int number;
    public float timer;
    public ResetPanel _RP;
    public GameObject bar;
    private Vector3 barVec3 = new Vector3 (0f,1f,1f); 
    private bool IsPressed = false;


    private void Update()
    {
        if(number == 0) 
        {
            barVec3.x = 1f / 3f * timer;
            bar.transform.localScale = barVec3;
        }      
        if (number == 0 && IsPressed == true)
        {
            timer += 1f * Time.deltaTime;         
            if (timer > 3f)
            {
               
                timer = 0f;
                IsPressed = false;



                playerManager.money = 0;
                playerManager.moneyTotal = 0;

                playerManager.prestigeCurrent += playerManager.prestigePointsInProgress;

                playerManager.levelPlanet = 0;

                playerManager.stageProgress = 0;
                playerManager.progPerProc = 0;

                playerManager.planetD = 1;

                playerManager.levelShip = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };

                playerManager.xBuy = 1;


                playerManager.upgradeLevel = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, };
    













                saveGame.save_gam();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);



                _RP.gameObject.SetActive(false);
            }
        }
    }
    private void OnMouseUpAsButton()
    {
        if (number == 1)
        {
            _RP.gameObject.SetActive(false);
            
        }
    }

    private void OnMouseDown()
    {
        if(number == 0)
        {
            IsPressed = true;
        }      
    }

    private void OnMouseUp()
    {
        timer = 0f;
        if (number == 0)
        {
            IsPressed = false;
        }
    }

    private void OnMouseExit()
    {
        timer = 0f;
        if (number == 0)
        {
            IsPressed = false;
        }
    }
}
