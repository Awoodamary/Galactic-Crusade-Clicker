using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class buttonAd : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI text;
    public static bool adSpeedActive;
    public static float adSpeedTimer;
    public float adCD;

    private void Update()
    {      
        if (adSpeedActive == true)
        {
            adSpeedTimer -= 1f * Time.deltaTime;
            if(adSpeedTimer <= 0f)
            {
                adSpeedActive = false;
                playerManager.UpdateStatsShip();
            }
            text.text = $"{playerManager.Timer00(adSpeedTimer)}";
        }
            
        else
            text.text = $"Watch Ad";
    }
    private void OnMouseUpAsButton()
    {
        if (adSpeedActive == false)
        {
            panel.SetActive(true);
        }
        
    }
}
