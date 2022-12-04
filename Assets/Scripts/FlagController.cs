using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour
{
    [SerializeField] private GameObject[] Stages;
    private int FlagInt = 0;

    void Start()
    {   //テスト用
        //PlayerPrefs.SetInt("LEVEL",0);
        //Debug.Log("Set0");

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
/*      テスト用
        if(Input.GetMouseButton(0))
        {
            PlayerPrefs.SetInt("LEVEL",1);
            Debug.Log("Set1");
        }
*/
        switch(FlagInt)
        {
            case  1:
            Stages[0].gameObject.SetActive(true);
            break;

            case  2:
            Stages[0].gameObject.SetActive(true);
            Stages[1].gameObject.SetActive(true);
            break;

            case  3:
            Stages[0].gameObject.SetActive(true);
            Stages[1].gameObject.SetActive(true);
            Stages[2].gameObject.SetActive(true);
            break;

            case  4:
            Stages[0].gameObject.SetActive(true);
            Stages[1].gameObject.SetActive(true);
            Stages[2].gameObject.SetActive(true);
            Stages[3].gameObject.SetActive(true);
            break;

            case  5:
            Stages[0].gameObject.SetActive(true);
            Stages[1].gameObject.SetActive(true);
            Stages[2].gameObject.SetActive(true);
            Stages[3].gameObject.SetActive(true);
            Stages[4].gameObject.SetActive(true);
            break;

            case  6:
            Stages[0].gameObject.SetActive(true);
            Stages[1].gameObject.SetActive(true);
            Stages[2].gameObject.SetActive(true);
            Stages[3].gameObject.SetActive(true);
            Stages[4].gameObject.SetActive(true);
            Stages[5].gameObject.SetActive(true);
            break;

            case  7:
            Stages[0].gameObject.SetActive(true);
            Stages[1].gameObject.SetActive(true);
            Stages[2].gameObject.SetActive(true);
            Stages[3].gameObject.SetActive(true);
            Stages[4].gameObject.SetActive(true);
            Stages[5].gameObject.SetActive(true);
            Stages[6].gameObject.SetActive(true);
            break;

            case  8:
            Stages[0].gameObject.SetActive(true);
            Stages[1].gameObject.SetActive(true);
            Stages[2].gameObject.SetActive(true);
            Stages[3].gameObject.SetActive(true);
            Stages[4].gameObject.SetActive(true);
            Stages[5].gameObject.SetActive(true);
            Stages[6].gameObject.SetActive(true);
            Stages[7].gameObject.SetActive(true);
            break;

            case  9:
            Stages[0].gameObject.SetActive(true);
            Stages[1].gameObject.SetActive(true);
            Stages[2].gameObject.SetActive(true);
            Stages[3].gameObject.SetActive(true);
            Stages[4].gameObject.SetActive(true);
            Stages[5].gameObject.SetActive(true);
            Stages[6].gameObject.SetActive(true);
            Stages[7].gameObject.SetActive(true);
            Stages[8].gameObject.SetActive(true);
            break;

            case  10:
            Stages[0].gameObject.SetActive(true);
            Stages[1].gameObject.SetActive(true);
            Stages[2].gameObject.SetActive(true);
            Stages[3].gameObject.SetActive(true);
            Stages[4].gameObject.SetActive(true);
            Stages[5].gameObject.SetActive(true);
            Stages[6].gameObject.SetActive(true);
            Stages[7].gameObject.SetActive(true);
            Stages[8].gameObject.SetActive(true);
            Stages[9].gameObject.SetActive(true);
            break;

            case  11:
            Stages[0].gameObject.SetActive(true);
            Stages[1].gameObject.SetActive(true);
            Stages[2].gameObject.SetActive(true);
            Stages[3].gameObject.SetActive(true);
            Stages[4].gameObject.SetActive(true);
            Stages[5].gameObject.SetActive(true);
            Stages[6].gameObject.SetActive(true);
            Stages[7].gameObject.SetActive(true);
            Stages[8].gameObject.SetActive(true);
            Stages[9].gameObject.SetActive(true);
            Stages[10].gameObject.SetActive(true);
            break;

            case  12:
            Stages[0].gameObject.SetActive(true);
            Stages[1].gameObject.SetActive(true);
            Stages[2].gameObject.SetActive(true);
            Stages[3].gameObject.SetActive(true);
            Stages[4].gameObject.SetActive(true);
            Stages[5].gameObject.SetActive(true);
            Stages[6].gameObject.SetActive(true);
            Stages[7].gameObject.SetActive(true);
            Stages[8].gameObject.SetActive(true);
            Stages[9].gameObject.SetActive(true);
            Stages[10].gameObject.SetActive(true);
            Stages[11].gameObject.SetActive(true);
            break;

            case  13:
            Stages[0].gameObject.SetActive(true);
            Stages[1].gameObject.SetActive(true);
            Stages[2].gameObject.SetActive(true);
            Stages[3].gameObject.SetActive(true);
            Stages[4].gameObject.SetActive(true);
            Stages[5].gameObject.SetActive(true);
            Stages[6].gameObject.SetActive(true);
            Stages[7].gameObject.SetActive(true);
            Stages[8].gameObject.SetActive(true);
            Stages[9].gameObject.SetActive(true);
            Stages[10].gameObject.SetActive(true);
            Stages[11].gameObject.SetActive(true);
            Stages[12].gameObject.SetActive(true);
            break;
        }
        FlagInt = PlayerPrefs.GetInt("LEVEL",0);

    }
}
