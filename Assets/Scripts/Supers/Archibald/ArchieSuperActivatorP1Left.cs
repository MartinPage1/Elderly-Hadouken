using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchieSuperActivatorP1Left : MonoBehaviour
{
    //Left

    public float projectileSpeed = 15f;
    public GameManager gM;
    bool hitTarget;

    void Awake()
    {
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
        hitTarget = false;
        StartCoroutine("DestroySelf", 8f);
    }

    void Update()
    {
        transform.position += new Vector3(-1f, 0.0f, 0.0f) * Time.deltaTime * projectileSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player 2")
        {
            hitTarget = true;
            Destroy(gameObject);
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
        if (hitTarget == true)
        {
            gM.ArchieAttackP1();
        }
    }
}

