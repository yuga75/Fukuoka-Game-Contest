using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SaveManager : MonoBehaviour
{
    private int stageNumber;
    public string stage = "0",LEVEL;
    public TextMeshProUGUI TextA;
    public void Click()
        {
        
        //今持っているステージ番号を取得（if分岐を使って上書きされないようにするためです）
        //ステージが進むたびにstageNumberに入る数値が変化します。
        stageNumber = PlayerPrefs.GetInt("LEVEL");
            switch (stage)
            {
                case "tutorial":
                //チュートリアルが終わったときセーブの中身をリセットする
                PlayerPrefs.DeleteAll();
                
                break;
                case "1-1":
                    //初めてそのステージをクリアしたときだけif文の中に入ります。
                    if (stageNumber == 0)
                    {
                        //呼び出すときのキーを「LEVEL」にして、値を「1」として保存します。
                        PlayerPrefs.SetInt("LEVEL", 1);
                        
                }
                    break;
                case "1-2":
                    if (stageNumber == 1)
                    {
                        //1-2のときは値を「2」として保存します。
                        PlayerPrefs.SetInt("LEVEL", 2);
                    }
                    break;
                case "1-3":
                    if (stageNumber == 2)
                    {
                        PlayerPrefs.SetInt("LEVEL", 3);
                    }
                    break;
                case "story1":
                    if (stageNumber == 3)
                    {
                        PlayerPrefs.SetInt("LEVEL", 4);
                    }
                    break;
                case "1-4":
                    if (stageNumber == 4)
                    {
                        PlayerPrefs.SetInt("LEVEL", 5);
                    }
                    break;
                case "1-5":
                    if (stageNumber == 5)
                    {
                        PlayerPrefs.SetInt("LEVEL", 6);
                    }
                    break;
                case "1-6":
                    if (stageNumber == 6)
                    {
                        PlayerPrefs.SetInt("LEVEL", 7);
                    }
                    break;
                case "story2":
                    if (stageNumber == 7)
                    {
                        PlayerPrefs.SetInt("LEVEL", 8);
                    }
                    break;
                case "1-7":
                    if (stageNumber == 8)
                    {
                        PlayerPrefs.SetInt("LEVEL", 9);
                    }
                    break;
                case "1-8":
                    if (stageNumber == 9)
                    {
                        PlayerPrefs.SetInt("LEVEL", 10);
                    }
                    break;
                case "1-9":
                    if (stageNumber == 10)
                    {
                        PlayerPrefs.SetInt("LEVEL", 11);
                    }
                    break;
                case "story3":
                    if (stageNumber == 11)
                    {
                        PlayerPrefs.SetInt("STORY", 12);
                    }
                    break;
                case "1-10":
                    if (stageNumber == 12)
                    {
                        PlayerPrefs.SetInt("LEVEL", 13);
                    }
                    break;
        }
        //念の為、ここでセーブしておきます。
        PlayerPrefs.Save();
    }
}
