using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdithSuper2P2 : MonoBehaviour
{
    //Right
    public float projectileSpeed = 9f;
    public GameObject currentPlayerOne;
    public Rigidbody2D rb;
    public bool stuck;

    private void Awake()
    {
        stuck = false;
        StartCoroutine("DestroySelf", 5f);
        transform.Rotate(0.0f, 0.0f, -90.0f, Space.World);
    }

    void Update()
    {
        currentPlayerOne = GameObject.FindGameObjectWithTag("Player");
        if (stuck == false)
        {
            transform.position += new Vector3(-1f, 0.0f, 0.0f) * Time.deltaTime * projectileSpeed;
        }
        if (stuck == true)
        {
            transform.position = currentPlayerOne.transform.position;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        CharacterController2D opponent = collision.GetComponent<CharacterController2D>();
        if (opponent != null)
        {
            transform.parent = currentPlayerOne.transform;
            stuck = true;
            opponent.EdithDamage();
            StartCoroutine("DestroySelf", 8f);
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
}
