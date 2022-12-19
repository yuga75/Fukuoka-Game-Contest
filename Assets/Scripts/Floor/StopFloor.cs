using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleFloor : MonoBehaviour
{
    private bool StopFlag = false;
    private string ModeOn = "StopOn";
    private string ModeOff = "StopOff";


    public void StopEvent(){
        Debug.Log("イベント検知");

        if(StopFlag == false){
        this.tag = ModeOn;
        StopFlag = true;
        Debug.Log (StopFlag);
        }

        else if(StopFlag == true){
            this.tag = ModeOff;
            StopFlag = false;
            Debug.Log (StopFlag);
        }
    }

}