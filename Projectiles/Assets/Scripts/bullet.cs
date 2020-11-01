using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    
    public float speed = 25f;
    public int damage = 20;    
    public Rigidbody2D rb;
    

    void Start()
    {
    // MK BULLET MOVE
        rb.velocity = transform.right * speed;
    }

    void onTriggerEnter2D (Collider2D hitInfo) {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)  {
           enemy.TakeDamage(damage); 
        }
        Destroy(gameObject);
        
    }
}
