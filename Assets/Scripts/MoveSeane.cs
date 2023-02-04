using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveSeane : MonoBehaviour
{
    [SerializeField] private string NextScene;
    [SerializeField] private GameObject Camera;
    [SerializeField] private float LoadTime;

    public void LoadSeane()
    {
        Vector3 CameraPosition = Camera.transform.position;
        Camera.transform.position = new Vector3(0,14,-10);
        Invoke("SetInvoke",LoadTime);
    }

    private void SetInvoke()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(NextScene);
    }

}
