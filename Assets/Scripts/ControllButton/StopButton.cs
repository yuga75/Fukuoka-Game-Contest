using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButton : MonoBehaviour
{
    public static bool stopping;

    public void StopEvent()
    {
        if(PlayButton.playing == true)
        {
            stopping = true;
            //tag‚ğStop‚É•ÏX
        }
        else
        {
            Debug.Log("Ä¶’†‚Å‚Í‚È‚¢");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        stopping = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
