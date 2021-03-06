using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperStick : MonoBehaviour
{
    public float projectileSpeed = 9f;
    public GameObject currentPlayerOne;
    public Rigidbody2D rb;
    public bool stuck;

    private void Awake()
    {
        stuck = false;
    }

    void Update()
    {
        currentPlayerOne = GameObject.FindGameObjectWithTag("Player");
        if (stuck == false)
        {
            //transform.position += new Vector3(1f, 0.0f, 0.0f) * Time.deltaTime * projectileSpeed;
        }
        if (stuck == true)
        {
            transform.position = currentPlayerOne.transform.position;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //CharacterController2D opponent = collision.GetComponent<CharacterController2D>();
        //if (opponent != null)
        if (collision.collider.gameObject.tag == "Player")
        {
            transform.parent = currentPlayerOne.transform;
            stuck = true;
            StartCoroutine("Damage", 1f);
            //StartCoroutine("DestroySelf", 8f);
        }
    }
    private IEnumerator Damage(float time)
    {
        CharacterController2D opponent = currentPlayerOne.GetComponent<CharacterController2D>();
        float pauseEndTime = Time.realtimeSinceStartup + time;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        opponent.DentureDamage();

        StartCoroutine("Damage", 1f);
    }
    private IEnumerator DestroySelf(float time)
    {
        float pauseEndTime = Time.realtimeSinceStartup + time;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        currentPlayerOne.GetComponent<CharacterController2D>().GrabToggle();
    }
}
