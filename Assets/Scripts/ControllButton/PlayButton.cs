using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public static bool playing;

    public void PlayEvent()
    {
        if(playing == true)
        {
            if(StopButton.stopping == true)
            {
                StopButton.stopping = false; 
                //tagをPlayに変更
            }
            else
            {
                Debug.Log("既に再生中");
            }
        }
        else
        {
            playing = true;
            //tagをplayに変更
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playing = false;
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームが終了したらplayingとstopingをfalseに変更
    }
}
