using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship4 : MonoBehaviour
{
    public GameObject panelCanvas;
    public GameObject startObjectMove;


    public GameObject gun;
    public GameObject gun1;

    public bulletShip prefabBullet;
    private bulletShip[] _allBullet = new bulletShip[250];

    private float timerFire = 0f;


    public GameObject _GO;
    private void Awake()
    {
        playerManager._ship[4] = _GO;
        gameObject.SetActive(false);
    }
    void Update()
    {


        if (playerManager.planetD == 0)
            timerFire += playerManager.shipSpeed[4] * Time.deltaTime;
        if (timerFire >= 1f)
        {
            timerFire = 0;
            FireBullet(0);
            FireBullet(1);
        }


        //вращение обекта для идл короблей
        float speed = -8f;
        transform.RotateAround(new Vector3(0f, -0.5f, 0f), new Vector3(0f, 0f, 1f), speed * Time.deltaTime);

    }




    public void FireBullet(int num)
    {
        
        for (int i = 0; i < 250; i++)
        {
            if (_allBullet[i] == null)
            {
                _allBullet[i] = Instantiate(prefabBullet, panelCanvas.transform);
                if (num == 0)
                {
                    _allBullet[i].StartMoveBullet(gun.transform.position);
                    _allBullet[i].number = 4;
                } 
                else if (num == 1)
                {
                    _allBullet[i].StartMoveBullet(gun1.transform.position);
                    _allBullet[i].number = 4;
                }

                
                break;
            }
            else
            {
                if (_allBullet[i].isActiveAndEnabled == false)
                {
                    _allBullet[i].gameObject.SetActive(true);
                    if (num == 0)
                    {
                        _allBullet[i].StartMoveBullet(gun.transform.position);
                        _allBullet[i].number = 4;
                    }
                    else if (num == 1)
                    {
                        _allBullet[i].StartMoveBullet(gun1.transform.position);
                        _allBullet[i].number = 4;
                    }
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
