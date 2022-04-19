using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectBehavior : MonoBehaviour
{
    public Button nursingHomeSelectButton, hospitalSelectButton, parkSelectButton, startLevelButton;
    public GameObject levelSelectedButton, nursingHome, hospital, park;
    public int levelSelected = 1;

    void Awake()
    {
        nursingHomeSelectButton.onClick.AddListener(() => ButtonClicked(1));
        hospitalSelectButton.onClick.AddListener(() => ButtonClicked(2));
        parkSelectButton.onClick.AddListener(() => ButtonClicked(3));
        startLevelButton.onClick.AddListener(() => ButtonClicked(4));
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("CharacterSelect");
        }
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        SceneManager.LoadScene("LevelSelect");
    }

    void TaskWithParameters(string message)
    {
        //Output this to console when the Button2 is clicked
        Debug.Log(message);
    }

    void ButtonClicked(int buttonNo)
    {
        if(buttonNo == 1)
        {
            levelSelected = 1;
            park.SetActive(false);
            hospital.SetActive(false);
            nursingHome.SetActive(true);
        }
        else if(buttonNo == 2)
        {
            levelSelected = 2;
            park.SetActive(false);
            hospital.SetActive(true); 
            nursingHome.SetActive(false);
        }
        else if(buttonNo == 3)
        {
            levelSelected = 3;
            park.SetActive(true);
            hospital.SetActive(false);
            nursingHome.SetActive(false);
        }
        else if (buttonNo == 4)
        {
            if (levelSelected == 1)
            {
                SceneManager.LoadScene("NurseryLevel");
            }
            else if (levelSelected == 2)
            {
                SceneManager.LoadScene("HospitalLevel");
            }
            else if (levelSelected == 3)
            {
                SceneManager.LoadScene("ParkLevel");
            }

        }
    }
}
