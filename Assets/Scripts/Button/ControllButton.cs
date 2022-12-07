using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControllButton : MonoBehaviour
{
    public static bool playing;
    public static bool stopping;
    public GameObject BC_T;

    // Start is called before the first frame update
    void Start()
    {
        playing = false;
        stopping = false;
    }

    // Update is called once per frame
    void Update()
    {
        //ステージが終了したらplayingとstoppingをfalseにする。
    }

    //再生ボタンが押されたときに実行
    public void PlayEvent()
    {
        if (playing == true)
        {
            if (stopping == true)
            {
                stopping = false;
                BC_T.tag = "start";
            }
            else
            {
                Debug.Log("既に再生中");
            }
        }
        else
        {
            playing = true;
            BC_T.tag = "start";
        }
    }

    //ストップボタンが押されたときに実行
    public void StopEvent()
    {
        if (playing == true)
        {
            stopping = true;
            BC_T.tag = "stop";
        }
        else
        {
            Debug.Log("再生中ではない");
        }
    }


    //リセットボタンが押されたときに実行
    public void ResetEvent()
    {
        if (playing == true)
        {
            Debug.Log("再生中につき、変更不可");
        }
        else
        {
            Debug.Log("Reset");
            BC_T.tag = "reset";
        }
    }
}
