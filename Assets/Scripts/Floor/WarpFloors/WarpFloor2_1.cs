using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpFloor2_1 : MonoBehaviour
{
    private bool WarpFlag = true;
    private string ModeOn = "Warp2_1On";
    private string ModeOff = "Warp2_1Off";


    public void Warp2_1Event(){
        Debug.Log("イベント検知");

        if(WarpFlag == false){
        this.tag = ModeOn;
        WarpFlag = true;
        Debug.Log (WarpFlag);
        }

        else if(WarpFlag == true){
            this.tag = ModeOff;
            WarpFlag = false;
            Debug.Log (WarpFlag);
        }
    }

}