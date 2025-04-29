using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject target;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
        {
            CreateNewTarget();
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
