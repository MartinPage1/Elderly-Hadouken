using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakAttackScript : MonoBehaviour
{
    private float projectileSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * projectileSpeed);
    }
    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag == "Something")
        {
          Destroy (gameObject);
        }          
     }
}
