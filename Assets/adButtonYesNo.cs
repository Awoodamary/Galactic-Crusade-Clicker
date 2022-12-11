using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrazyGames;

public class adButtonYesNo : MonoBehaviour
{
    public GameObject adPanel;
    public int number;



    private void OnMouseUpAsButton()
    {
        if (number == 0)
        {
            CrazyAds.Instance.beginAdBreakRewarded(successCallback, errorCallback);
        }
        else
        {
            adPanel.SetActive(false);
        }
    }

    void successCallback()
    {
        Debug.Log("Video completed - Offer a reward to the player");
        buttonAd.adSpeedActive = true;
        buttonAd.adSpeedTimer = 180f;
        playerManager.UpdateStatsShip();
        adPanel.SetActive(false);
    }

    void errorCallback()
    {
        Debug.Log("Video not completed");
        adPanel.SetActive(false);

    }

}
