using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public float speed, direction;

    public Rigidbody2D myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody.velocity = new Vector2(0, -speed);
    }

    // Update is called once per frame
    void Update()
    {
        // permet de garder la même speed en continu
        //myRigidbody.velocity = myRigidbody.velocity.normalized * speed;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Brique>() != null)
        {
            Destroy(collision.gameObject);
        }
        
    }

}
