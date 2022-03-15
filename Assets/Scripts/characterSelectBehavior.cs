using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class characterSelectBehavior : MonoBehaviour
{
    public Button albertButton, archieButton, richardButton, bettyButton, gertieButton, edithButton, levelSelectButtonUse;

    //public GameManager gM;
    public int selectedChar1, selectedChar2;
    public GameObject levelSelectButton, albert1, archie1, richard1, betty1, gertie1, edith1, albert2, archie2, richard2, betty2, gertie2, edith2;


    public bool p1Selecting = true;


    public void SetInt(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
    }

    public int Getint(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
    }

    void Start()
    {
        selectedChar1 = 0;
        selectedChar2 = 0;
        //gM = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (p1Selecting == true)
        {
            //albertButton.onClick.AddListener(TaskOnClick);
            albertButton.onClick.AddListener(() => ButtonClicked(1));
            archieButton.onClick.AddListener(() => ButtonClicked(2));
            richardButton.onClick.AddListener(() => ButtonClicked(3));
            bettyButton.onClick.AddListener(() => ButtonClicked(4));
            gertieButton.onClick.AddListener(() => ButtonClicked(5));
            edithButton.onClick.AddListener(() => ButtonClicked(6));
        }
        else if (p1Selecting == false)
        {
            albertButton.onClick.AddListener(() => ButtonClicked(1));
            archieButton.onClick.AddListener(() => ButtonClicked(2));
            richardButton.onClick.AddListener(() => ButtonClicked(3));
            bettyButton.onClick.AddListener(() => ButtonClicked(4));
            gertieButton.onClick.AddListener(() => ButtonClicked(5));
            edithButton.onClick.AddListener(() => ButtonClicked(6));
        }

        //m_YourSecondButton.onClick.AddListener(delegate { TaskWithParameters("Hello"); });
 
       // m_YourThirdButton.onClick.AddListener(TaskOnClick);
    }
    private void Update()
    {
        SetInt("char1", selectedChar1);

        SetInt("char2", selectedChar2);
       
        if (Input.GetKey(KeyCode.Escape) && p1Selecting == true && selectedChar1 > 0)
        {
            albert1.SetActive(false);
            archie1.SetActive(false);
            richard1.SetActive(false);
            betty1.SetActive(false);
            gertie1.SetActive(false);
            edith1.SetActive(false);
            selectedChar1 = 0;
        }


        else if (Input.GetKey(KeyCode.Escape) && p1Selecting == false)
        {
            albert2.SetActive(false);
            archie2.SetActive(false);
            richard2.SetActive(false);
            betty2.SetActive(false);
            gertie2.SetActive(false);
            edith2.SetActive(false);
            selectedChar2 = 0;
            levelSelectButton.SetActive(false);
            p1Selecting = true;
        }
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        selectedChar1 = 1;
    }

    void ButtonClicked(int buttonNo)
    {
        Debug.Log("Button clicked = " + buttonNo);
        if (buttonNo == 1)
        {
            if (p1Selecting == true) {
                selectedChar1 = 1;
                archie1.SetActive(false);
                richard1.SetActive(false);
                betty1.SetActive(false);
                gertie1.SetActive(false);
                edith1.SetActive(false);
                albert1.SetActive(true);
                p1Selecting = false;
            }
            else
            {
                selectedChar2 = 1;
                albert2.SetActive(true);
                archie2.SetActive(false);
                richard2.SetActive(false);
                betty2.SetActive(false);
                gertie2.SetActive(false);
                edith2.SetActive(false);
                levelSelectButton.SetActive(true);
            }
        }
        if (buttonNo == 2)
        {
            if (p1Selecting == true)
            {
                selectedChar1 = 2;
                archie1.SetActive(true);
                albert1.SetActive(false);
                richard1.SetActive(false);
                betty1.SetActive(false);
                gertie1.SetActive(false);
                edith1.SetActive(false);
                p1Selecting = false;
            }
            else
            {
                selectedChar2 = 2;
                albert2.SetActive(false);
                richard2.SetActive(false);
                betty2.SetActive(false);
                gertie2.SetActive(false);
                edith2.SetActive(false);
                archie2.SetActive(true);
                levelSelectButton.SetActive(true);
            }
        }
        if (buttonNo == 3)
        {
            if (p1Selecting == true)
            {
                selectedChar1 = 3;
                albert1.SetActive(false);
                archie1.SetActive(false);
                betty1.SetActive(false);
                gertie1.SetActive(false);
                edith1.SetActive(false);
                richard1.SetActive(true);
                p1Selecting = false;
            }
            else
            {
                selectedChar2 = 3;
                albert2.SetActive(false);
                archie2.SetActive(false);
                betty2.SetActive(false);
                gertie2.SetActive(false);
                edith2.SetActive(false);
                richard2.SetActive(true);
                levelSelectButton.SetActive(true);
            }
        }
        if (buttonNo == 4)
        {
            if (p1Selecting == true)
            {
                selectedChar1 = 4;
                albert1.SetActive(false);
                archie1.SetActive(false);
                richard1.SetActive(false);
                gertie1.SetActive(false);
                edith1.SetActive(false);
                betty1.SetActive(true);
                p1Selecting = false;
            }
            else
            {
                selectedChar2 = 4;
                albert2.SetActive(false);
                archie2.SetActive(false);
                richard2.SetActive(false);
                gertie2.SetActive(false);
                edith2.SetActive(false);
                betty2.SetActive(true);
                levelSelectButton.SetActive(true);
            }
        }
        if (buttonNo == 5)
        {
            if (p1Selecting == true)
            {
                selectedChar1 = 5;
                gertie1.SetActive(true);
                albert1.SetActive(false);
                archie1.SetActive(false);
                richard1.SetActive(false);
                betty1.SetActive(false);
                edith1.SetActive(false);
                p1Selecting = false;
            }
            else
            {
                selectedChar2 = 5;
                albert2.SetActive(false);
                archie2.SetActive(false);
                richard2.SetActive(false);
                betty2.SetActive(false);
                edith2.SetActive(false);
                gertie2.SetActive(true);
                levelSelectButton.SetActive(true);
            }
        }
        if (buttonNo == 6)
        {
            if (p1Selecting == true)
            {
                selectedChar1 = 6;
                albert1.SetActive(false);
                archie1.SetActive(false);
                richard1.SetActive(false);
                betty1.SetActive(false);
                gertie1.SetActive(false);
                edith1.SetActive(true);
                p1Selecting = false;
            }
            else
            {
                selectedChar2 = 6;
                albert2.SetActive(false);
                archie2.SetActive(false);
                richard2.SetActive(false);
                betty2.SetActive(false);
                gertie2.SetActive(false);
                edith2.SetActive(true);
                levelSelectButton.SetActive(true);
            }
        }





    }
}
