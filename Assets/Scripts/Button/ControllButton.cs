using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ControllButton : MonoBehaviour
{
    public bool play = false;
    public bool stop = false;
    public bool fast = false;
    public bool reset = false;

    private float ResetCount = 0;
    private float OutResetLimit = 250;


    private GameObject PlayerObject;
    private PlayerTest pt;

    public GameObject ResetButton;
    MainEvent mainEvent;

    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GameObject.Find("Player");
        pt = PlayerObject.GetComponent<PlayerTest>();

        ResetButton = GameObject.Find("ResetButton");
        mainEvent = ResetButton.GetComponent<MainEvent>();
    }

    // Update is called once per frame
    public void Update()
    {
        //resetがtrueになるとシーンを再読み込み。
        if (reset == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        //playerがアウトになったときリセットの処理を実行する
        if(pt.playerState == "humanFailed" || pt.playerState == "wolfFailed")
        {
            ResetCount += 1;
            Debug.Log(ResetCount);
            if (ResetCount >= OutResetLimit)
            {
                mainEvent.ResetEvent();
                Debug.Log("play:" + play);
                Debug.Log("stop:" + stop);
                Debug.Log("fast:" + fast);
                Debug.Log("reset:" + reset);
                ResetCount = 0;
            }
        }
    }
}
