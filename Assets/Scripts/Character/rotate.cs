using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{

    float rotation_speed = 0; // ��]���x
    bool key = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ���N���b�N���ꂽ���]���x��ݒ肷��
        if (Input.GetMouseButtonDown(0))
        {
            this.rotation_speed = 1.0f;
            //rotation_speed = 0;
        }
        // ��]���x����
        if (key == true)
        {
            gameObject.transform.Rotate(new Vector3(0, 1, 0));
        }
    }
}