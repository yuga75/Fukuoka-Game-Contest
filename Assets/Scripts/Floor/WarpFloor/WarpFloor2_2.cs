using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpFloor2_2 : MonoBehaviour
{
    private bool WarpFlag = false;
    private string ModeOn = "Warp2_2On";
    private string ModeOff = "Warp2_2Off";


    public void Warp2_2Event(){
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