using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearEvent : MonoBehaviour
{
    [SerializeField] Image GameClear;
    private float SwitchCount = 0.0f;
    private float SwitchLimit = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        GameClear.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (�Q�[�����N���A����������)
          {
              GameClear.enabled = true
          }*/
        if (GameClear.enabled == true)
        {
            //GameClear�̔�\���܂łT�b�҂�
            SwitchCount += Time.deltaTime;
            if (SwitchCount >= SwitchLimit)
            {
                {
                    GameClear.enabled = false;
                    SceneManager.LoadScene("hoge", LoadSceneMode.Single);
                    SwitchCount = 0.0f;
                }
            }
        }
    }
}
