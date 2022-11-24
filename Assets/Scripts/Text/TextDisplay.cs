using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
    [SerializeField] public string[] texts;
    [SerializeField] public float textSpeed;
    //[SerializeField] private string NextScean;
    int textNumber;
    string displayText;
    int textCharNumber;
    int EndInvoke = 2;
    bool Endflag = false;

    void Start()
    {
        InvokeRepeating("TextManager",1,textSpeed);
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
        //SceneManager.LoadScene(NextScean);
    }
}