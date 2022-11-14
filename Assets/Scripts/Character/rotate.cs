using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{

    float rotation_speed = 0; // 回転速度
    bool key = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 左クリックされたら回転速度を設定する
        if (Input.GetMouseButtonDown(0))
        {
            this.rotation_speed = 1.0f;
            //rotation_speed = 0;
        }
        // 回転速度分回す
        if (key == true)
        {
            gameObject.transform.Rotate(new Vector3(0, 1, 0));
        }
    }
}