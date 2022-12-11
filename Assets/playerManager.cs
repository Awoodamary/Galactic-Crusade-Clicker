using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Math = System.Math;

public class playerManager : MonoBehaviour
{

    public static double money = 10000000000000000000000d;
    public static double moneyPerBlock = 1;
    public static double moneyTotal;

    public static double prestigeCurrent = 0d;
    public static double prestigePointsInProgress = 0d;

    public static int levelPlanet = 0;

    public static double[] fragmentHp = new double[1264];
    public static int[] fragmentHpProp = new int[1264];
    public static int fragentAmount = 1138;
    public static float stageProgress;
    public static int progPerProc = 0;

    public static int planetD = 0;
    

    public static int[] levelShip = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };

    public static double[] costShip = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };
    public static double[] costStartShip = new double[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, };
    public static double[] costPerLevelShip = new double[] { 1.1d, 1.1d, 1.1d, 1.1d, 1.1d, 1.1d, 1.1d, 1.1d, 1.1d, 1.1d, };
    public static int[] xBuyShip = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, };
    public static int xBuy = 1;


    public static double[] shipDamage = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, };
    public static double[] shipDamageUp = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, };
    public static double[] shipStarDamage = new double[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, };
    public static double[] shipDamagePerLevel = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, };
    public static float[] shipSpeed = new float[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, };
    public static float[] shipSpeedStart = new float[] { 1, 1, 0.5f, 2, 1, 0.5f, 2, 1, 0.4f, 2, };
    public static float[] shipCrit = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };
    public static float[] shipCritPow = new float[] { 150, 150, 150, 150, 150, 150, 150, 150, 150, 150, };

    public static int[] upgradeLevel = new int[] { 0, 0, 0, 0, 0, 0, 0, 0,};
    public static double[] upgradeCost = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, };
    public static double[] upgradeCostPerLevel = new double[] { 2.5d, 2.5d, 2.5d, 2.5d, 2.5d, 2.5d, 2.5d, 2.5d, };
    public static double[] upgradeCostStart = new double[] { 100, 100, 100, 100, 100, 100, 100, 100, };
    public static double[] upgradeBonus = new double[] { 25, 10, 5, 10, 10, 10, 1, 5, };
    public static double[] upgradeBonusPerLevel = new double[] { 25, 10, 5, 10, 10, 10, 1, 5, };


    public static int learnOn = 0;
    public static int musicOnOff = 0;


    public static panelShip[] _panelShip = new panelShip[10];
    public static panelUpgrade[] _panelUpgrade = new panelUpgrade[8];
    public static GameObject[] _ship = new GameObject[10];
    public static shipUpgradeScroll _SUS;
    public static upgradeScroll _US;

    public planetManager _pm;
    public shipClick _sc;
    public ship1 _s1;
    public ship2 _s2;
    public ship3 _s3;
    public ship3 _s6;
    public ship3 _s9;
    public ship4 _s4;
    public ship5 _s5;
    public ship7 _s7;
    public ship8 _s8;


    private void Start()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        UpdateStatsShip();
        UpdatePanelShip();
        SpawnNewShip();
    }


    private void Update()
    {
        // ïðåñòèæ
        prestigePointsInProgress = Math.Floor(Math.Pow(moneyTotal / 100000d, 1d / 1.01d));

        // ïðîãðåññ óðîâíÿ
        stageProgress = 100f / 1138f * (1138f - fragentAmount);
        //îáíîâëåíèå õï ïðè ïðîöåíòàõ õï
        if(stageProgress >= progPerProc * 20 + 20)
        {
            progPerProc += 1;
        }

        if(fragentAmount <= 0)
        {
            fragentAmount = 1138;
            levelPlanet += 1;
            planetD = 1;
            _pm.PlanetDestruction();
            Invoke("resetPlanet", 4f);          
        }
     

    }

    public void resetPlanet()
    {
        planetD = 0;

        UpdateHpFragmentStart();

        _sc.DeleteAllBullet();
        _s1.DeleteAllBullet();
        _s2.DeleteAllBullet();
        _s3.DeleteAllBullet();
        _s4.DeleteAllBullet();
        _s5.DeleteAllBullet();
        _s6.DeleteAllBullet();
        _s7.DeleteAllBullet();
        _s8.DeleteAllBullet();
        _s9.DeleteAllBullet();
        _pm.CreateNewPlanet();
    }


    public static void UpdateStatsShip()
    {
        for (int i = 0; i < 8; i++)
        {
            upgradeCost[i] = upgradeCostStart[i] * Math.Pow(upgradeCostPerLevel[i], upgradeLevel[i]);
            upgradeBonus[i] = upgradeBonusPerLevel[i] * upgradeLevel[i];
            if (i == 7)
                upgradeBonus[i] += 150;
        }
        
        for(int i = 0; i < 10; i++)
        {
            //îïðåäåëåíèå õ ïîêóïêè
            xBuyShip[i] = xBuy;

            //öåíà
            costShip[i] = costStartShip[i] * Math.Pow(costPerLevelShip[i], levelShip[i]);
            costShip[i] = (Math.Pow(costPerLevelShip[i], xBuyShip[i]) - 1d) / (costPerLevelShip[i] - 1d) * costShip[i];
            if (upgradeLevel[2] > 0)
                costShip[i] *= 1d * Math.Pow(0.95d, upgradeLevel[2]);
            

            //óðîí
            shipDamage[i] = shipStarDamage[i];
            shipDamage[i] += shipDamagePerLevel[i] * levelShip[i];

            shipDamageUp[i] = shipStarDamage[i];
            shipDamageUp[i] += shipDamagePerLevel[i] * (levelShip[i] + 1);
            //àïãðåéä
            if(upgradeLevel[0] > 0)
            {
                shipDamage[i] *= upgradeBonus[0] / 100d + 1;
                shipDamageUp[i] *= upgradeBonus[0] / 100d + 1;
            }
            if (manualBar.currentBuff == 1)
            {
                shipDamage[i] *= 1.5d;
                shipDamageUp[i] *= 1.5d;
            }
            //престиж
            if(prestigeCurrent > 0)
            {
                shipDamage[i] *= prestigeCurrent / 100d + 1d;
                shipDamageUp[i] *= prestigeCurrent / 100d + 1d;
            }
            //ad
            if(buttonAd.adSpeedActive == true)
            {
                shipDamage[i] *= 1.5d;
                shipDamageUp[i] *= 1.5d;
            }

            //скорость
            shipSpeed[i] = shipSpeedStart[i];
            if (upgradeLevel[3] > 0 && (i == 1 || i == 4 || i == 7 || i == 8))
            {
                shipSpeed[i] *= (float)upgradeBonus[3] / 100f + 1;
            }
            if (upgradeLevel[4] > 0 && (i == 2 || i == 5))
            {
                shipSpeed[i] *= (float)upgradeBonus[4] / 100f + 1;
            }
            if (upgradeLevel[5] > 0 && (i == 3 || i == 6 || i == 9))
            {
                shipSpeed[i] *= (float)upgradeBonus[5] / 100f + 1;
            }
            if (manualBar.currentBuff == 2)
            {
                shipSpeed[i] *= 1.5f;
            }

            //крит
            shipCrit[i] = 0;
            shipCrit[i] += (float)upgradeBonus[6];
            if (manualBar.currentBuff == 3)
            {
                shipCrit[i] += 20;
            }

            //крит множет
            shipCritPow[i] = 0;
            shipCritPow[i] += (float)upgradeBonus[7];





        }



        UpdateMoneyPerBlock();
    }


    public static void UpdatePanelShip()
    {
        int scrollSize = 1;
        Vector2 vec2 =  new Vector2 (240, 0);
        
        //ships
        for (int i = 1; i < 10; i++)
        {
            _panelShip[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < 10; i++)
        {
            if(levelShip[i] > 0)
            {
                if(i < 9)
                {
                    _panelShip[i + 1].gameObject.SetActive(true);
                    scrollSize += 1;
                }             
                
            }
        }
        vec2.y = scrollSize * 79 + 6;
        _SUS._rect.sizeDelta = vec2;
        scrollSize = 1;

        //upgrades
        for (int i = 1; i < 8; i++)
        {
            _panelUpgrade[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < 8; i++)
        {
            if (upgradeLevel[i] > 0)
            {
                if (i < 7)
                {
                    _panelUpgrade[i + 1].gameObject.SetActive(true);
                    scrollSize += 1;
                }
                
            }
        }
        vec2.y = scrollSize * 95 + 6;
        _US._rect.sizeDelta = vec2;
    }

    public static void SpawnNewShip()
    {
        for (int i = 0; i < 10; i++)
        {
            if (levelShip[i] > 0)
            {
                if (i > 0)
                {
                    _ship[i].SetActive(true);
                }
            }
        }
    }

    public static void UpdateHpFragmentStart()
    {
        progPerProc = 0;
        for (int i = 0; i < 1264; i++)
        {
            fragmentHp[i] = (1 + (5 * levelPlanet)) * Math.Pow(3d, levelPlanet);
            fragmentHp[i] *= fragmentHpProp[i];
        }
        
        UpdateMoneyPerBlock();
    }
    public static void UpdateMoneyPerBlock()
    {
        moneyPerBlock = 1 * Math.Pow(2.5d, levelPlanet);
        if (upgradeLevel[1] > 0)
            moneyPerBlock *= upgradeBonus[1] / 100d + 1;
        if (manualBar.currentBuff == 0)
            moneyPerBlock *= 1.5d;
    }


    //âðåìåííîå ñîêðàùåíèå
    #region
    public static string Timer00(float timer)
    {
        string ret = "";
        float min = Mathf.Floor(timer / 60f);
        float sec = Mathf.Round(timer - min * 60f);


        if (min < 10f)
            ret += "0";
        ret += min + ":";
        if (sec < 10f)
            ret += "0";
        ret += sec;

        return (ret);
    }
    #endregion

    //ñîêðàùåíèå ÷èñåë
    #region
    public static int notation = 0;

    //Reduction 0
    private static string[] sokr = new string[] { "K", "M", "B", "T", "aa", "ab", "ac", "ad", "ae", "af", "ag", "ah", "ai", "aj", "ak", "al", "am", "an", "ao", "ap", "aq", "ar", "as", "at", "au", "av", "aw", "ax", "ay", "az", "ba", "bb", "bc", "bd", "be", "bf", "bg", "bh", "bi", "bj", "bk", "bl", "bm", "bn", "bo", "bp", "bq", "br", "bs", "bt", "bu", "bv", "bw", "bx", "by", "bz", "ca", "cb", "cc", "cd", "ce", "cf", "cg", "ch", "ci", "cj", "ck", "cl", "cm", "cn", "co", "cp", "cq", "cr", "cs", "ct", "cu", "cv", "cw", "cx", "cy", "cz", "da", "db", "dc", "dd", "de", "df", "dg", "dh", "di", "dj", "dk", "dl", "dm", "dn", "do", "dp", "dq", "dr", "ds", "dt" };
    public static string Reduction_0(double costs)
    {
        string ret = "Over";

        //alf
        if (notation == 0)
        {
            if (costs < 1000)
            {
                ret = costs.ToString("n0");
            }
            else
            {

                //ret = costs.tostring("g3"); 1.000e6 = 1 000 000
                double prov = 1000;
                int prov_n = 0;
                for (int i = 0; costs >= prov; i++)
                {
                    prov *= 1000;
                    prov_n = i;
                }
                ret = ((Math.Floor(costs / (prov / 1000000d))) / 1000).ToString("N1") + (sokr[prov_n]);
                //ret = ((Math.Floor(costs / (prov / 10000d))) / 1000).ToString("N3") + " e" + (prov_n + 6);
                //ret = (math.floor(costs / (prov / 10000d)) / 1000d).tostring(".00") + "e" + (prov_n + 6);
            }
        }

        //scientific
        if (notation == 1)
        {
            if (costs < 1000000)
            {
                ret = costs.ToString("n0");
            }
            else
            {

                //ret = costs.tostring("g3"); 1.000e6 = 1 000 000
                double prov = 1000000;
                int prov_n = 0;
                for (int i = 0; costs >= prov; i++)
                {
                    prov *= 10;
                    prov_n = i;
                }
                //ret = Math.Floor();
                ret = ((Math.Floor(costs / (prov / 10000d))) / 1000).ToString("N3") + "e" + (prov_n + 6);
                //ret = ((Math.Floor(costs / (prov / 10000d))) / 1000).ToString("N3") + " e" + (prov_n + 6);
                //ret = (math.floor(costs / (prov / 10000d)) / 1000d).tostring(".00") + "e" + (prov_n + 6);
            }
        }
        //scientific
        if (notation == 2)
        {
            if (costs < 1000000)
            {
                ret = costs.ToString("n0");
            }
            else
            {

                //ret = costs.tostring("g3"); 1.000e6 = 1 000 000
                double prov = 1000000;
                int prov_n = 0;
                int prov_eng = -1;
                for (int i = 0; costs >= prov; i++)
                {
                    prov *= 1000;
                    prov_n = i;
                }
                //for eng
                double prov2 = 1000000;
                for (int i = 0; costs >= prov2; i++)
                {
                    prov2 *= 10;
                    prov_eng += 1;
                    if (prov_eng > 2)
                        prov_eng = 0;
                }

                if (prov_eng == 0)
                    ret = ((Math.Floor(costs / (prov / 1000000d))) / 1000).ToString("N3") + "e" + (prov_n * 3 + 6);
                if (prov_eng == 1)
                    ret = ((Math.Floor(costs / (prov / 1000000d))) / 1000).ToString("N2") + "e" + (prov_n * 3 + 6);
                if (prov_eng == 2)
                    ret = ((Math.Floor(costs / (prov / 1000000d))) / 1000).ToString("N1") + "e" + (prov_n * 3 + 6);
                //ret = ((Math.Floor(costs / (prov / 10000d))) / 1000).ToString("N3") + " e" + (prov_n + 6);
                //ret = (math.floor(costs / (prov / 10000d)) / 1000d).tostring(".00") + "e" + (prov_n + 6);
            }
        }






        return (ret);
    }
    public static string Reduction_1(double costs)
    {
        string ret = "Over";

        //alf
        if (notation == 0)
        {
            if (costs < 1000)
            {
                ret = costs.ToString("n1");
            }
            else
            {

                //ret = costs.tostring("g3"); 1.000e6 = 1 000 000
                double prov = 1000;
                int prov_n = 0;
                for (int i = 0; costs >= prov; i++)
                {
                    prov *= 1000;
                    prov_n = i;
                }
                ret = ((Math.Floor(costs / (prov / 1000000d))) / 1000).ToString("N2") + (sokr[prov_n]);
                //ret = ((Math.Floor(costs / (prov / 10000d))) / 1000).ToString("N3") + " e" + (prov_n + 6);
                //ret = (math.floor(costs / (prov / 10000d)) / 1000d).tostring(".00") + "e" + (prov_n + 6);
            }
        }

        //scientific
        if (notation == 1)
        {
            if (costs < 1000000)
            {
                ret = costs.ToString("n0");
            }
            else
            {

                //ret = costs.tostring("g3"); 1.000e6 = 1 000 000
                double prov = 1000000;
                int prov_n = 0;
                for (int i = 0; costs >= prov; i++)
                {
                    prov *= 10;
                    prov_n = i;
                }
                //ret = Math.Floor();
                ret = ((Math.Floor(costs / (prov / 10000d))) / 1000).ToString("N3") + "e" + (prov_n + 6);
                //ret = ((Math.Floor(costs / (prov / 10000d))) / 1000).ToString("N3") + " e" + (prov_n + 6);
                //ret = (math.floor(costs / (prov / 10000d)) / 1000d).tostring(".00") + "e" + (prov_n + 6);
            }
        }
        //scientific
        if (notation == 2)
        {
            if (costs < 1000000)
            {
                ret = costs.ToString("n0");
            }
            else
            {

                //ret = costs.tostring("g3"); 1.000e6 = 1 000 000
                double prov = 1000000;
                int prov_n = 0;
                int prov_eng = -1;
                for (int i = 0; costs >= prov; i++)
                {
                    prov *= 1000;
                    prov_n = i;
                }
                //for eng
                double prov2 = 1000000;
                for (int i = 0; costs >= prov2; i++)
                {
                    prov2 *= 10;
                    prov_eng += 1;
                    if (prov_eng > 2)
                        prov_eng = 0;
                }

                if (prov_eng == 0)
                    ret = ((Math.Floor(costs / (prov / 1000000d))) / 1000).ToString("N3") + "e" + (prov_n * 3 + 6);
                if (prov_eng == 1)
                    ret = ((Math.Floor(costs / (prov / 1000000d))) / 1000).ToString("N2") + "e" + (prov_n * 3 + 6);
                if (prov_eng == 2)
                    ret = ((Math.Floor(costs / (prov / 1000000d))) / 1000).ToString("N1") + "e" + (prov_n * 3 + 6);
                //ret = ((Math.Floor(costs / (prov / 10000d))) / 1000).ToString("N3") + " e" + (prov_n + 6);
                //ret = (math.floor(costs / (prov / 10000d)) / 1000d).tostring(".00") + "e" + (prov_n + 6);
            }
        }






        return (ret);
    }
    public static string Reduction_2(double costs)
    {
        string ret = "Over";

        //alf
        if (notation == 0)
        {
            if (costs < 1000)
            {
                ret = costs.ToString("n2");
            }
            else
            {

                //ret = costs.tostring("g3"); 1.000e6 = 1 000 000
                double prov = 1000;
                int prov_n = 0;
                for (int i = 0; costs >= prov; i++)
                {
                    prov *= 1000;
                    prov_n = i;
                }
                ret = ((Math.Floor(costs / (prov / 1000000d))) / 1000).ToString("N2") + (sokr[prov_n]);
                //ret = ((Math.Floor(costs / (prov / 10000d))) / 1000).ToString("N3") + " e" + (prov_n + 6);
                //ret = (math.floor(costs / (prov / 10000d)) / 1000d).tostring(".00") + "e" + (prov_n + 6);
            }
        }

        //scientific
        if (notation == 1)
        {
            if (costs < 1000000)
            {
                ret = costs.ToString("n0");
            }
            else
            {

                //ret = costs.tostring("g3"); 1.000e6 = 1 000 000
                double prov = 1000000;
                int prov_n = 0;
                for (int i = 0; costs >= prov; i++)
                {
                    prov *= 10;
                    prov_n = i;
                }
                //ret = Math.Floor();
                ret = ((Math.Floor(costs / (prov / 10000d))) / 1000).ToString("N3") + "e" + (prov_n + 6);
                //ret = ((Math.Floor(costs / (prov / 10000d))) / 1000).ToString("N3") + " e" + (prov_n + 6);
                //ret = (math.floor(costs / (prov / 10000d)) / 1000d).tostring(".00") + "e" + (prov_n + 6);
            }
        }
        //scientific
        if (notation == 2)
        {
            if (costs < 1000000)
            {
                ret = costs.ToString("n0");
            }
            else
            {

                //ret = costs.tostring("g3"); 1.000e6 = 1 000 000
                double prov = 1000000;
                int prov_n = 0;
                int prov_eng = -1;
                for (int i = 0; costs >= prov; i++)
                {
                    prov *= 1000;
                    prov_n = i;
                }
                //for eng
                double prov2 = 1000000;
                for (int i = 0; costs >= prov2; i++)
                {
                    prov2 *= 10;
                    prov_eng += 1;
                    if (prov_eng > 2)
                        prov_eng = 0;
                }

                if (prov_eng == 0)
                    ret = ((Math.Floor(costs / (prov / 1000000d))) / 1000).ToString("N3") + "e" + (prov_n * 3 + 6);
                if (prov_eng == 1)
                    ret = ((Math.Floor(costs / (prov / 1000000d))) / 1000).ToString("N2") + "e" + (prov_n * 3 + 6);
                if (prov_eng == 2)
                    ret = ((Math.Floor(costs / (prov / 1000000d))) / 1000).ToString("N1") + "e" + (prov_n * 3 + 6);
                //ret = ((Math.Floor(costs / (prov / 10000d))) / 1000).ToString("N3") + " e" + (prov_n + 6);
                //ret = (math.floor(costs / (prov / 10000d)) / 1000d).tostring(".00") + "e" + (prov_n + 6);
            }
        }






        return (ret);
    }
    #endregion





}
