using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyMovement : MonoBehaviour
{
    public int EnemySpeed;
    public int XMoveDirection;
    
    // Update is called once per frame
    void Update()
    {
       RaycastHit2D hit = Physics2D.Raycast (transform.position, new Vector2 (XMoveDirection, 0));
       gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (XMoveDirection, 0) * EnemySpeed; 
        if (hit.distance < 0.7f) {
            Flip();
            //Allows enemy to destroy any object it collides with
            // Destroy (hit.collider.gameObject);
        if (hit.collider.tag == "Player") {
            Destroy (hit.collider.gameObject);
            //Added this trigger (on my own) to reset game when plsyer is hit by character 
            SceneManager.LoadScene ("Prototype");
        }
        //WILL NOT WORK IF PLAYER IS ON IGNORE RAYCAST LAYER
        }

    }
    void Flip() {
        if (XMoveDirection > 0) {
            XMoveDirection = -1;
        }
        else {
            XMoveDirection  = 1;
        }
    }
}
