using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GertieSuperP1 : MonoBehaviour
{
    //Right
    public float projectileSpeed = 9f;
    public GameObject currentPlayerTwo;
    public Rigidbody2D rb;
    public bool stuck;
    public bool right = true;

    private void Awake()
    {
        stuck = false;
        StartCoroutine("DestroySelf", 5f);
        transform.Rotate(0.0f, 0.0f, 180.0f, Space.World);
    }

    void Update()
    {
        currentPlayerTwo = GameObject.FindGameObjectWithTag("Player 2");
        if (stuck == false && right == true)
        {
            transform.position += new Vector3(1f, 0.0f, 0.0f) * Time.deltaTime * projectileSpeed;
        }
        if (stuck == false && right == false)
        {
            transform.position += new Vector3(-1f, 0.0f, 0.0f) * Time.deltaTime * projectileSpeed;
        }
        if (stuck == true)
        {
            transform.position = currentPlayerTwo.transform.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterTwoController2D opponent = collision.GetComponent<CharacterTwoController2D>();
        if (opponent != null)
        {
            opponent.GrabToggle();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        CharacterTwoController2D opponent = collision.GetComponent<CharacterTwoController2D>();
        if (opponent != null)
        {
            transform.parent = currentPlayerTwo.transform;
            stuck = true;
            opponent.GertieDamage();
            StartCoroutine("DestroySelf", 5f);
        }
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
