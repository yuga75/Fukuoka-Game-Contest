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
            //tag��Stop�ɕύX
        }
        else
        {
            Debug.Log("�Đ����ł͂Ȃ�");
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
