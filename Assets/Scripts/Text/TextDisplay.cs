using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextDisplay : MonoBehaviour
{
    [SerializeField] private string[] texts;
    [SerializeField] private GameObject[] OPimages;
    [SerializeField] private GameObject[] EDimages;
    [SerializeField] private float textSpeed;
    [SerializeField] private string NextScean;
    [SerializeField] private bool OpFlag; 
    [SerializeField] private bool EdFlag; 
    int textNumber;
    string displayText;
    int textCharNumber;
    int EndInvoke = 2;
    bool Endflag = false;

    void Start()
    {
        InvokeRepeating("TextManager",1,textSpeed);
        for(int i=0;i<=OPimages.Length-1;i++){
            OPimages[i].SetActive(false);
        }
        if(OpFlag==true)
        {
            OPimages[0].SetActive(true);
        }
        for(int i=0;i<=EDimages.Length-1;i++){
            EDimages[i].SetActive(false);
        }
        if(EdFlag==true)
        {
            EDimages[0].SetActive(true);
        }
    }
    void Update()
    {
        if (textNumber != texts.Length - 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                displayText = "";
                textCharNumber = 0;
                textNumber = textNumber + 1;
                Debug.Log("charend1");

                if(OpFlag==true)
                {
                    switch(textNumber){
                        case 0:
                            OPimages[0].SetActive(true);
                            break;
                        case 2:
                            OPimages[0].SetActive(false);
                            OPimages[1].SetActive(true);
                            break;
                        case 3:
                            OPimages[1].SetActive(false);
                            OPimages[2].SetActive(true);
                            break;
                        case 5:
                            OPimages[2].SetActive(false);
                            OPimages[3].SetActive(true);
                            break;
                        case 7:
                            OPimages[3].SetActive(false);
                            OPimages[4].SetActive(true);
                            break;
                        case 9:
                            OPimages[4].SetActive(false);
                            OPimages[5].SetActive(true);
                            break;
                    }
                }
                 if(EdFlag==true)
                {
                    switch(textNumber){
                        case 0:
                            EDimages[0].SetActive(true);
                            break;
                        case 3:
                            EDimages[0].SetActive(false);
                            EDimages[1].SetActive(true);
                            break;
                        case 5:
                            EDimages[1].SetActive(false);
                            EDimages[2].SetActive(true);
                            break;
                    }
                }


            }
        }
        else if(Endflag == false)
        {
            Invoke("EndProcess",EndInvoke);
            Endflag = true;
        }         
    }

    void TextManager()
    {
        if (textCharNumber != texts[textNumber].Length) 
        {
            displayText = displayText + texts[textNumber][textCharNumber];
            textCharNumber = textCharNumber + 1;
        }

        this.GetComponent<Text>().text = displayText;
    }

    void EndProcess()
    {
        Debug.Log("End");
        SceneManager.LoadScene(NextScean);
    }
}