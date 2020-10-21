using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoveProt : MonoBehaviour
{
    public int playerSpeed = 10;
    public int playerJumpPower = 1250;
    private bool facingRight = false;
    private float moveX;

    void Start()    
    {
        facingRight = false;
    }
    // Update is called once per frame
    void Update()
    {
     PlayerMove();
    }
    void PlayerMove()   {
        //CONTROLS
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown ("Jump")){
            Jump();
        }
        //PLAYER ANIMATION
        //PLAYER DIRECTION
        if (moveX < 0.0f && facingRight == false) 
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true)   
        {
           FlipPlayer(); 
        }
        //PHYSICS
        //getComponent refers to interacting with any component of the object that the script is in
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }
    void Jump() {
        //jUMPING CODE
    GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
    }

    void FlipPlayer() {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
