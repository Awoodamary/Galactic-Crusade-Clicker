using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeScroll : MonoBehaviour
{
    public RectTransform _rect;



    private void Awake()
    {

        playerManager._US = this;
    }
}
