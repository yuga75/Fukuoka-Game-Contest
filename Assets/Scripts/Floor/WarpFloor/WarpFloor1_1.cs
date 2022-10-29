using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpFloor1_1 : MonoBehaviour
{
    private bool WarpFlag = false;
    private string ModeOn = "Warp1_1On";
    private string ModeOff = "Warp1_1Off";


    public void Warp1_1Event(){
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