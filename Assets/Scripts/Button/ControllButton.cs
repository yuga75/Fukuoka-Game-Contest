using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControllButton : MonoBehaviour
{
    public bool play = false;
    public bool stop = false;
    public bool fast = false;
    public bool reset = false;
    private float ResetCount = 0.0f;
    private float ResetLimit = 5.0f;
    [SerializeField] Image GameClear;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //resetは5秒経過でfalseにする。
        if (reset == true)
        {
            ResetCount += Time.deltaTime;
            Debug.Log(ResetCount);
            if (ResetCount >= ResetLimit)
            {
                reset = false;
                Debug.Log("play:" + play);
                Debug.Log("stop:" + stop);
                Debug.Log("fast:" + fast);
                Debug.Log("reset:" + reset);
                ResetCount = 0.0f;
            }
        }
        //ステージが終了したらplayとfastをfalseにする。
        if(GameClear.enabled == true)
        {
            play = false;
            fast = false;
        }
    }
}
