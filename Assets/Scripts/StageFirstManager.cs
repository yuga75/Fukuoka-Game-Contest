using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageFirstManager : MonoBehaviour
{
    [SerializeField] private GameObject FirstCamera;
    private GameObject Camera1_3;
    private GameObject Camera4_6;
    private GameObject Camera7_9;
    private GameObject Camera10;


    void Start()
    {
        Camera1_3 = GameObject.Find("Stage1-3Camera");
        Camera4_6 = GameObject.Find("Stage4-6Camera");
        Camera7_9 = GameObject.Find("Stage7-9Camera");
        Camera10 = GameObject.Find("Stage10Camera");
        Camera1_3.SetActive(false);
        Camera4_6.SetActive(false);
        Camera7_9.SetActive(false);
        Camera10.SetActive(false);
        FirstCamera.SetActive(true);
    }
}