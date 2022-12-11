using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship3 : MonoBehaviour
{

    public int number;

    public GameObject panelCanvas;
    public GameObject startObjectMove;


    public Vector3 cursor;

    public laserShip3 _ls;



    

    public GameObject _GO;
    private void Awake()
    {
        playerManager._ship[number] = _GO;
        gameObject.SetActive(false);
        
    }

    void Update()
    {



        


        //вращение обекта для идл короблей
        float speed = 5f;
        transform.RotateAround(new Vector3(0f, -0.5f, 0f), new Vector3(0f, 0f, 1f), speed * Time.deltaTime);

    }



    public void DeleteAllBullet()
    {
        _ls.StopLaser();
    }



}
