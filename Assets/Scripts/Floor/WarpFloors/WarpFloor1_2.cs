using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpFloor1_2 : MonoBehaviour
{
    private bool WarpFlag = true;
    private string ModeOn = "Warp1_2On";
    private string ModeOff = "Warp1_2Off";


    public void Warp1_2Event(){
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