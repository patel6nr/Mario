using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float jumpStrength;
    public LogicScript logic;
    public bool marioIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic")?.GetComponent<LogicScript>();
        if (logic == null)
        {
            Debug.LogError("LogicScript component not found!");
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && marioIsAlive)
        {
            myRigidbody.velocity = Vector2.up * jumpStrength;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();
    }

    private void OnBecameInvisible()
    {
        GameOver();
        marioIsAlive = false;
    }

    private void GameOver()
    {
        if (marioIsAlive)
        {
            logic?.gameOver();
            marioIsAlive = false;
        }
    }
}