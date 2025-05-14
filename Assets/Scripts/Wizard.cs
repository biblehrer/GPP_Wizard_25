using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    public GameObject fireballPrefab;    
    private Vector3 lastDirection;
    
    // Componenten
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;

    // Players Stats
    private float castingTimer = 0;
    public WizardClass stats; 


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();        
    }

    void Update()
    {
        animator.SetBool("attack", false);  
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
        rb.velocity = direction.normalized * stats.movementSpeed;

        if (direction.x < 0)
        {
            sr.flipX = true;
        }
        if (direction.x > 0)
        {
            sr.flipX = false;
        }

        if (direction.magnitude > 0)
        {
            lastDirection = direction.normalized;
        }
        animator.SetBool("move", direction.magnitude > 0);  
        
    }

    void Casting()
    {
        castingTimer -= Time.deltaTime;
        if (Input.GetKeyUp(KeyCode.Space) && castingTimer <= 0 && stats.mana >= 20)
        {
            animator.SetFloat("attackSpeed", stats.castingTimeBase /stats.castingTime);
            castingTimer = stats.castingTime;            
            animator.SetBool("attack", true);
            stats.mana -= 20;   
        }  

        stats.mana += Time.deltaTime * stats.manaRegeneration;
        if (stats.mana > stats.maxMana)
        {
            stats.mana = stats.maxMana;
        }      
    }

    public void CreateFireball()
    {
        GameObject obj = Instantiate(fireballPrefab, transform.position, Quaternion.identity);  
        obj.GetComponent<Fireball>().SetValues(lastDirection);   
    }

}
