using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
public Transform firePoint;
public GameObject projectilePrefab;
    // Update is called once per frame
    void Update()
    {
    //Fire1 is left mouse button
       if (Input.GetButtonDown("Fire1")) {
          Shoot(); 
       }
       void Shoot() {
           // Shoot Logic
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
       }
    }
}
