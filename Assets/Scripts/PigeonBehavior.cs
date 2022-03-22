using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonBehavior : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed = 7f;
    public float die = 4f;
    public bool left = false;
    public GameObject pap;
    public float papSpotY = -1f;
    public float papFrequencyA = 1f;
    public float papFrequencyB = 4f;

    private float lastDamagedAt = -9999f;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine("DestroySelf", die);
        Invoke("Pap", Random.Range(papFrequencyA, papFrequencyB));
    }

    // Update is called once per frame
    void Update()
    {
        if (left == false)
        {
            transform.position += new Vector3(1f, 0.0f, 0.0f) * Time.deltaTime * speed;
        }
        else
        {
            transform.position += new Vector3(-1f, 0.0f, 0.0f) * Time.deltaTime * speed;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        CharacterTwoController2D opponent = collision.GetComponent<CharacterTwoController2D>();
        CharacterController2D opponent2 = collision.GetComponent<CharacterController2D>();
        if (Time.time > lastDamagedAt + 4f)
        {
            if (opponent != null)
            {
                lastDamagedAt = Time.time;
                opponent.PigeonDamage();
                //StartCoroutine("DestroySelf", 2f);
            }
            if (opponent2 != null)
            {
                opponent2.PigeonDamage();
                lastDamagedAt = Time.time;
                //StartCoroutine("DestroySelf", 2f);
            }
        }
    }
    void Pap()
    {
        Instantiate(pap, transform.position + new Vector3(0, papSpotY, 0), transform.rotation);
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
