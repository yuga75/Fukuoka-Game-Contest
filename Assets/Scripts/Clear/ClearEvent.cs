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

    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GameObject.Find("Player");
        pt = PlayerObject.GetComponent<PlayerTest>();
        GameClear.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //クリア後、ClearUIを表示する
        if(pt.playerState == "Cleared")
        {
            Debug.Log("検知");
            GameClear.enabled = true;
        }
    }
}
