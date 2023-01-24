using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchImage : MonoBehaviour
{
    Sprite firstImage;
    public Image CurrentImage;
    [SerializeField] private Sprite NightImage;
    [SerializeField] private Sprite DayImage;
    public GameObject ControllButton;
    ControllButton controllButton;

    public GameObject Player;
    PlayerTest playerTest;

    // Start is called before the first frame update
    void Start()
    {
        ControllButton = GameObject.Find("ControllButton(empty)");
        controllButton = ControllButton.GetComponent<ControllButton>();
        firstImage = DayImage;

        Player = GameObject.Find("Player");
        playerTest = Player.GetComponent<PlayerTest>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTest.playerState == "Human")
        {
            CurrentImage.sprite = DayImage;
        }
        else if(playerTest.playerState == "humanFailed" || playerTest.playerState == "wolfFailed")
        {

        }
        else
        {
            CurrentImage.sprite = NightImage;
        }
        if(controllButton.reset == true)
        {
            CurrentImage.sprite = firstImage;
            Start();
        }
    }
}
