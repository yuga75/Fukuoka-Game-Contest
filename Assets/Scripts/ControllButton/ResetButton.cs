using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public void ResetEvent()
    {
        if(PlayButton.playing == true)
        {
            Debug.Log("�Đ����ɂ��A�ύX�s��");
        }
        else
        {
            //Tag��Reset�ɕύX
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
