using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakAttackScript : MonoBehaviour
{
   private bool faceRight;
   public float projectileSpeed = 10f;
   public bool bouncing;
   public bool isProjectile;
   
   void Update()
   {
      if(bouncing == false){
         transform.position += new Vector3(1f, 0.0f, 0.0f) * Time.deltaTime * projectileSpeed;
       }
      if(isProjectile==false){
         Destroy(gameObject, 5);
         }
   }
   private void OnCollisionEnter2D (Collision2D collision) {
      if ((collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Something") && isProjectile==true)
      {
         Destroy (gameObject);
      }
      else if((collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Something") && isProjectile==false)
      {
        Vector3 relative = transform.InverseTransformDirection(Vector3.forward);
      }    
   }
}