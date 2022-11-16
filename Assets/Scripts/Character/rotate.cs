using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{

    float rotation_speed = 0; // 回転速度
    int count = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 左クリックされたら回転速度を設定する
            this.rotation_speed = 7.2f;
            //rotation_speed = 0;
        // 回転速度分回す
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