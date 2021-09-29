using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakAttackScriptInversed : MonoBehaviour
{
    private bool faceRight;
    private float projectileSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
       transform.position += new Vector3(-1f, 0.0f, 0.0f) * Time.deltaTime * projectileSpeed;
            /*if(faceRight == false){
               transform.position += new Vector3(1f, 0.0f, 0.0f) * Time.deltaTime * projectileSpeed;
            }
            else {
               transform.position += new Vector3(-1f, 0.0f, 0.0f) * Time.deltaTime * projectileSpeed;
            }*/
    }
    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag == "Something")
        {
          Destroy (gameObject);
        }          
     }
}
