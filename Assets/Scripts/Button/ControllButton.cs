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
        //�X�e�[�W���I��������playing��stopping��false�ɂ���B
    }

    //�Đ��{�^���������ꂽ�Ƃ��Ɏ��s
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
                Debug.Log("���ɍĐ���");
            }
        }
        else
        {
            playing = true;
            BC_T.tag = "start";
        }
    }

    //�X�g�b�v�{�^���������ꂽ�Ƃ��Ɏ��s
    public void StopEvent()
    {
        if (playing == true)
        {
            stopping = true;
            BC_T.tag = "stop";
        }
        else
        {
            Debug.Log("�Đ����ł͂Ȃ�");
        }
    }


    //���Z�b�g�{�^���������ꂽ�Ƃ��Ɏ��s
    public void ResetEvent()
    {
        if (playing == true)
        {
            Debug.Log("�Đ����ɂ��A�ύX�s��");
        }
        else
        {
            Debug.Log("Reset");
            BC_T.tag = "reset";
        }
    }
}
