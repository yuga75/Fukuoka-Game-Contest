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
        //�Đ��{�^���������ꂽ�Ƃ��Ɏ��s
        public void PlayEvent()
    {
        cb.play = true;
        cb.stop = false;
        Debug.Log("play:" + cb.play);
        Debug.Log("stop:" + cb.stop);
        Debug.Log("fast:" + cb.fast);
        Debug.Log("reset:" + cb.reset);
    }   

    //�X�g�b�v�{�^���������ꂽ�Ƃ��Ɏ��s
    public void StopEvent()
    {
        cb.play = false;
        cb.stop = true;
        Debug.Log("play:" + cb.play);
        Debug.Log("stop:" + cb.stop);
        Debug.Log("fast:" + cb.fast);
        Debug.Log("reset:" + cb.reset);
    }

    //������{�^���������ꂽ�Ƃ��Ɏ��s
    public void FastForwardEvent()
    {
        //������{�^����2�񉟂��ꂽ�Ƃ��́Afalse
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

    //���Z�b�g�{�^���������ꂽ�Ƃ��Ɏ��s
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
