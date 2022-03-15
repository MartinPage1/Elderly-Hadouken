using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //public static GameManager Instance;

    public int selectedChar1 = 0;
    public int selectedChar2 = 0;

    public GameObject playerOnePrefab;
    public GameObject playerTwoPrefab;
    public GameObject albertPrefab;
    public GameObject bettyPrefab;
    public GameObject archiPrefab;
    public GameObject gertiePrefab;
    public GameObject richardPrefab;
    public GameObject edithPrefab;


    public GameObject albert2Prefab;
    public GameObject betty2Prefab;
    public GameObject archi2Prefab;
    public GameObject gertie2Prefab;
    public GameObject richard2Prefab;
    public GameObject edith2Prefab;

    public GameObject currentPlayerOne;
    public GameObject currentPlayerTwo;

    public GameObject albertSuperP1;
    public GameObject albertSuperP2;
    public GameObject archieSuperBirdOneP1;
    public GameObject archieSuperBirdTwoP1;
    public GameObject archieSuperBirdThreeP1;
    public GameObject archieSuperBirdOneP2;
    public GameObject archieSuperBirdTwoP2;
    public GameObject archieSuperBirdThreeP2;

    public TMP_Text playerOneHP;
    public TMP_Text playerTwoHP;
    public TMP_Text playerOnePP;
    public TMP_Text playerTwoPP;
    public TMP_Text playerOneWins;
    public TMP_Text playerTwoWins;
    public float healthP1;
    public float healthP2;
    public float powerP1;
    public float powerP2;
    private bool gameOver = false;

    public int Getint(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
    }

    void Awake()
    {
        selectedChar1 = Getint("char1");
        selectedChar2 = Getint("char2");

        //if (Instance == null)
       // {
       //     DontDestroyOnLoad(gameObject);
        //    Instance = this;
       // }
       // else if (Instance != this)
       // {
       //     Destroy(gameObject);
       // }
        //Player 1 player selected spawn
        if (selectedChar1 == 1)
        {
            Instantiate(albertPrefab, new Vector3(-7.8f, -2.8f, 0), Quaternion.identity);
        }
        if (selectedChar1 == 2)
        {
            Instantiate(archiPrefab, new Vector3(-7.8f, -2.8f, 0), Quaternion.identity);
        }
        if (selectedChar1 == 3)
        {
            Instantiate(richardPrefab, new Vector3(-7.8f, -2.8f, 0), Quaternion.identity);
        }
        if (selectedChar1 == 4)
        {
            Instantiate(bettyPrefab, new Vector3(-7.8f, -2.8f, 0), Quaternion.identity);
        }
        if (selectedChar1 == 5)
        {
            Instantiate(gertiePrefab, new Vector3(-7.8f, -2.8f, 0), Quaternion.identity);
        }
        if (selectedChar1 == 6)
        {
            Instantiate(edithPrefab, new Vector3(-7.8f, -2.8f, 0), Quaternion.identity);
        }

        //Player 2 character Selected Spawn
        if (selectedChar2 == 1)
        {
            Instantiate(archiPrefab, new Vector3(8f, -2.8f, 0), Quaternion.identity);
        }
        if (selectedChar2 == 2)
        {
            Instantiate(archiPrefab, new Vector3(8f, -2.8f, 0), Quaternion.identity);
        }
        if (selectedChar2 == 3)
        {
            Instantiate(archiPrefab, new Vector3(8f, -2.8f, 0), Quaternion.identity);
        }
        if (selectedChar2 == 4)
        {
            Instantiate(archiPrefab, new Vector3(8f, -2.8f, 0), Quaternion.identity);
        }
        if (selectedChar2 == 5)
        {
            Instantiate(archiPrefab, new Vector3(8f, -2.8f, 0), Quaternion.identity);
        }
        if (selectedChar2 == 6)
        {
            Instantiate(archiPrefab, new Vector3(8f, -2.8f, 0), Quaternion.identity);
        }
        Time.timeScale = 1;
    }
   
    // Update is called once per frame
    void Update()
    {

        selectedChar1 = Getint("char1");
        selectedChar2 = Getint("char2");
        currentPlayerOne = GameObject.FindGameObjectWithTag("Player");
        currentPlayerTwo = GameObject.FindGameObjectWithTag("Player 2");
        if (Input.GetKeyDown(KeyCode.U))
        {
            selectedChar1 = 1;
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            selectedChar1 = 2;
        }
        if ((Input.GetKey(KeyCode.R)) && (gameOver==true))
        {
            RestartScene();
        } 
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
           Instantiate(albertPrefab, new Vector3(-7.8f, -2.8f, 0), Quaternion.identity);
            Destroy(currentPlayerOne);
            currentPlayerOne = GameObject.FindGameObjectWithTag("Player");
        } 
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
           Instantiate(bettyPrefab, new Vector3(-7.8f, -2.8f, 0), Quaternion.identity);
            Destroy(currentPlayerOne);
            currentPlayerOne = GameObject.FindGameObjectWithTag("Player");
        } 
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
           Instantiate(edithPrefab, new Vector3(-7.8f, -2.8f, 0), Quaternion.identity);
            Destroy(currentPlayerOne);
            currentPlayerOne = GameObject.FindGameObjectWithTag("Player");
        } 
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
           Instantiate(archiPrefab, new Vector3(8f, -2.8f, 0), Quaternion.identity);
            Destroy(currentPlayerTwo);
            currentPlayerTwo = GameObject.FindGameObjectWithTag("Player 2");
        } 
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
           Instantiate(richardPrefab, new Vector3(8f, -2.8f, 0), Quaternion.identity);
            Destroy(currentPlayerTwo);
            currentPlayerTwo = GameObject.FindGameObjectWithTag("Player 2");
        } 
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
           Instantiate(gertiePrefab, new Vector3(8f, -2.8f, 0), Quaternion.identity);
            Destroy(currentPlayerTwo);
            currentPlayerTwo = GameObject.FindGameObjectWithTag("Player 2");
        }
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            SceneManager.LoadScene("HospitalLevel");
        }

        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            SceneManager.LoadScene("NurseryLevel");
        }

        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            SceneManager.LoadScene("ParkLevel");
        }
    }
    public void AlbertsAttackP1()
    {
        Instantiate(albertSuperP1, new Vector3(Random.Range(-4f, 4f), 6f, 0), Quaternion.identity);
    }
    public void AlbertsAttackP2()
    {
        Instantiate(albertSuperP2, new Vector3(Random.Range(-4f, 4f), 6f, 0), Quaternion.identity);
    }
    public void ArchieAttackP1()
    {
        Instantiate(archieSuperBirdOneP1, new Vector3(Random.Range(-4f, 4f), 6f, 0), Quaternion.identity);
    }
    public void ArchieAttackP2()
    {
        Instantiate(archieSuperBirdOneP2, new Vector3(Random.Range(-4f, 4f), 6f, 0), Quaternion.identity);
        Instantiate(archieSuperBirdTwoP2, new Vector3(Random.Range(-4f, 4f), 6f, 0), Quaternion.identity);
        Instantiate(archieSuperBirdThreeP2, new Vector3(Random.Range(-4f, 4f), 6f, 0), Quaternion.identity);
    }
    public void UpdateHealthP1(float health)
    {
        healthP1 = health;
        playerOneHP.text = "" + healthP1;
    }
    public void UpdateHealthP2(float health)
    {        
        healthP2 = health;
        playerTwoHP.text = "" + healthP2;
    }
    public void UpdatePowerP1(float power)
    {
        powerP1 = power;
        playerOnePP.text = "" + powerP1;
    }
    public void UpdatePowerP2(float power)
    {
        powerP2 = power;
        playerTwoPP.text = "" + powerP2;
    }
    public void PlayerTwoDied()
    {
        playerOneWins.gameObject.SetActive(true);
        gameOver = true;
    }
    public void PlayerOneDied()
    {
        playerTwoWins.gameObject.SetActive(true);
        gameOver = true;
    }
    public void RestartScene()
    {
        SceneManager.LoadScene("Scenes/"+SceneManager.GetActiveScene().name);      
    }
}
