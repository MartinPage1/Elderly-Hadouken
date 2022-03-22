using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightningSpawner : MonoBehaviour
{
    public GameObject[] objects;
    public float spawnTime = 6f;            // How long between each spawn.
    private Vector3 spawnPosition;
    public float rangeA = 2f;
    public float rangeB = 7f;
    // Use this for initialization
    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.

         spawnTime = Random.Range(2, 5);
         Invoke("Spawn", spawnTime);
    }

    void Spawn()
    {
        spawnTime = Random.Range(rangeA, rangeB);
        Invoke("Spawn", spawnTime);
        spawnPosition.x = Random.Range(1.2f, 18f);
        spawnPosition.y = 10.2f; //Random.Range(2.75f, 4.55f);
        spawnPosition.z = 0f;

        Instantiate(objects[UnityEngine.Random.Range(0, objects.Length - 1)], spawnPosition, Quaternion.identity);
    }
}
