using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class manualBar : MonoBehaviour
{
    public TextMeshProUGUI text;

    public GameObject barCharge;
    public GameObject barTimer;
    public TextMeshProUGUI textTimer;

    private Vector3 vec3 = new Vector3(0f, 1f, 1f);
    private Vector3 vec3off = new Vector3(0f, 1f, 1f);



    public float timer = 0f;
    public static int currentBuff = -1;
    public int state = 0;
    
    private void Update()
    {

        if(state == 1 && timer > 0f)
        {
            timer -= 1 * Time.deltaTime;
            if(timer <= 0f)
            {
                timer = 0f;
                state = 0;
                currentBuff = -1;
                playerManager.UpdateStatsShip();
            }
            vec3.x = 1f / 10f * timer;
            barTimer.transform.localScale = vec3;
            barCharge.transform.localScale = vec3off;
            textTimer.text = playerManager.Timer00(timer);
        }
        

        

        if (state == 0)
        {
            if (timer <= 0f)
                vec3.x = 0f;
            else if (timer >= 20f)
                vec3.x = 1f;
            else
                vec3.x = 1f / 20f * timer;

            barCharge.transform.localScale = vec3;
            barTimer.transform.localScale = vec3off;
            textTimer.text = $"{playerManager.Reduction_0(100f/20f*timer)}%";
            text.text = $"Random bonus";
        }


    }

    public void ManualBuff()
    {
        state = 1;
        timer = 10f;
        //выдать бафф
        currentBuff = Random.Range(0, 4);
        text.text = allTextManager.manualBuffDesc[currentBuff];

        playerManager.UpdateStatsShip();
    }
}
