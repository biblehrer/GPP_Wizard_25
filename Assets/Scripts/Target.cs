using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void O(Collision2D collision)
    {
        Debug.Log("HEY");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("LISTEN");
    }
}
