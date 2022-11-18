using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SaveManager : MonoBehaviour
{
    private int stageNumber;
    public string stage = "0";
    public TextMeshProUGUI TextA;
    public void Click()
        {
        TextA.text = $"{stage}";
        //�������Ă���X�e�[�W�ԍ����擾�iif������g���ď㏑������Ȃ��悤�ɂ��邽�߂ł��j
        //�X�e�[�W���i�ނ��т�stageNumber�ɓ��鐔�l���ω����܂��B
        stageNumber = PlayerPrefs.GetInt("LEVEL");
            switch (stage)
            {
                case "1-1":
                    //���߂Ă��̃X�e�[�W���N���A�����Ƃ�����if���̒��ɓ���܂��B
                    if (stageNumber == 0)
                    {
                        //�Ăяo���Ƃ��̃L�[���uLEVEL�v�ɂ��āA�l���u1�v�Ƃ��ĕۑ����܂��B
                        PlayerPrefs.SetInt("LEVEL", 1);
                    }
                SceneManager.LoadScene("sampleB");
                break;
                case "1-2":
                    if (stageNumber == 1)
                    {
                        //1-2�̂Ƃ��͒l���u2�v�Ƃ��ĕۑ����܂��B
                        PlayerPrefs.SetInt("LEVEL", 2);
                    }
                    break;
                case "1-3":
                    if (stageNumber == 2)
                    {
                        PlayerPrefs.SetInt("LEVEL", 3);
                    }
                    break;
                case "1-4":
                    if (stageNumber == 3)
                    {
                        PlayerPrefs.SetInt("LEVEL", 4);
                    }
                    break;
                case "1-5":
                    if (stageNumber == 4)
                    {
                        PlayerPrefs.SetInt("LEVEL", 5);
                    }
                    break;
                case "1-6":
                    if (stageNumber == 5)
                    {
                        PlayerPrefs.SetInt("LEVEL", 6);
                    }
                    break;
                case "1-7":
                    if (stageNumber == 6)
                    {
                        PlayerPrefs.SetInt("LEVEL", 7);
                    }
                    break;
                case "1-8":
                    if (stageNumber == 7)
                    {
                        PlayerPrefs.SetInt("LEVEL", 8);
                    }
                    break;
                case "1-9":
                    if (stageNumber == 8)
                    {
                        PlayerPrefs.SetInt("LEVEL", 9);
                    }
                    break;
                case "1-10":
                    if (stageNumber == 9)
                    {
                        PlayerPrefs.SetInt("LEVEL", 10);
                    }
                    break;
        }
        //�O�ׁ̈A�����ŃZ�[�u���Ă����܂��B
        PlayerPrefs.Save();
    }
}
