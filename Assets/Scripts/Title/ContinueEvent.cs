using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContinueEvent : MonoBehaviour
{
    public Text message;

    public void ContinueSwitchScene()
    {
        if (PlayerPrefs.GetInt("Tutorial", 0) == 0)
        {
            message.text = "セーブデータがありません！";
            StartCoroutine("TextSet");
        }
        else
        {
            SceneManager.LoadScene("StageSelect", LoadSceneMode.Single);
        }
    }

    IEnumerator TextSet()
    {
        yield return new WaitForSeconds(1.0f);
        message.text = "";
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
