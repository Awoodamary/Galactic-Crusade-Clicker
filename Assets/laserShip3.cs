using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserShip3 : MonoBehaviour
{

    public int number;

    private int cont = 0;
    private float damageCooldownMax = 1f;
    private float damageCooldown;
    private float MaxScale = 37.5f;
    private Vector3 ScaleY = new Vector3(1f,1f,1f);

    public GameObject _LS3F;


    void FixedUpdate()
    {
        if (playerManager.planetD == 1)
        {
            StopLaser();
        }
        else
            damageCooldown += playerManager.shipSpeed[number] * Time.deltaTime;
        //удлинение
        if (cont == 1)
        {
            if (ScaleY.y <= MaxScale)
            {
                ScaleY.y += 100f * Time.deltaTime;
                transform.localScale = ScaleY;
            }
        }
        //обнуление
        if (cont == 0)
        {
            cont = 1;
            ScaleY.y = 1f;
            transform.localScale = ScaleY;
        }
        

    }



    public void StopLaser()
    {
        cont = 0;
        ScaleY.y = 1f;
        transform.localScale = ScaleY;
        _LS3F.transform.localScale = transform.localScale;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (cont == 1 && other.transform.tag == "fragment")
        {
            int num = other.transform.GetComponent<fragment>().number;

            //сравнение лазера
            _LS3F.transform.localScale = transform.localScale;
            //наносим урон
            if (damageCooldown >= damageCooldownMax)
            {
                if (Random.Range(0f, 100f) <= playerManager.shipCrit[number])
                {
                    playerManager.fragmentHp[num] -= playerManager.shipDamage[number] * playerManager.shipCritPow[number] / 100d;
                }
                else
                {
                    playerManager.fragmentHp[num] -= playerManager.shipDamage[number];
                }
                damageCooldown = 0;
            }
            
            //делаем проверку на убийство фрагмента
            if (playerManager.fragmentHp[num] <= 0)
            {
                planetManager._allFragment[num].gameObject.SetActive(false);
                playerManager.money += playerManager.moneyPerBlock;
                playerManager.moneyTotal += playerManager.moneyPerBlock;
                playerManager.fragentAmount -= 1;
            }
            cont = 0;

        }
    }




}
