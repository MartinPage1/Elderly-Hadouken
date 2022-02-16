using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonSpawner : MonoBehaviour
{
    public GameObject[] objects;                // The prefab to be spawned.
    public float spawnTime = 6f;            // How long between each spawn.
    private Vector3 spawnPosition;
    public bool left = false;
    public float rangeA = 10f;
    public float rangeB = 20f;
    // Use this for initialization
    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
       
        if (left == false)
        {
            spawnTime = Random.Range(10, 20);
            Invoke("Spawn", spawnTime);
        }
        else
        {
            spawnTime = Random.Range(10, 20);
            Invoke("Spawn2", spawnTime);
        }
    }

    void Spawn()
    {
        spawnTime = Random.Range(rangeA, rangeB);
        Invoke("Spawn", spawnTime);
        spawnPosition.x = -10;
        spawnPosition.y = Random.Range(2.75f, 4.55f);
        spawnPosition.z = 0f;

        Instantiate(objects[UnityEngine.Random.Range(0, objects.Length - 1)], spawnPosition, Quaternion.identity);
    }
    void Spawn2()
    {
        spawnTime = Random.Range(rangeA, rangeB);
        Invoke("Spawn2", spawnTime);
        spawnPosition.x = 10;
        spawnPosition.y = Random.Range(2.75f, 4.55f);
        spawnPosition.z = 0f;

        Instantiate(objects[UnityEngine.Random.Range(0, objects.Length - 1)], spawnPosition, Quaternion.identity);
    }
}
