using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PapBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine("DestroySelf", 4f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Something")
        {
            Destroy(gameObject);
        }
    }
    private IEnumerator DestroySelf()
    {
        float pauseEndTime = Time.realtimeSinceStartup + 8f;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Destroy(gameObject);
    }
}
