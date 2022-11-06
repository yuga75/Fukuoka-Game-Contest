using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButton : MonoBehaviour
{
    public static bool stopping;

    public void StopEvent()
    {
        if(PlayButton.playing == true)
        {
            stopping = true;
            //tagをStopに変更
        }
        else
        {
            Debug.Log("再生中ではない");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        stopping = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
