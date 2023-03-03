using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetReload : MonoBehaviour
{

    string sceneName;
    
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        if(sceneName == "StageSelect")
        {
            PlayerPrefs.SetInt("Reload", 1);
        }
        else if(sceneName != "StageSelect" && PlayerPrefs.GetInt("Reload", 0) == 1)
        {
            PlayerPrefs.SetInt("Reload", 0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        PlayerPrefs.Save();
        Debug.Log("Saved");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
