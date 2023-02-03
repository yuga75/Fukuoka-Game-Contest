using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearEvent : MonoBehaviour
{
    public Renderer GameClear;

    public GameObject PlayerObject;
    PlayerTest pt;

    bool OneTime;

    string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GameObject.Find("Player");
        pt = PlayerObject.GetComponent<PlayerTest>();
        GameClear.enabled = false;
        sceneName = SceneManager.GetActiveScene().name;
        OneTime= true;
    }

    // Update is called once per frame
    void Update()
    {
        //クリア後、ClearUIを表示する
        if(pt.playerState == "Cleared")
        {
            GameClear.enabled = true;

            if (sceneName == "Tutorial" && OneTime == true)
            {
                PlayerPrefs.SetInt("Tutorial", 1);
                PlayerPrefs.SetInt("Stage1", 0);
                PlayerPrefs.SetInt("Stage2", 0);
                PlayerPrefs.SetInt("Stage3", 0);
                PlayerPrefs.SetInt("Stage4", 0);
                PlayerPrefs.SetInt("Stage5", 0);
                PlayerPrefs.SetInt("Stage6", 0);
                PlayerPrefs.SetInt("Stage7", 0);
                PlayerPrefs.SetInt("Stage8", 0);
                PlayerPrefs.SetInt("Stage9", 0);
                PlayerPrefs.SetInt("Stage10", 0);
                PlayerPrefs.SetInt("Story1", 0);
                PlayerPrefs.SetInt("Story2", 0);
                PlayerPrefs.SetInt("Story3", 0);
            }
            if (sceneName == "Stage1" && OneTime == true)
            {
                PlayerPrefs.SetInt("Stage1", 1);
            }
            if (sceneName == "Stage2" && OneTime == true)
            {
                PlayerPrefs.SetInt("Stage2", 1);
            }
            if (sceneName == "Stage3" && OneTime == true)
            {
                PlayerPrefs.SetInt("Stage3", 1);
            }
            if (sceneName == "Stage4" && OneTime == true)
            {
                PlayerPrefs.SetInt("Stage4", 1);
            }
            if (sceneName == "Stage5" && OneTime == true)
            {
                PlayerPrefs.SetInt("Stage5", 1);
            }
            if (sceneName == "Stage6" && OneTime == true)
            {
                PlayerPrefs.SetInt("Stage6", 1);
            }
            if (sceneName == "Stage7" && OneTime == true)
            {
                PlayerPrefs.SetInt("Stage7", 1);
            }
            if (sceneName == "Stage8" && OneTime == true)
            {
                PlayerPrefs.SetInt("Stage8", 1);
            }
            if (sceneName == "Stage9" && OneTime == true)
            {
                PlayerPrefs.SetInt("Stage9", 1);
            }
            if (sceneName == "Stage10" && OneTime == true)
            {
                PlayerPrefs.SetInt("Stage10", 1);
            }
            PlayerPrefs.Save();
            Debug.Log("Saved");
            Invoke("ChangeScene", 2.5f);
            OneTime = false;
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("hogehoge");
    }
}
