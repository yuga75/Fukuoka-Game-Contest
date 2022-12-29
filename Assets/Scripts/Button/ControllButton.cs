using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControllButton : MonoBehaviour
{
    public bool play = false;
    public bool stop = false;
    public bool fast = false;
    public bool reset = false;

    private float ResetCount = 0;
    private float ResetLimit = 20;
    private float OutResetLimit = 1000;

    [SerializeField] GameObject GameClear;

    private GameObject PlayerObject;
    private PlayerTest pt;

    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GameObject.Find("Player");
        pt = PlayerObject.GetComponent<PlayerTest>();
    }

    // Update is called once per frame
    public void Update()
    {
        //resetは20経過でfalseにする。
        if (reset == true)
        {
            ResetCount += 1;
            Debug.Log(ResetCount);
            if (ResetCount >= ResetLimit)
            {
                reset = false;
                Debug.Log("play:" + play);
                Debug.Log("stop:" + stop);
                Debug.Log("fast:" + fast);
                Debug.Log("reset:" + reset);
                ResetCount = 0;
            }
        }
        //ステージが終了したらplayとfastをfalseにする。
        if(GameClear.activeSelf == true)
        {
            play = false;
            fast = false;
        }
        //playerがアウトになったときリセットの処理を実行する
        if(pt.playerState == "humanFailed" || pt.playerState == "wolfFailed")
        {
            ResetCount += 1;
            Debug.Log(ResetCount);
            if (ResetCount >= OutResetLimit)
            {
                reset = true;
                Debug.Log("play:" + play);
                Debug.Log("stop:" + stop);
                Debug.Log("fast:" + fast);
                Debug.Log("reset:" + reset);
                ResetCount = 0;
            }
        }
    }
}
