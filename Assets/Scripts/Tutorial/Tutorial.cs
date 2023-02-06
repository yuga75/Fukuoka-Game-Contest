using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject[] TutorialText;

    [SerializeField] GameObject player;

    private GameObject ControllButtonObject;
    private ControllButton cb;

    Vector3 locate;

    // Start is called before the first frame update
    void Start()
    {
        ControllButtonObject = GameObject.Find("ControllButton(empty)");
        cb = ControllButtonObject.GetComponent<ControllButton>();

        player = GameObject.Find("Player");

        TutorialText[0].gameObject.SetActive(true);
        TutorialText[1].gameObject.SetActive(true);
        TutorialText[2].gameObject.SetActive(false);
        TutorialText[3].gameObject.SetActive(false);
        TutorialText[4].gameObject.SetActive(false);
        TutorialText[5].gameObject.SetActive(false);
        TutorialText[6].gameObject.SetActive(false);
        TutorialText[7].gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        locate = player.transform.position;
        if (cb.play == true)
        {
            TutorialText[0].gameObject.SetActive(false);
            TutorialText[1].gameObject.SetActive(false);
            TutorialText[2].gameObject.SetActive(true);
            if (locate.x >= -4.0)
            {
                TutorialText[3].gameObject.SetActive(true);
                TutorialText[4].gameObject.SetActive(true);
            }
            if (locate.x >= -2.5)
            {
                TutorialText[2].gameObject.SetActive(false);
            }
            if (locate.x >= 0.5)
            {
                TutorialText[5].gameObject.SetActive(true);
                TutorialText[6].gameObject.SetActive(true);
                TutorialText[7].gameObject.SetActive(true);
            }
            if (locate.x >= 1.5)
            {
                TutorialText[3].gameObject.SetActive(false);
                TutorialText[4].gameObject.SetActive(false);
            }
            if (locate.x >= 5.5)
            {
                TutorialText[5].gameObject.SetActive(false);
                TutorialText[6].gameObject.SetActive(false);
                TutorialText[7].gameObject.SetActive(false);
            }
        }
    }
}
