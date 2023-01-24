using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnUpFloor : MonoBehaviour
{
    private bool TurnFlag = true;
    private string ModeOn = "TurnUpOn";
    private string ModeOff = "TurnUpOff";


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
