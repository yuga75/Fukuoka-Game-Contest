using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour
{
    [SerializeField] private GameObject[] Stages;

    void Start()
    {   //テスト用
        PlayerPrefs.SetInt("LEVEL",0);
        Debug.Log("Set0");

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
        Stages[10].gameObject.SetActive(false);
        Stages[11].gameObject.SetActive(false);
        Stages[12].gameObject.SetActive(false);
    }


    void Update()
    {
      //テスト用
        if(Input.GetMouseButton(0))
        {
            PlayerPrefs.SetInt("Tutorial",1);
            Debug.Log("Set1");
        }
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
                Stages[4].gameObject.SetActive(true);
        }
        if(PlayerPrefs.GetInt("Stage4",0)==1)
        {
                Stages[5].gameObject.SetActive(true);
        }
        if(PlayerPrefs.GetInt("Stage5",0)==1)
        {
                Stages[6].gameObject.SetActive(true);
        }
        if(PlayerPrefs.GetInt("Stage6",0)==1)
        {
                Stages[7].gameObject.SetActive(true);
                Stages[8].gameObject.SetActive(true);
        }
        if(PlayerPrefs.GetInt("Stage7",0)==1)
        {
                Stages[9].gameObject.SetActive(true);
        }
        if(PlayerPrefs.GetInt("Stage8",0)==1)
        {
                Stages[10].gameObject.SetActive(true);
        }
        if(PlayerPrefs.GetInt("Stage9",0)==1)
        {
                Stages[11].gameObject.SetActive(true);
                Stages[12].gameObject.SetActive(true);
        }
    }
}
