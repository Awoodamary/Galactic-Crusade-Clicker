using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class saveGame : MonoBehaviour
{

    private static Save sv = new Save();

    public static int save_on = 0;
    public static int load_on = 0;


    public static float save_time = 0f;
    public static float save_time_online = 0f;
    public static float load_time_online = 10f;


    //import export
    public static int amount_export_save = 0;
    public static string export_text = "";

    public static string save_string = "";


    private static int prov_amount;
    private static string[] all_slot = new string[5000];
    public static string import_string = "";


    //год мес€ц день час минута секунда
    public static int[] data_off = new int[] { 0, 0, 0, 0, 0, 0 };
    public static int[] data_off2 = new int[] { 0, 0, 0, 0, 0, 0 };
    public static int[] data_on = new int[] { 0, 0, 0, 0, 0, 0 };

    public static int[] mountD = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

    public static int prosh_sec;
    public static int cur_sec;
    public static int mount_day;
    public static int mount_dayC;
    public static int sec_in_off;



    public static int on_off_save = 0;

    public static int import_compl = 0;






    void Awake()
    {
        if (save_on == 0)
        {
            if (PlayerPrefs.HasKey("PlanetDestroy"))
            {
                sv = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("PlanetDestroy"));

                load_gam();
            }
        }
    }




    private void Update()
    {
        save_time += 1f * Time.deltaTime;

        if (save_time >= 1)
        {
            save_time = 0f;


            save_gam();

        }

        save_time_online += 1f * Time.deltaTime;
        load_time_online += 1f * Time.deltaTime;





    }




    public static void save_gam()
    {
        //Debug.Log("Save game");


        sv.money = playerManager.money;

        sv.moneyTotal = playerManager.moneyTotal;

        sv.prestigeCurrent = playerManager.prestigeCurrent;

        sv.levelPlanet = playerManager.levelPlanet;

        for(int i = 0; i < 1264; i++)
        {
            sv.fragmentHp[i] = playerManager.fragmentHp[i];
        }
    
        sv.fragentAmount = playerManager.fragentAmount;
        sv.stageProgress = playerManager.stageProgress;
        sv.progPerProc = playerManager.progPerProc;

        for (int i = 0; i < 10; i++)
        {
            sv.levelShip[i] = playerManager.levelShip[i];
        }
        for (int i = 0; i < 8; i++)
        {
            sv.upgradeLevel[i] = playerManager.upgradeLevel[i];
        }
        sv.planetD = playerManager.planetD;

        
        sv.learnOn = playerManager.learnOn;
        sv.musicOnOff = playerManager.musicOnOff;




        PlayerPrefs.SetString("PlanetDestroy", JsonUtility.ToJson(sv));

    }

    public static void load_gam()
    {
        Debug.Log("Load game");

        save_on = 1;

        playerManager.money = sv.money;

        playerManager.moneyTotal = sv.moneyTotal;

        playerManager.prestigeCurrent = sv.prestigeCurrent;

        playerManager.levelPlanet = sv.levelPlanet;

        for (int i = 0; i < 1264; i++)
        {
            playerManager.fragmentHp[i] = sv.fragmentHp[i];
        }

        playerManager.fragentAmount = sv.fragentAmount;
        playerManager.stageProgress = sv.stageProgress;
        playerManager.progPerProc = sv.progPerProc;

        for (int i = 0; i < 10; i++)
        {
            playerManager.levelShip[i] = sv.levelShip[i];
        }
        for (int i = 0; i < 8; i++)
        {
            playerManager.upgradeLevel[i] = sv.upgradeLevel[i];
        }
        playerManager.planetD = sv.planetD;

        
        playerManager.learnOn = sv.learnOn;
        playerManager.musicOnOff = sv.musicOnOff;

        if (sv.moneyTotal > 0f)
        {
            load_on = 1;
        }

    }













    [Serializable]
    public class Save
    {

        public double money = 0;

        public double moneyTotal;

        public double prestigeCurrent = 0d;

        public int levelPlanet = 0;

        public double[] fragmentHp = new double[1264];
        public int fragentAmount = 1138;
        public float stageProgress = 0;
        public int progPerProc = 0;


        public int[] levelShip = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };

        public int[] upgradeLevel = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, };

        public int planetD = 0;

        public int learnOn = 0;
        public int musicOnOff = 0;

    }


}
