using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    public GameObject fireballPrefab;
    private Rigidbody2D rb;
    private Vector3 lastDirection;
    private float movementSpeed = 3;
    float castingTimer = 0;
    float castingCooldown = 2;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
        Casting();
    }

    void Movement()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }
        rb.velocity = direction.normalized * movementSpeed;

        if (direction.magnitude > 0)
        {
            lastDirection = direction.normalized;
        }
        
    }

    void Casting()
    {
        castingTimer -= Time.deltaTime;
        if (Input.GetKeyUp(KeyCode.Space) && castingTimer <= 0)
        {
            // Reset the Casting
            castingTimer = castingCooldown;

            // Give the Fireball its Direction and Values
            GameObject obj = Instantiate(fireballPrefab, transform.position, Quaternion.identity);                  
            obj.GetComponent<Fireball>().SetValues(lastDirection);        
        }        
    }
}
