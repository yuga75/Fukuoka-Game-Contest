using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject Camera;
    [SerializeField] private float NowCameraPosition;
    [SerializeField] private float LoadTime;
    



    private void Start()
    {
        Vector3 CameraPosition = new Vector3(NowCameraPosition,0,-10);
        Camera.transform.position = new Vector3(NowCameraPosition,0,-10);
        Debug.Log(2);
    }

    private void NextArea()
    {
        Vector3 CameraPosition = Camera.transform.position;
        Camera.transform.position = new Vector3(0,14,-10);
        Invoke("SetInvokeNext",LoadTime);
    }

    private void BackArea()
    {
        Vector3 CameraPosition = Camera.transform.position;
        Camera.transform.position = new Vector3(0,14,-10);
        Invoke("SetInvokeBack",LoadTime);
    }

    private void SetInvokeNext()
    {
        NowCameraPosition = NowCameraPosition+25;
        Camera.transform.position = new Vector3(NowCameraPosition,0,-10);
        Debug.Log(0);
    }

    private void SetInvokeBack()
    {
        NowCameraPosition = NowCameraPosition-25;
        Camera.transform.position = new Vector3(NowCameraPosition,0,-10);
        Debug.Log(1);
    }
}
