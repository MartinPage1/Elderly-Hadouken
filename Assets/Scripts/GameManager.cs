using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject playerOnePrefab;
    public GameObject playerTwoPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerOnePrefab, new Vector3(-7.8f, -2.8f, 0), Quaternion.identity);
        Instantiate(playerTwoPrefab, new Vector3(8f, -2.8f, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
