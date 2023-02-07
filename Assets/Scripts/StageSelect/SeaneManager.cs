using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SeaneManager : MonoBehaviour
{
    [SerializeField] private Slider Slider;
    [SerializeField] private string NextScene;
    void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(NextScene);
        while (!async.isDone)
        {
            Slider.value = async.progress;
            yield return null;
        } 
    }

}
