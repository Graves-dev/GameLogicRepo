using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoveProt : MonoBehaviour
{
    public int playerSpeed = 10;
    public bool isGrounded;
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
     PlayerRaycast();    
    }
    void PlayerMove() {
        //CONTROLS
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown ("Jump") && isGrounded == true){
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
        isGrounded = false;
    }
    void FlipPlayer() {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    void OnCollisionEnter2D (Collision2D col) {
    //   Debug.Log ("Player has collided with " + col.collider.name);
        // if (col.gameObject.tag == "ground") {
        //     isGrounded = true;
        // }
        
    } 
    void PlayerRaycast () {
        //Raycast shoots ray from bottom of player
        //Allows the ray to trigger a jump for the player when its above enemy
     RaycastHit2D rayUp = Physics2D.Raycast (transform.position, Vector2.up);
     //TODO: FIX CODE
     if (rayUp != null && rayUp.collider != null && rayUp.distance < 1.111f && rayUp.collider.name == "Breakable") {
         Destroy (rayUp.collider.gameObject);
     }
     RaycastHit2D rayDown = Physics2D.Raycast (transform.position, Vector2.down);
        //"rayDown != null && rayDown.collider != null" makes sure we do not recieve error when the target below = null
        if (rayDown != null && rayDown.collider != null && rayDown.distance < 1.111f && rayDown.collider.tag == "enemy") {
            Debug.Log("Enemy contact");
            GetComponent<Rigidbody2D>().AddForce (Vector2.up * 800);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().AddForce (Vector2.right * 200);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 8;
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            rayDown.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rayDown.collider.gameObject.GetComponent<enemyMovement>().enabled = false;
            
        }
        if (rayDown != null && rayDown.collider != null && rayDown.distance < 1.111f && rayDown.collider.tag != "enemy") {                
                isGrounded = true;
            }
    } 
}
