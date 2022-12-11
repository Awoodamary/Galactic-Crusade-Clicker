using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletShip : MonoBehaviour
{


    public Animator _animator;
    public BoxCollider _bc;

    private int state = 0;

    public int number = 0;

    private float speed = 1f;

    private Vector3 targetPos = new Vector3(0f, -0.5f, 0f);

    public AudioSource _AS;
    public AudioClip[] audioClip;
    private void FixedUpdate()
    {
        //если ещё не достиг цели
        if(state == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(targetPos.y - transform.position.y, targetPos.x - transform.position.x) * Mathf.Rad2Deg - 90);





            if (transform.position == targetPos)
            {
                state = 1;
                _bc.enabled = false;
                _animator.SetInteger("state", 1);
            }
        }
        
        



    }

   

    public void StartMoveBullet(Vector3 startPos)
    {
        transform.position = startPos;
        _bc.enabled = true;
        state = 0;
        _animator.SetInteger("state", 0);

    }


    public void AnimEnd()
    {
        gameObject.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (state == 0 && other.transform.tag == "fragment")
        {
            int num = other.transform.GetComponent<fragment>().number;
            state = 1;

            //наносим урон
            if(Random.Range(0f,100f) <= playerManager.shipCrit[number])
            {
                playerManager.fragmentHp[num] -= playerManager.shipDamage[number] * playerManager.shipCritPow[number] / 100d;
            }
            else
            {
                playerManager.fragmentHp[num] -= playerManager.shipDamage[number];
            }
            
            //делаем проверку на убийство фрагмента
            if (playerManager.fragmentHp[num] <= 0)
            {
                planetManager._allFragment[num].gameObject.SetActive(false);
                playerManager.money += playerManager.moneyPerBlock;
                playerManager.moneyTotal += playerManager.moneyPerBlock;
                playerManager.fragentAmount -= 1;

                if(playerManager.musicOnOff == 0)
                {
                    _AS.clip = audioClip[Random.Range(0,7)];
                    _AS.Play();
                }
            }
            _bc.enabled = false;

            _animator.SetInteger("state", 1);

        }
    }

    




}
