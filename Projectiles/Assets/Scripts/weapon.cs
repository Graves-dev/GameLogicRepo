using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
public Transform firePoint;
public int damage = 30;

void Shoot() {
   
   RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
   if (hitInfo)   {      
      Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
      hitInfo.transform.GetComponent<Enemy>();
      if (enemy != null)   {         
         enemy.TakeDamage(damage);
      }
   }
}
void Update()  {
   if (Input.GetButtonDown("Fire1"))   {
      Shoot();
   }   
}
}