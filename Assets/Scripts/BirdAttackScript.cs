using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAttackScript : MonoBehaviour
{
    private Vector3 targetPos;
    public float mySpeed = 5f;
    public GameObject mytarget;

    void Awake()
    {
        //mytarget = GameObject.FindGameObjectWithTag("Player");
        //targetPos = mytarget.transform.position;
        StartCoroutine("DestroySelf", 8f);
    }

    void Update()
    {
        mytarget = GameObject.FindGameObjectWithTag("Player");
        targetPos = mytarget.transform.position;
        if (mytarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos + new Vector3(Random.Range(-1.2f, 1.2f), Random.Range(-1.5f, 1.5f), 0), mySpeed * Time.deltaTime);
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetPos), Time.deltaTime * 500f);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position, mySpeed * Time.deltaTime);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        CharacterController2D opponent = collision.GetComponent<CharacterController2D>();
        if (opponent != null)
        {
            opponent.ArchieDamage();
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
