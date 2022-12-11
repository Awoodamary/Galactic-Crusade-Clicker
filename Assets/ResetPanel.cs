using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResetPanel : MonoBehaviour
{
    public TextMeshProUGUI text;
    
    private void Start()
    {
        transform.localPosition = new Vector3(0,0,-9100);
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        text.text = $"Would you like reset your progress and gain <sprite=1>?";
        text.text += $"\n\nEach <sprite=1> increases all damage by 1%";
        text.text += $"\n\nCurrent <sprite=1> bonus: {playerManager.Reduction_0(playerManager.prestigeCurrent)}%";
        text.text += $"\n<sprite=1> gained after this reset: <sprite=1>{playerManager.Reduction_0(playerManager.prestigePointsInProgress)}";
        text.text += $"\n\n(Hold the button to reset)";

    }
}
