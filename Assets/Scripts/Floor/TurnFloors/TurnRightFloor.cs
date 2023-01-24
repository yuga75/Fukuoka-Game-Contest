using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnRightFloor : MonoBehaviour
{
    private bool TurnFlag = true;
    private string ModeOn = "TurnRightOn";
    private string ModeOff = "TurnRightOff";


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
