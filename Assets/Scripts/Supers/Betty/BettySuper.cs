using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BettySuper : MonoBehaviour
{
    //Right
    public float projectileSpeed = 3f;
    public Rigidbody2D rb;

    private void Awake()
    {

        StartCoroutine("DestroySelf", 5f);
    }

    void Update()
    {
        transform.position += new Vector3(1f, 0.0f, 0.0f) * Time.deltaTime * projectileSpeed;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        CharacterTwoController2D opponent = collision.GetComponent<CharacterTwoController2D>();
        if (opponent != null)
        {
            opponent.BettyDamage();
            StartCoroutine("DestroySelf", 2f);
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
