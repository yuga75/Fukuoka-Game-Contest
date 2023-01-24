using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpFloor3_2 : MonoBehaviour
{
    private bool WarpFlag = true;
    private string ModeOn = "Warp3_2On";
    private string ModeOff = "Warp3_2Off";


    public void Warp3_2Event(){
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