using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearEvent : MonoBehaviour
{
    [SerializeField] GameObject GameClear;

    // Start is called before the first frame update
    void Start()
    {
        transform.SetAsLastSibling();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (ゲームをクリアしたか判定)
        {
            GameClear.SetActive(true)
        }*/
    }
}
