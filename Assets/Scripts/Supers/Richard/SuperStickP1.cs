using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperStickP1 : MonoBehaviour
{
    public float projectileSpeed = 9f;
    public GameObject currentPlayerTwo;
    public Rigidbody2D rb;
    public bool stuck;

    private void Awake()
    {
        stuck = false;
    }

    void Update()
    {
        currentPlayerTwo = GameObject.FindGameObjectWithTag("Player 2");
        if (stuck == false)
        {
            //transform.position += new Vector3(1f, 0.0f, 0.0f) * Time.deltaTime * projectileSpeed;
        }
        if (stuck == true)
        {
            transform.position = currentPlayerTwo.transform.position;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //CharacterController2D opponent = collision.GetComponent<CharacterController2D>();
        //if (opponent != null)
        if (collision.collider.gameObject.tag == "Player 2")
        {
            transform.parent = currentPlayerTwo.transform;
            stuck = true;
            StartCoroutine("Damage", 1f);
            //StartCoroutine("DestroySelf", 8f);
        }
    }
    private IEnumerator Damage(float time)
    {
        CharacterTwoController2D opponent = currentPlayerTwo.GetComponent<CharacterTwoController2D>();
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
        currentPlayerTwo.GetComponent<CharacterTwoController2D>().GrabToggle();
    }
}
