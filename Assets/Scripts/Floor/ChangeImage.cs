using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    [SerializeField] private Sprite OnImage;
    [SerializeField] private Sprite OffImage;
    SpriteRenderer sr;
    private bool ImageFlag = true;

    void Start(){
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    public void OnClickChangeImage(){
        if(ImageFlag == false){
            sr.sprite = OnImage;
            ImageFlag = true;
            Debug.Log ("On");
        }

        else if(ImageFlag == true){
            sr.sprite = OffImage;
            ImageFlag = false;
            Debug.Log ("Off");
        }
    }
}
