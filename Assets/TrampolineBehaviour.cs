using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineBehaviour : MonoBehaviour
{
    public Transform myTransform, limitLeft, limitRight;
    public float speed;
    public Rigidbody2D myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (myTransform.position.x > limitLeft.position.x)
            {
                myRigidbody.velocity = Vector2.left * speed; 
            }
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (myTransform.position.x < limitRight.position.x)
            {
                myRigidbody.velocity = Vector2.right * speed;
            }
        }

        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow) || !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidbody.velocity = new Vector2(0, 0);
        }
    }
}
