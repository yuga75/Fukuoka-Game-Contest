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
                //tag��Play�ɕύX
            }
            else
            {
                Debug.Log("���ɍĐ���");
            }
        }
        else
        {
            playing = true;
            //tag��play�ɕύX
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
        //�Q�[�����I��������playing��stoping��false�ɕύX
    }
}
