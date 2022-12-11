using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fragment : MonoBehaviour
{

    public int number;
    public int number2;
    public int fragmProp = 0;

    private float animX;
    private float animY;
    private float animSpeed = 1f;
    private bool animOnOff = false;

    public SpriteRenderer _sr;
    public Sprite[] _icon;

    private Vector3 pos = new Vector3(0f, 0f, 0f);

    private void FixedUpdate()
    {
        if (animOnOff == true)
        {
            _sr.color = new Vector4(1f, 1f, 1f, _sr.color.a - 0.25f * Time.deltaTime) ;
            transform.localPosition = new Vector3(transform.localPosition.x + animX * animSpeed * Time.deltaTime, transform.localPosition.y + animY * animSpeed * Time.deltaTime, 0f);
        }
            
    }

    public void StartFragment()
    {
        int count = 0;
        for (int i = 0; i < 1600; i++)
        {
            if(planetManager.planetGrid[i] > 0)
            {
                if(planetManager.countPlanetQueue == count)
                {
                    pos.x = -1.17f + i % 40 * 0.06f;
                    pos.y = -1.17f + i / 40 * 0.06f;
                    transform.localPosition = pos;
                    planetManager.countPlanetQueue += 1;
                    number2 = i;


                    UpdateFragment();

                    playerManager.fragmentHpProp[number] = planetManager.planetGridDif[i];
                    

                    break;
                }
                count += 1;
            }
        }       
    }


    public void UpdateFragment()
    {
        if (planetManager.stateFrag == 0)
            _sr.sprite = _icon[planetManager.planetGrid[number2] - 1];
        if (planetManager.stateFrag == 1)
            _sr.sprite = _icon[planetManager.planetGrid[number2] - 1 + 6];
        if (planetManager.stateFrag == 2)
            _sr.sprite = _icon[planetManager.planetGrid[number2] - 1 + 12];
    }

    public void PlanetDeathAnimation()
    {
        animX = Random.Range(-1f, 1f);
        animY = Random.Range(-1f, 1f);
        animOnOff = true;
    }

    public void PlanetAnimationEnd()
    {
        transform.localPosition = pos;
        _sr.color = new Vector4(1f, 1f, 1f, 1f);
        animOnOff = false;
        UpdateFragment();
    }
}
