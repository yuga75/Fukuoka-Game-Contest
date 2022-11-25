using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAreaButton : MonoBehaviour
{
    [SerializeField] private GameObject ChangeCamera;
    [SerializeField] private GameObject NowCamera;


    public void ChangeField()
    {
        NowCamera.SetActive(false);
        ChangeCamera.SetActive(true);
        Debug.Log("Chenge");
    }
}

