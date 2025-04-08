using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public int speed;
    public bool goingLeft;
    private float cooldownTime = 5;
    private float nextFire = 3f;

    // Update is called once per frame
    void Update()
    {
        if (goingLeft == true)
        {
            transform.position += speed * Vector3.right * Time.deltaTime;
            nextFire = cooldownTime;
        }
        else
        {
            transform.position += speed * Vector3.left * Time.deltaTime;
            nextFire = cooldownTime;
        }
    }
}
