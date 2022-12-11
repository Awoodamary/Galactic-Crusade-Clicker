using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allTextManager : MonoBehaviour
{
    public static string[] spaceShipName = new string[] {"Clicker MK1", "Kestrel", "Artillery", "Laseroid", "Gophel", "Swarmer", "Ayatan", "Osmian", "Lanius", "Ionoid", }; 
    public static string[] upgradeDesc = new string[] { "Increases all damage",
        "More money per block",
        "Decreases ship upgrade costs",
        "Bullet attack speed",
        "Rocket attack speed",
        "Laser attack speed",
        "Crit chance",
        "Crit damage", };

    //50% 50% 50% 20%
    public static string[] manualBuffDesc = new string[] {"+ money gained", "+ damage","+ attack speed", "+ crit chance" };

}
