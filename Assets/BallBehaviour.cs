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
        Debug.Log(myRigidbody.velocity);

        myRigidbody.velocity = myRigidbody.velocity.normalized * speed;
    }
}
