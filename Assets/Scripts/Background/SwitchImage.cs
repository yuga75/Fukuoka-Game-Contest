using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchImage : MonoBehaviour
{
    public Image CurrentImage;
    [SerializeField] private Sprite NightImage;
    [SerializeField] private Sprite DayImage;

    // Start is called before the first frame update
    void Start()
    {

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
    }
}
