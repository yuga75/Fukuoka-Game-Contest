using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnFloor : MonoBehaviour
{
    private bool TurnFlag = false;
    private string ModeOn = "TurnOn";
    private string ModeOff = "TurnOff";


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
