using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{


    private float rotationZ = 0f;



    private void FixedUpdate()
    {
        rotationZ += 1f * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    }

}
