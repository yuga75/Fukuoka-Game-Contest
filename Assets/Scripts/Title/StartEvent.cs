using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartEvent : MonoBehaviour
{
    
    public void StartSwitchScene()
    {
        PlayerPrefs.SetInt("Tutorial", 0);
        SceneManager.LoadScene("OP", LoadSceneMode.Single);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
