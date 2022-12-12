using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchImage : MonoBehaviour
{
    public Image CurrentImage;
    [SerializeField] private Sprite NightImage;
    [SerializeField] private Sprite DayImage;

    private GameObject dayFloor;
    private DayFloor df;
    // Start is called before the first frame update
    void Start()
    {
        dayFloor = GameObject.Find("DayFloor");
        df = dayFloor.GetComponent<DayFloor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (df.DayNightFlag == true)
        {
            CurrentImage.sprite = DayImage;
        }
        else
        {
            CurrentImage.sprite = NightImage;
        }
    }
}
