using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectGenerator : MonoBehaviour  {
    public GameObject[] randomObject;

    void Update()   {
                
        //Generates random  Objects
        Instantiate (randomObject[Random.Range(0, randomObject.Length)], transform.position, transform.rotation); 
       
        }
}
