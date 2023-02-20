using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryText : MonoBehaviour
{
    [SerializeField] Text text;
    private string[] wordArray;
    private string words1;
    private string words2;
    private string words3;

    string sceneName;

    bool oneTime;

    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        words1 = "1,つ,目,の,配,達,の,証,を,手,に,い,れ,た,！,\n";
        words2 = "2,つ,目,の,配,達,の,証,を,手,に,い,れ,た,！,\n";
        words3 = "3,つ,目,の,配,達,の,証,を,手,に,い,れ,た,！,\n";
        oneTime = true;
    }

    void Update()
    {
        if (sceneName == "Story1")
        {
            wordArray = words1.Split(",");
        }
        else if (sceneName == "Story2")
        {
            wordArray = words2.Split(",");
        }
        else
        {
            wordArray = words3.Split(",");
        }

        if (oneTime == true)
        {
            StartCoroutine("SetText");
            oneTime = false;
        }

        if(Input.GetMouseButtonDown(0))
        {
            Invoke("ChangeScene", 2.0f);
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("StageSelect");
    }


    IEnumerator SetText()
    {
        foreach (var p in wordArray)
        {
            if (p != "\n")
            {
                text.text = text.text + p;
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}