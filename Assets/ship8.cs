using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship8 : MonoBehaviour
{
    public GameObject panelCanvas;
    public GameObject startObjectMove;


    public Vector3 shipPosition;

    public bulletShip prefabBullet;
    private bulletShip[] _allBullet = new bulletShip[250];

    private float timerFire = 0f;

    public GameObject _GO;
    private void Awake()
    {
        playerManager._ship[8] = _GO;
        gameObject.SetActive(false);
    }

    void Update()
    {


        if (playerManager.planetD == 0)
            timerFire += playerManager.shipSpeed[8] * Time.deltaTime;
        if (timerFire >= 1f)
        {
            timerFire = 0;
            for (int i = 0; i < 7; i++)
                FireBullet();
        }


        //вращение обекта для идл короблей
        float speed = -12f;
        transform.RotateAround(new Vector3(0f, -0.5f, 0f), new Vector3(0f, 0f, 1f), speed * Time.deltaTime);

    }




    public void FireBullet()
    {
        shipPosition = transform.position;
        shipPosition.x += Random.Range(-0.1f, 0.1f);
        shipPosition.y += Random.Range(-0.1f, 0.1f);
        for (int i = 0; i < 250; i++)
        {
            if (_allBullet[i] == null)
            {
                _allBullet[i] = Instantiate(prefabBullet, panelCanvas.transform);
                _allBullet[i].StartMoveBullet(shipPosition);
                _allBullet[i].number = 8;
                break;
            }
            else
            {
                if (_allBullet[i].isActiveAndEnabled == false)
                {
                    _allBullet[i].gameObject.SetActive(true);
                    _allBullet[i].StartMoveBullet(shipPosition);
                    _allBullet[i].number = 8;
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
