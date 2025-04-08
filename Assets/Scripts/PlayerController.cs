using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Compilation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Player Variables")]
    public int speed;
    public int jumpForce;
    private Rigidbody rigidbody;

    public int Health = 100;
    public int fallDepth;
    private Vector3 startPosition;

    public float totalCoins = 0f;
    private float coinValue = 1f;


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        SpaceJump();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            totalCoins += coinValue;
            Destroy(other.gameObject);
        }


        if (other.gameObject.GetComponent<EnemyController>())
        {
            Health -= 15;

            if (Health <= 0)
            {
                Respawn();
            }
        }

        if (other.gameObject.tag == "Spike")
        {
            Respawn();
        }

        if (other.gameObject.GetComponent<PortalScript>())
        {
            startPosition = other.gameObject.GetComponent<PortalScript>().spawnPoint.transform.position;
            transform.position = startPosition;
        }
    }

    /// <summary>
    /// Lets the player move with these inputs
    /// </summary>
    public void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (transform.position.y < fallDepth)
        {
            Respawn();
        }
    }

    /// <summary>
    /// lets the player jump with space
    /// </summary>
    public void SpaceJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
            {
                Debug.Log("Touching the ground");

                rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            else
            {
                Debug.Log("Can't jump, not touching the ground");
            }
        }
    }

    /// <summary>
    /// lets the player respawn
    /// </summary>
    private void Respawn()
    {
        transform.position = startPosition;
        Health -= 15;

        if (Health <= 0)
        {
            this.enabled = false;
            SceneManager.LoadScene(2);
        }
    }
}
