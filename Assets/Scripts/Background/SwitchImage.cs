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

    // Start is called before the first frame update
    void Start()
    {
        ControllButton = GameObject.Find("ControllButton(empty)");
        controllButton = ControllButton.GetComponent<ControllButton>();
        firstImage = DayImage;
    }

    // Update is called once per frame
    void Update()
    {
        if (DayFloor.instance.DayNightFlag == true)
        {
            CurrentImage.sprite = DayImage;
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
