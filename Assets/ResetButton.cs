using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResetButton : MonoBehaviour
{
    public ResetPanel _RP;
    public Button _button;
    private void OnMouseUpAsButton()
    {
        _RP.gameObject.SetActive(true);
    }
}
