using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    public GameObject ghost;                // The enemy prefab to be spawned.
    public float spawnTime = 10f;            // How long between each spawn.

    public int objectSizeMax = 2;
    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }
    void MakeNewObject()
    {
        var numRandom = Random.Range(.5f, 2f); // or you could use Random.Range(0,objectSizeMax)+0.5;
        GameObject objectMade = Instantiate(ghost, transform.position, transform.rotation);
        objectMade.transform.localScale = Vector3.one * numRandom;
    }
    void Spawn()
    {
        var numRandom = Random.Range(.5f, 2f);
        var xPos = Random.Range(-7, 8);
        var  yPos = Random.Range(-7, 8);
        GameObject objectMade = Instantiate(ghost, new Vector3(xPos, yPos, -2), Quaternion.identity);
        objectMade.transform.localScale = Vector3.one * numRandom;
    }
}
