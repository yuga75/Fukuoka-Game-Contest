using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSE : MonoBehaviour
{
    AudioSource playerSe;
    public AudioClip playerClear;
    public AudioClip playerFailed;

    public GameObject player;
    PlayerTest playerTest;
    // Start is called before the first frame update
    void Start()
    {
        playerSe = GetComponent<AudioSource>();
        player = GameObject.Find("Player");
        playerTest = player.GetComponent<PlayerTest>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTest.playerState == "Cleared")
        {
            playerSe.PlayOneShot(playerClear);
        }
        else if(playerTest.playerState == "humanFailed"
            || playerTest.playerState == "wolfFailed")
        {
            playerSe.PlayOneShot(playerFailed);
        }
    }
}
