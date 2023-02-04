using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoButtonController : MonoBehaviour
{
    [SerializeField] private GameObject[] GoButton;

    void Start()
    {
        Reset();
    }
    void Reset()
    {
        GoButton[0].gameObject.SetActive(false);
        GoButton[1].gameObject.SetActive(false);
        GoButton[2].gameObject.SetActive(false);
        GoButton[3].gameObject.SetActive(false);
        GoButton[4].gameObject.SetActive(false);
        GoButton[5].gameObject.SetActive(false);
        GoButton[6].gameObject.SetActive(false);
        GoButton[7].gameObject.SetActive(false);
        GoButton[8].gameObject.SetActive(false);
        GoButton[9].gameObject.SetActive(false);
        GoButton[10].gameObject.SetActive(false);
        GoButton[11].gameObject.SetActive(false);
        GoButton[12].gameObject.SetActive(false); 
    }

    public void GoButton1()
    {
        Reset();
        GoButton[0].gameObject.SetActive(true);
    }
    public void GoButton2()
    {
        Reset();
        GoButton[1].gameObject.SetActive(true);
    }
    public void GoButton3()
    {
        Reset();
        GoButton[2].gameObject.SetActive(true);
    }
    public void GoButton4()
    {
        Reset();
        GoButton[3].gameObject.SetActive(true);
    }
    public void GoButton5()
    {
        Reset();
        GoButton[4].gameObject.SetActive(true);
    }
    public void GoButton6()
    {
        Reset();
        GoButton[5].gameObject.SetActive(true);
    }
    public void GoButton7()
    {
        Reset();
        GoButton[6].gameObject.SetActive(true);
    }
    public void GoButton8()
    {
        Reset();
        GoButton[7].gameObject.SetActive(true);
    }
    public void GoButton9()
    {
        Reset();
        GoButton[8].gameObject.SetActive(true);
    }
    public void GoButton10()
    {
        Reset();
        GoButton[9].gameObject.SetActive(true);
    }
    public void GoButton11()
    {
        Reset();
        GoButton[10].gameObject.SetActive(true);
    }
    public void GoButton12()
    {
        Reset();
        GoButton[11].gameObject.SetActive(true);
    }
    public void GoButton13()
    {
        Reset();
        GoButton[12].gameObject.SetActive(true);
    }
}
