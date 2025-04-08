using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShoot : MonoBehaviour
{
    [Header("Projectile Variable")]
    public bool goingLeft;
    [Header("Spawner Variable")]
    public GameObject projectilePrefab;
    public float timeBetweenShots;
    public float startDelay;


    // Update is called once per frame
    void Update()
    {
        SpawnProjectiles();
    }

    public void SpawnProjectiles()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            if (projectile.GetComponent<LaserScript>())
            {
                projectile.GetComponent<LaserScript>().goingLeft = goingLeft;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            if (projectile.GetComponent<LaserScript>())
            {
                projectile.GetComponent<LaserScript>().goingLeft = true;
            }
        }
    }
}
