using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlbertSuper2 : MonoBehaviour
{
    private Vector3 targetPos;
    public float mySpeed = 10f;
    public GameObject mytarget;

    void Awake()
    {
        mytarget = GameObject.FindGameObjectWithTag("Player");
        targetPos = mytarget.transform.position;
        StartCoroutine("DestroySelf", 3f);
    }

    void Update()
    {
        mytarget = GameObject.FindGameObjectWithTag("Player");
        if (mytarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, mySpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position, mySpeed * Time.deltaTime);
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