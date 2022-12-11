using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipUpgradeScroll : MonoBehaviour
{

    public RectTransform _rect;
    
    
    
    private void Awake()
    {
        
        playerManager._SUS = this;
    }
}
