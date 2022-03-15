using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlbertP2ActivateSuper : MonoBehaviour
{
    public float mySpeed = 18f;
    private Vector3 sky;
    public GameManager gM;
    private float lastAttackedAt = -9999f;

    void Awake()
    {
        StartCoroutine("DestroySelf", 8f);
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        sky = new Vector3(0f, 7f, 0f);
        transform.position = Vector3.MoveTowards(transform.position, sky, mySpeed * Time.deltaTime);
        if (transform.position.y >= 5.5f)
        {
            if (Time.time > lastAttackedAt + 1f)
            {
                gM.AlbertsAttackP2();
                lastAttackedAt = Time.time;
            } 
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