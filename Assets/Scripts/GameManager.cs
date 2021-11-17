using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerOnePrefab;
    public GameObject playerTwoPrefab;
    public GameObject albertPrefab;
    public GameObject bettyPrefab;
    public GameObject archiPrefab;
    public GameObject gertiePrefab;
    public GameObject richardPrefab;
    public GameObject edithPrefab;

    public GameObject currentPlayerOne;
    public GameObject currentPlayerTwo;

    public GameObject albertSuperP1;
    public GameObject albertSuperP2;
    public GameObject archieSuperP1;
    public GameObject archieSuperP2;

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

    // Start is called before the first frame update
    void Start()
    {
        //playerOneHP = GameObject.Find("PlayerOneHealth").GetComponent<TMPro.TextMeshProUGUI>().text;
        Time.timeScale = 1;
        Instantiate(playerOnePrefab, new Vector3(-7.8f, -2.8f, 0), Quaternion.identity);
        Instantiate(playerTwoPrefab, new Vector3(8f, -2.8f, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        currentPlayerOne = GameObject.FindGameObjectWithTag("Player");
        currentPlayerTwo = GameObject.FindGameObjectWithTag("Player 2");
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
    }
    public void AlbertsAttackP1()
    {
        Instantiate(albertSuperP1, new Vector3(Random.Range(-4f, 4f), 6f, 0), Quaternion.identity);
    }
    public void AlbertsAttackP2()
    {
        Instantiate(albertSuperP2, new Vector3(Random.Range(-4f, 4f), 6f, 0), Quaternion.identity);
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
