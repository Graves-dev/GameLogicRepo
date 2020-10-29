using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//To restart game
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    public int health;
    
    // Start is called before the first frame update
    void Start() {
       
    }

    // Update is called once per frame
    void Update() {
        if (gameObject.transform.position.y < -7) {
            Die();
        }
    }

    // IEnumerator's can stall for an amount of time
    void Die () {
    //  Eveerything within the Enumerator happens as listed
        // Debug.Log("Player Has fallen");
        // yield return new WaitForSeconds (2);
        // Debug.Log("Player has died");
        SceneManager.LoadScene ("Prototype");
    //The function has to have a return because it has a type
        
    }
}
