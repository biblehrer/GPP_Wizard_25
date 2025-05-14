using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject target;
    private Wizard player;
    private float lifeTimeCounter = 0;  

    void Start ()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Wizard>();
    }

    void Update ()
    {
        lifeTimeCounter += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
        {
            player.stats.GainXP(Mathf.Max(1, 5-lifeTimeCounter));
            CreateNewTarget();
            GameUI.score++;
            Destroy(gameObject);
            
        }
    }

    void CreateNewTarget()
    {
        float x = Random.Range(-8.3f, 8.3f);
        float y = Random.Range(-4.5f,4.5f);
        Instantiate(target,new Vector3(x,y,0), Quaternion.identity);
    }
}
