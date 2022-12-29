using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgm : MonoBehaviour
{
    public GameObject Player;
    PlayerTest playerTest;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        playerTest = Player.GetComponent<PlayerTest>();

        audioSource = Player.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTest.playerState == "Cleared"
            || playerTest.playerState == "humanFailed"
            || playerTest.playerState == "wolfFailed")
        {
            audioSource.loop = !audioSource.loop;
        }
        else
        {
            audioSource.loop = audioSource.loop;
        }
    }
}
