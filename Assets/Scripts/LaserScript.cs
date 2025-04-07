using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float speed;
    public bool goingLeft;
    public float cooldownTime;
    public int maxDistance;
    public Vector3 leftPos;

    // Update is called once per frame
    void Update()
    {
        if (goingLeft == true)
        {
            transform.position += cooldownTime * Vector3.right * Time.deltaTime;
        }
        else
        {
            transform.position += cooldownTime * Vector3.left * Time.deltaTime;
        }

        if (transform.position.y < maxDistance)
        {
            
        }
    }
}
