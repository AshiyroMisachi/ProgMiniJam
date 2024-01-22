using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineBehaviour : MonoBehaviour
{
    public Transform myTransform, limitLeft, limitRight;
    public float speed;

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
                myTransform.position += Vector3.left * speed;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (myTransform.position.x < limitRight.position.x)
            {
                myTransform.position += Vector3.right * speed;
            }
        }
    }
}
