using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,3);        
    }

    public void SetValues(Vector3 direction)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * 5;
        transform.position += direction * 1.5f;

        AdjustRotation(direction);

    }

    public void AdjustRotation(Vector3 direction)
    {
        float angle = Vector3.Angle(direction, Vector3.left);        
        if (direction.y > 0)
        {
            angle = angle * -1;
        }
        transform.localRotation = Quaternion.Euler(0,0,angle);
    }

    public void AdjustRotation3(Vector3 direction)
    {
        // TODO finish Code
        float angle = 0;        
        if (direction.y != 0)
        {
            if (direction.y > 0)
            {
                angle = 270;
            }
            else
            {
                angle = 90;
            }
            angle = angle * -1;
        }
        transform.localRotation = Quaternion.Euler(0,0,angle);
    }

    public void AdjustRotation2(Vector3 direction)
    {
        transform.right = direction*-1;       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            Destroy(gameObject);
        }
    }

}
