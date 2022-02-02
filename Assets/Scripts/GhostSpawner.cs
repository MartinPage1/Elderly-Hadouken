using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    public GameObject ghost;                // The enemy prefab to be spawned.
    public float spawnTime = 18f;            // How long between each spawn.
    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
       var xPos = Random.Range(-7, 8);
       var  yPos = Random.Range(-7, 8);
       Instantiate(ghost, new Vector3(xPos, yPos, -2), Quaternion.identity);
    }
}
