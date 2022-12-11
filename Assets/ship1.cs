using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship1 : MonoBehaviour
{



    public GameObject panelCanvas;
    public GameObject startObjectMove;
    

    public Vector3 cursor;

    public bulletShip prefabBullet;
    private bulletShip[] _allBullet = new bulletShip[250];

    private float timerFire = 0f;
    

    public GameObject _GO;
    private void Awake()
    {
        playerManager._ship[1] = _GO;
        gameObject.SetActive(false);
    }

    void Update()
    {


        if(playerManager.planetD == 0)
            timerFire += playerManager.shipSpeed[1] * Time.deltaTime;
        if (timerFire >= 1f)
        {
            timerFire = 0;
            FireBullet();
        }


        //вращение обекта для идл короблей
        float speed = 6.5f;
        transform.RotateAround(new Vector3(0f, -0.5f, 0f), new Vector3(0f, 0f, 1f), speed * Time.deltaTime);

    }




    public void FireBullet()
    {
        for (int i = 0; i < 250; i++)
        {
            if (_allBullet[i] == null)
            {
                _allBullet[i] = Instantiate(prefabBullet, panelCanvas.transform);
                _allBullet[i].StartMoveBullet(startObjectMove.transform.position);
                _allBullet[i].number = 1;
                break;
            }
            else
            {
                if (_allBullet[i].isActiveAndEnabled == false)
                {
                    _allBullet[i].gameObject.SetActive(true);
                    _allBullet[i].StartMoveBullet(startObjectMove.transform.position);
                    _allBullet[i].number = 1;
                    break;
                }
            }
        }


        
    }

    public void DeleteAllBullet()
    {
        for (int i = 0; i < 250; i++)
        {
            if (_allBullet[i] != null)
            {
                _allBullet[i].gameObject.SetActive(false);
            }
        }
    }


}
