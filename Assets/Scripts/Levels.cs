using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{


    public string level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void load()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(level);
    }
}
