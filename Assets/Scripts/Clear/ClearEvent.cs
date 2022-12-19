using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearEvent : MonoBehaviour
{
    [SerializeField] GameObject GameClear;

    private GameObject PlayerObject;
    private PlayerTest pt;

    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GameObject.Find("Player");
        pt = PlayerObject.GetComponent<PlayerTest>();
        transform.SetAsLastSibling();
    }

    // Update is called once per frame
    void Update()
    {
        //クリア後、ClearUIを表示する
        if(pt.playerState == "Cleared")
        {
            GameClear.SetActive(true);
        }
    }
}
