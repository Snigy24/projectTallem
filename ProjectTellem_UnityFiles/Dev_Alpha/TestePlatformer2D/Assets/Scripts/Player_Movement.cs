using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    // Player var
    private GameObject player;

    // Jump vars
    public bool midjump = false;
    public int playerJump = 1250;
    public bool isgrounded = false;

    // Movement vars
    public int playerSpeed = 10;
    private bool facingRight = false;
    private float moveX;

    // Cooldown vars
    public float cooldownTime = 3;
    private float nextTeleport = 0;

    // Update is called once per frame
    void Update() {
        PlayerMove();
        PlayerTeleport();
        if ((isgrounded == true) && (Input.GetKeyDown("space")))
        {
            PlayerJump();
        }
    }

    //Jump detection
    void OnCollisionEnter2D(Collision2D Col)
    {
        if (Col.gameObject.tag == "Ground")
        {
            isgrounded = true;
            print("Grounded");
        }
    }

    void OnCollisionExit2D(Collision2D Col)
    {
        if (Col.gameObject.tag == "Ground")
        {
            isgrounded = false;
            print("Not Grounded");
        }
    }

    void PlayerMove()
    {
        //Controls

        //Move
        moveX = Input.GetAxis("Horizontal");

        //Animations
        //Facing direction
        if (moveX < 0.0f && facingRight == false)
        {
            PlayerFlip();
        } else if (moveX > 0.0f && facingRight == true)
        {
            PlayerFlip();
        }
        //Physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void PlayerJump()
    {
        //Jump
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJump);
    }

    void PlayerFlip()
    {
        //Flip
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void PlayerTeleport()
    {
        //Teleport
        if (Time.time > nextTeleport)
        {
            if ((Input.GetKeyDown(KeyCode.G)) && (transform.position.y >= -30))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 67, transform.position.z);
                print("Cooldown started");
                nextTeleport = Time.time + cooldownTime;
            }
        }

        if ((Time.time > nextTeleport) && (transform.position.y < -30))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 67, transform.position.z);
        }
    }
}
