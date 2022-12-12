using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEvent : MonoBehaviour
{
    private GameObject ControllButtonObject;
    public ControllButton cb;

    private void Start()
    {
        ControllButtonObject = GameObject.Find("ControllButton(empty)");
        cb = ControllButtonObject.GetComponent<ControllButton>();
    }
        //再生ボタンが押されたときに実行
        public void PlayEvent()
    {
        cb.play = true;
        cb.stop = false;
        Debug.Log("play:" + cb.play);
        Debug.Log("stop:" + cb.stop);
        Debug.Log("fast:" + cb.fast);
        Debug.Log("reset:" + cb.reset);
    }   

    //ストップボタンが押されたときに実行
    public void StopEvent()
    {
        cb.play = false;
        cb.stop = true;
        Debug.Log("play:" + cb.play);
        Debug.Log("stop:" + cb.stop);
        Debug.Log("fast:" + cb.fast);
        Debug.Log("reset:" + cb.reset);
    }

    //早送りボタンが押されたときに実行
    public void FastForwardEvent()
    {
        //早送りボタンが2回押されたときは、false
        if (cb.fast == true)
        {
            cb.fast = false;
            Debug.Log("play:" + cb.play);
            Debug.Log("stop:" + cb.stop);
            Debug.Log("fast:" + cb.fast);
            Debug.Log("reset:" + cb.reset);
        }
        else
        {
            cb.fast = true;
            Debug.Log("play:" + cb.play);
            Debug.Log("stop:" + cb.stop);
            Debug.Log("fast:" + cb.fast);
            Debug.Log("reset:" + cb.reset);
        }
    }

    //リセットボタンが押されたときに実行
    public void ResetEvent()
    {
        cb.reset = true;
        cb.play = false;
        cb.stop = false;
        cb.fast = false;
        Debug.Log("play:" + cb.play);
        Debug.Log("stop:" + cb.stop);
        Debug.Log("fast:" + cb.fast);
        Debug.Log("reset:" + cb.reset);
    }
}
