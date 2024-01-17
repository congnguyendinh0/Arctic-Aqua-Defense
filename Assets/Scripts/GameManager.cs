using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager gameManager;

    public void Awake()
    {
        gameManager = this;
    }

    public bool isLive;
    private bool _won;
    public ShipBase theBase;
    public List<EHealth> enemies = new List<EHealth>();
    public Wave wave;
    public SpawnerTest spawner;
    public string next;
    void Start()
    {
        theBase = FindObjectOfType<ShipBase>();
        spawner = FindObjectOfType<SpawnerTest>();
        if (SceneManager.GetActiveScene().name == "Hard")
        {
            wave = FindObjectOfType<Wave>();
        }
      
        isLive = true;
    }
    void SaveGameStatus()
    {
        string saveFilePath = Application.persistentDataPath + "/gameStatusVer2.json";

        // Create a JSON object with the game status
        GameStatusData gameStatusData = new GameStatusData
        {
            status = true
        };

        // Convert the object to a JSON string
        string json = JsonUtility.ToJson(gameStatusData);

        // Write the JSON string to a file
        File.WriteAllText(saveFilePath, json);

        Debug.Log("Game status saved!");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager)
        {
            if (theBase.curHealth <= 0)
            {
                isLive = false;
                _won = false;

               UI.ui.lost.SetActive(true);
            }
            // WON GAME BELOW Level Easy (Easy Scene)
            if (enemies.Count == 0 && spawner.amount == 0 && !_won)
            {
                isLive = false;
                _won = true;

                UI.ui.won.SetActive(true);
                SaveGameStatus();
            }

            if (!isLive)
            {
                UI.ui.lost.SetActive(!_won);
                UI.ui.won.SetActive(_won);
            }
            // WON GAME BELOW Level Hard (Hard Scene)
            if (SceneManager.GetActiveScene().name == "Hard")
            {
                if (wave.spawn == false && !_won && enemies.Count == 0)
                {
                    isLive = false;
                    _won = true;

                    UI.ui.won.SetActive(true);
                }
            }

        }
    }
}

[Serializable]
public class GameStatusData
{
    public bool status;
}
