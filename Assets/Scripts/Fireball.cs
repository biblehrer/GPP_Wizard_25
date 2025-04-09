using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,3);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.up * 5;
    }

    // Update is called once per frame
    void Update()
    {
        //Random.Range(0f, );
    }









    public void DoSomething(Vector3 direction)
    {
        float angle = Vector3.Angle(direction, Vector3.right);

        if (direction.y <0)
        {
            angle = angle * -1;
        }
    }
}
