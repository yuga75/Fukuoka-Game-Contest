using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControllButton : MonoBehaviour
{
    public static bool play = false;
    public static bool stop = false;
    public static bool fast = false;
    public static bool reset = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //ステージが終了したらplayingとstoppingをfalseにする。
    }

    //再生ボタンが押されたときに実行
    public void PlayEvent()
    {
        play = true;
        stop = false;
        Debug.Log("play:" + play);
        Debug.Log("stop:" + stop);
        Debug.Log("fast:" + fast);
        Debug.Log("reset:" + reset);
    }

    //ストップボタンが押されたときに実行
    public void StopEvent()
    {
        play = false;
        stop = true;
        Debug.Log("play:" + play);
        Debug.Log("stop:" + stop);
        Debug.Log("fast:" + fast);
        Debug.Log("reset:" + reset);
    }

    public void FastForwardEvent()
    {
        if (fast == true)
        {
            fast = false;
            Debug.Log("play:" + play);
            Debug.Log("stop:" + stop);
            Debug.Log("fast:" + fast);
            Debug.Log("reset:" + reset);
        }
        else
        {
            fast = true;
            Debug.Log("play:" + play);
            Debug.Log("stop:" + stop);
            Debug.Log("fast:" + fast);
            Debug.Log("reset:" + reset);
        }
    }

    //リセットボタンが押されたときに実行
    public void ResetEvent()
    {
        reset = true;
        play = false;
        stop = false;
        fast = false;
        Debug.Log("play:" + play);
        Debug.Log("stop:" + stop);
        Debug.Log("fast:" + fast);
        Debug.Log("reset:" + reset);
    }
}
