using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Compilation;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public int jumpForce;
    private Rigidbody rigidbody;

    public int lives = 3;
    public int fallDepth;
    private Vector3 startPosition;

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
        if (other.gameObject.GetComponent<EnemyController>())
        {
            Respawn();
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
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
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


    private void Respawn()
    {
        transform.position = startPosition;
        lives--;

        if (lives <= 0)
        {
            this.enabled = false;
        }
    }
}
