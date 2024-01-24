using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetris_Manager : MonoBehaviour
{
    public GameObject[] tetriminos;
    public GameObject currentTetrominos;
    public GameObject spawnTetriminos;
    private float speedTetriminosFall;
    public float speedTetriminosFallValue;
    public float speedTetriminosTranslate;
    public bool[] timerMovementValue;
    public float protecSpawn;

    void Start()
    {
        CreateTetrominos();
        speedTetriminosFall = speedTetriminosFallValue;
    }

    void Update()
    {
        MovementTetriminos();
    }

    public void CreateTetrominos()
    {
        if (protecSpawn <= 3.5f)
        {
            currentTetrominos = Instantiate(tetriminos[Random.Range(0, tetriminos.Length)], spawnTetriminos.transform.position, Quaternion.identity);
        }

    }

    public void MovementTetriminos()
    {
        //Fall
        if (timerMovementValue[0])
        {
            //currentTetrominos.transform.position += Vector3.down * speedTetriminosFall;
            //currentTetrominos.GetComponent<Rigidbody2D>().velocity = Vector2.down * speedTetriminosFall;
            currentTetrominos.transform.position += Vector3.down * speedTetriminosFall;
            protecSpawn = currentTetrominos.transform.position.y;
            StartCoroutine(ResetTimerMovement(0));
        }

        if (Input.GetKey(KeyCode.S))
        {
            speedTetriminosFall = speedTetriminosFallValue * 2;
        }


        if (currentTetrominos.transform.position.y <= 0)
        {
            currentTetrominos.transform.position = new Vector2(currentTetrominos.transform.position.x, 0);
            CreateTetrominos();
            return;
        }

        //Move Left
        if (Input.GetKey(KeyCode.A) && timerMovementValue[1])
        {
            currentTetrominos.transform.position += Vector3.left * speedTetriminosTranslate;
            StartCoroutine(ResetTimerMovement(1));
        }

        //Move Right
        if (Input.GetKey(KeyCode.D) && timerMovementValue[2])
        {
            currentTetrominos.transform.position += Vector3.right * speedTetriminosTranslate;
            StartCoroutine(ResetTimerMovement(2));
        }

        //Rotate Left
        if (Input.GetKey(KeyCode.Q) && timerMovementValue[3])
        {
            currentTetrominos.transform.eulerAngles += Vector3.forward * 90;
            StartCoroutine(ResetTimerMovement(3));
        }
        //Rotate Right
        if (Input.GetKey(KeyCode.E) && timerMovementValue[4])
        {
            currentTetrominos.transform.eulerAngles += Vector3.back * 90;
            StartCoroutine(ResetTimerMovement(4));
        }
    }

    public IEnumerator ResetTimerMovement(int index)
    {
        timerMovementValue[index] = false;
        yield return new WaitForSeconds(0.25f);
        timerMovementValue[index] = true;
    }
}
