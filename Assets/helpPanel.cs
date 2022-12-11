using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class helpPanel : MonoBehaviour
{
    private int page = 0;
    public GameObject textPage1;
    public GameObject textPage2;

    private void Awake()
    {
        transform.localPosition = new Vector3(0f, 0f, -9100f);
        
    }

    private void OnMouseUpAsButton()
    {
        if (page == 0)
        {
            page = 1;
            textPage1.SetActive(false);
            textPage2.SetActive(true);
        }
        else if (page == 1)
        {
            page = 0;
            textPage1.SetActive(true);
            textPage2.SetActive(false);

            gameObject.SetActive(false); // end of tutorial
        }
    }
}
