using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class moneyPanel : MonoBehaviour
{
    public TextMeshProUGUI money;
    public TextMeshProUGUI stageProgress;
    public TextMeshProUGUI prestige;

    private string[] colorProg = new string[] { "<#5FFF00>", "<#F5FF00>", "<#FFC100>", "<#FF5800>", "<#FF0300>", "<#FF0300>", };

    void Update()
    {
        prestige.text = $"<sprite=1>{playerManager.Reduction_0(playerManager.prestigeCurrent)}";
        money.text = $"<sprite=0>{playerManager.Reduction_0(playerManager.money)}";


        if(playerManager.planetD == 0)
            stageProgress.text = $"Destrution progress: {colorProg[playerManager.progPerProc]}{playerManager.Reduction_1(playerManager.stageProgress)}%";
        else
            stageProgress.text = $"Destrution progress: {colorProg[playerManager.progPerProc]}100%";
    }
}
