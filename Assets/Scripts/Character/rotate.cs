using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{

    float rotation_speed = 0; // ��]���x
    int count = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // ���N���b�N���ꂽ���]���x��ݒ肷��
            this.rotation_speed = 7.2f;
            //rotation_speed = 0;
        // ��]���x����
        if (count != 50)
        {
            gameObject.transform.Rotate(new Vector3(0, this.rotation_speed, 0));
            count += 1;
            Debug.Log(count);
        }
        else
        {
            this.rotation_speed = 0.0f;
            gameObject.transform.Rotate(new Vector3(0, this.rotation_speed, 0));
        }
    }
}