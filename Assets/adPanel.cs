using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adPanel : MonoBehaviour
{
    private void Awake()
    {
        transform.localPosition = new Vector3(0f,0f,-9100f);
        gameObject.SetActive(false);
    }
}
