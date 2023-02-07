using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour
{
    [SerializeField] private GameObject[] Stages;

    void Start()
    { 
        Stages[0].gameObject.SetActive(false);
        Stages[1].gameObject.SetActive(false);
        Stages[2].gameObject.SetActive(false);
        Stages[3].gameObject.SetActive(false);
        Stages[4].gameObject.SetActive(false);
        Stages[5].gameObject.SetActive(false);
        Stages[6].gameObject.SetActive(false);
        Stages[7].gameObject.SetActive(false);
        Stages[8].gameObject.SetActive(false);
        Stages[9].gameObject.SetActive(false);
    }


    void Update()
    {
        //フラグ
        if(PlayerPrefs.GetInt("Tutorial",0)==1)
        {
                Stages[0].gameObject.SetActive(true);
        }
        if(PlayerPrefs.GetInt("Stage1",0)==1)
        {
                Stages[1].gameObject.SetActive(true);
        }
        if(PlayerPrefs.GetInt("Stage2",0)==1)
        {
                Stages[2].gameObject.SetActive(true);
        }
        if(PlayerPrefs.GetInt("Stage3",0)==1)
        {
                Stages[3].gameObject.SetActive(true);
        }
        if(PlayerPrefs.GetInt("Stage4",0)==1)
        {
                Stages[4].gameObject.SetActive(true);
        }
        if(PlayerPrefs.GetInt("Stage5",0)==1)
        {
                Stages[5].gameObject.SetActive(true);
        }
        if(PlayerPrefs.GetInt("Stage6",0)==1)
        {
                Stages[6].gameObject.SetActive(true);
        }
        if(PlayerPrefs.GetInt("Stage7",0)==1)
        {
                Stages[7].gameObject.SetActive(true);
        }
        if(PlayerPrefs.GetInt("Stage8",0)==1)
        {
                Stages[8].gameObject.SetActive(true);
        }
        if(PlayerPrefs.GetInt("Stage9",0)==1)
        {
                Stages[9].gameObject.SetActive(true);
        }
    }
}
