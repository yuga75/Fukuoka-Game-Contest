using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgm : MonoBehaviour
{
    public GameObject Player;
    PlayerTest playerTest;
    public AudioSource BGM;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        playerTest = Player.GetComponent<PlayerTest>();

        BGM = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTest.playerState == "Cleared"
            || playerTest.playerState == "humanFailed"
            || playerTest.playerState == "wolfFailed")
        {
            BGM.Stop();
        }
        else
        {
            BGM.loop = BGM.loop;
        }
    }
}
