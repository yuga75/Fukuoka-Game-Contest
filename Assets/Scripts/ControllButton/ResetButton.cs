using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public void ResetEvent()
    {
        if(PlayButton.playing == true)
        {
            Debug.Log("再生中につき、変更不可");
        }
        else
        {
            //TagをResetに変更
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
