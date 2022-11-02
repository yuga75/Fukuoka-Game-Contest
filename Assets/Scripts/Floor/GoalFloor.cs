using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalFloor : MonoBehaviour
{
    [SerializeField] private GameObject ClearText;
    [SerializeField] private string NextScean;
    [SerializeField] private float InvokeTime;
    
    void Start()
    {
        ClearText.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("hit");
        if(other.name.Contains("Player")){
            ClearText.GetComponent<Text>();
            ClearText.SetActive(true);
            Invoke("ChangeScene",InvokeTime);
        }
    }

    private void ChangeScene(){
        SceneManager.LoadScene(NextScean);
    }
}
