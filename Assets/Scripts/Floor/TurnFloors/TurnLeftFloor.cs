using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLeftFloor : MonoBehaviour
{
    private bool TurnFlag = true;
    private string ModeOn = "TurnLeftOn";
    private string ModeOff = "TurnLeftOff";


    public void TurnEvent(){

        if(TurnFlag == false){
        this.tag = ModeOn;
        TurnFlag = true;
        }

        else if(TurnFlag == true){
            this.tag = ModeOff;
            TurnFlag = false;
        }
    }

}
