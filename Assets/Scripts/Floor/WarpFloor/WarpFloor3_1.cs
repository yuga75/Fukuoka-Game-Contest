using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpFloor3_1 : MonoBehaviour
{
    private bool WarpFlag = false;
    private string ModeOn = "Warp3_1On";
    private string ModeOff = "Warp3_1Off";


    public void Warp3_1Event(){
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