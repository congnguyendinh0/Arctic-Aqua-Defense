using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
public class UI : MonoBehaviour
{
    public static UI ui;

    public void Awake()
    {
        ui = this;
    }

    public string menus;
    public string level;
    
    public TMP_Text value;
    public Speed speedScript;
    public TMP_Text life;
    public GameObject upgrade;
    public GameObject won;
    public GameObject lost;
    public GameObject pause;
    public float doubleClickTimeThreshold = 0.5f;

    private float lastClickTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check for Alt + F4 or Alt + Q key press
        if ((Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) &&
            (Input.GetKeyDown(KeyCode.F4) || Input.GetKey(KeyCode.Q)))
        {
            // Call the QuitGame function
            QuitGame();
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            float currentTime = Time.time;

            if (currentTime - lastClickTime <= doubleClickTimeThreshold)
            {
               Close();

                // Reset last click time to avoid detecting multiple double-clicks
                lastClickTime = 0f;
            }
            else
            {
                // Single click
                lastClickTime = currentTime;
            }
        }
    }
    public void Back()
    {
        if (pause.activeSelf == false)
        {
            // If the pause menu is not active, show it and set time scale to 0f
            pause.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            // If the pause menu is active, hide it and set time scale based on Speed class
            pause.SetActive(false);

            // Adjust time scale based on the state of the Speed class
            if (speedScript != null && speedScript.isSpeededUp)
            {
                // If Speed class is in 2x speed, set time scale to 2f
                Time.timeScale = 1f;
            }
            else
            {
                // If Speed class is in 1x speed or the script is not present, set time scale to 1f
                Time.timeScale = 2f;
            }
        }
    }


    public void Levels()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(level);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menus);
    }

    public void QuitGame()  
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Next()
    {
        SceneManager.LoadScene(GameManager.gameManager.next);
    }

    public void Open()
    {
        upgrade.SetActive(true);
    }
    public void Close()
    {
        upgrade.SetActive(false);
        PlayerManager.playerManager.theTower = null;
        PlayerManager.playerManager.effect.SetActive(false);
    }
}
