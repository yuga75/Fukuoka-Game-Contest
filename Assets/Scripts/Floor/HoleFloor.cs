
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleFloor : MonoBehaviour
{
    private bool HoleFlag = true;
    private string ModeOn = "HoleOn";
    private string ModeOff = "HoleOff";


    public void StopEvent(){

        if(HoleFlag == false){
        this.tag = ModeOn;
        HoleFlag = true;
        }

        else if(HoleFlag == true){
            this.tag = ModeOff;
            HoleFlag = false;
            Debug.Log(this.tag);
        }
    }

}