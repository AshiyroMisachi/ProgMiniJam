using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BallBehaviour : MonoBehaviour
{
    public float speed, direction;

    public Rigidbody2D myRigidbody;

    public TextMeshProUGUI victoryText;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody.velocity = new Vector2(0, -speed);
    }

    // Update is called once per frame
    void Update()
    {
        // permet de garder la m�me speed en continu
        //myRigidbody.velocity = myRigidbody.velocity.normalized * speed;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Brique>() != null)
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.GetComponent<Player>() != null)
        {
            victoryText.gameObject.SetActive(true);

            if (collision.gameObject.tag == "PlayerA")
            {
                victoryText.text = "JOUEUR B VICTORY";
            }
            else if (collision.gameObject.tag == "PlayerB")
            {
                victoryText.text = "JOUEUR A VICTORY";
            }

            Time.timeScale = 0;
        }

    }

}
