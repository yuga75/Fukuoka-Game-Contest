using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayFloor : MonoBehaviour
{
    public static DayFloor instance;
    private bool DayFlag = false;
    public bool DayNightFlag = true;
    private string ModeOn = "DayOn";
    private string ModeOff = "DayOff";

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void DayEvent(){
        Debug.Log("イベント検知");

        if(DayFlag == false){
        this.tag = ModeOn;
        DayFlag = true;
        Debug.Log (DayFlag);
        }

        else if(DayFlag == true){
            this.tag = ModeOff;
            DayFlag = false;
            Debug.Log (DayFlag);
        }
    }

    public bool OnTriggerEnter2D(Collider2D other){
        Debug.Log("衝突");
        if(other.name.Contains("Enemy")){
            if(DayNightFlag == true){
                DayNightFlag = false;
                Debug.Log("夜");
            }
            else if (DayNightFlag == false){
                DayNightFlag = true;
                Debug.Log("昼");
            }
        }
        return DayNightFlag;
    }

}
