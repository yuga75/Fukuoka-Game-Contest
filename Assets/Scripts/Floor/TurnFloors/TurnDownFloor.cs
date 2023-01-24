using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnDownFloor : MonoBehaviour
{
    private bool TurnFlag = true;
    private string ModeOn = "TurnDownOn";
    private string ModeOff = "TurnDownOff";


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
