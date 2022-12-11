using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipClick : MonoBehaviour
{

    

    public GameObject panelCanvas;
    public GameObject startObjectMove;
    public manualBar _manualBar;

    public Vector3 cursor;

    public bulletShip prefabBullet;
    private bulletShip[] _allBullet = new bulletShip[250];

    //private float timerFire = 0f;

    public bool IsPressed = false;

    void Update()
    {
        cursor = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));

        Vector3 position = Camera.main.ScreenToWorldPoint(cursor);
        float angle = Vector2.Angle(Vector2.up, cursor - transform.position);
        transform.eulerAngles = new Vector3(0f, 0f, transform.position.x < cursor.x ? -angle : angle);


        //if (IsPressed == true)
        //{
        //    timerFire += 1f * Time.deltaTime;
        //    if (timerFire >= 0.5f)
        //    {
        //        timerFire = 0;
        //        FireBullet();
        //    }
        //}


        //вращение обекта для идл короблей
        //float speed = 10f;
        //transform.RotateAround(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 1f), speed * Time.deltaTime);

    }




    public void FireBullet()
    {
        for(int i = 0; i < 250; i++)
        {
            if (_allBullet[i] == null)
            {
                _allBullet[i] = Instantiate(prefabBullet, panelCanvas.transform);
                _allBullet[i].StartMoveBullet(startObjectMove.transform.position);
                break;
            }
            else
            {
                if(_allBullet[i].isActiveAndEnabled == false)
                {
                    _allBullet[i].gameObject.SetActive(true);
                    _allBullet[i].StartMoveBullet(startObjectMove.transform.position);
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
                _allBullet[i].number = 0;
            }   
        }
    }



    private void OnMouseDown()
    {
        if (playerManager.planetD == 0)
        {
            FireBullet();
            IsPressed = true;

            if(_manualBar.state == 0)
            {
                _manualBar.timer += 1f;
                if (_manualBar.timer >= 20f)
                {
                    _manualBar.ManualBuff();
                }
                    
            }
            
        }
            
    }

    private void OnMouseUp()
    {
        //timerFire = 0;
        IsPressed = false;
    }

    private void OnMouseExit()
    {
        //timerFire = 0;
        IsPressed = false;
    }


}
