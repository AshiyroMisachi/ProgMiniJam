using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brique : MonoBehaviour
{
    public Tetris_Manager tetrisManager;

    private void Start()
    {
        //Find Reference
        tetrisManager = FindObjectOfType<Tetris_Manager>();
    }

    //Spawn Tetriminos if touch deadline or other brick
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Brique brique = collision.gameObject.GetComponent<Brique>();
        if (brique != null && brique.transform.parent != transform.parent && transform.parent == tetrisManager.currentTetrominos)
        {
            tetrisManager.CreateTetrominos();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (tetrisManager.timerMovementValue[9])
        {
            tetrisManager.currentTetrominos.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            tetrisManager.CreateTetrominos();
            StartCoroutine(tetrisManager.ResetTimerMovement(9));
        }

    }
}
