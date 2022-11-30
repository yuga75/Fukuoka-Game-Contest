using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Progress;

public class Player : MonoBehaviour
{
    //再生ボタンの取得
    GameObject ControllButton;
    public ControllButton controllButton;
    public DragDropScript dragDropScript;

    public GameObject Warp1_1;
    public GameObject Warp1_2;
    public GameObject Warp2_1;
    public GameObject Warp2_2;
    public GameObject Warp3_1;
    public GameObject Warp3_2;


    public GameObject player;   //(操作)移動したいオブジェクトを設定
    public Vector3 movePosition;　//移動する距離を格納
    public int speed = 5;　//1マス毎に移動するスピード
    public float rotateSpeed = 7.2f;   //回転スピード
    public Vector3 moveY = new Vector3(0, 1, 0);　//(1マス毎の)Y軸の移動距離
    public Vector3 moveX = new Vector3(1, 0, 0);　//(1マス毎の)X軸の移動距離
    int count = 0;  //1秒カウント用
    bool hogehoge;  //再生判定
    bool firstMoveJudge;    //最初のフレームの移動判定
    bool moveJudge; //移動中の判定
    bool stopJudge;   //回転中の判定

    public Vector3 pos;
    Collision collision;

    // 点滅させる対象
    [SerializeField] private Renderer _target;
    // 点滅周期[s]
    [SerializeField] private float _cycle = 1;
    private float _time;

    void Start()
    {
        //初期設定
        player.tag = "Human";

        firstMoveJudge = true;  //最初のフレームの移動判定を真にする
        moveJudge = false;  //2フレーム目以降の移動判定を偽にする
        stopJudge = false;  //停止判定を偽にする

        ControllButton = GameObject.Find("ControllButton"); //再生ボタンを探す
        controllButton = ControllButton.GetComponent<ControllButton>();
    }

    void FixedUpdate()  //0.02秒毎に呼び出される
    {
        //移動場所設定
        //移動を行うと、moveJudge = true に変わり、一時的に移動の分岐処理を無効化
        if (hogehoge == true)   //再生判定が真である
        {
            //最初のフレームは独立した移動処理を行う
            if (firstMoveJudge == true && this.gameObject.CompareTag("NormalFloor"))    //通常床の場合
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, movePosition, speed * Time.deltaTime);
                firstMoveJudge = false; //最初の移動判定を偽にする
            }
            else
            {
                movePosition = new Vector3(0, 0, 0);    //移動距離を0にする
            }

            if (moveJudge == false && firstMoveJudge == false) //移動判定が偽である
            {

                /*-----ここから回転床の処理-----*/
                if (this.gameObject.CompareTag("TurnUpFloor"))  //↑方向の回転床の場合
                {
                    if (count == 50)
                    {
                        //FixedUpdateで一秒を計測するために50回カウントを行う
                        stopJudge = false;
                        count = 0;
                    }

                    if (stopJudge == false)
                    {
                        movePosition = player.transform.position + moveY;  //movePositionに移動する距離を格納
                        moveJudge = true;  //moveButtonJudge = trueにして、処理を制限する
                    }
                    else if(moveJudge == false)
                    {
                        stopJudge = true;   //一時的に移動をとめる
                        gameObject.transform.Rotate(new Vector3(0, this.rotateSpeed, 0));
                        count += 1;
                    }
                }
                if (this.gameObject.CompareTag("TurnDownFloor"))    //↓方向の回転床の場合
                {
                    if (count == 50)
                    {
                        //FixedUpdateで一秒を計測するために50回カウントを行う
                        stopJudge = false;
                        count = 0;
                    }

                    if (stopJudge == false)
                    {
                        movePosition = player.transform.position - moveY;  //movePositionに移動する距離を格納
                        moveJudge = true;  //moveButtonJudge = trueにして、処理を制限する
                    }
                    else if (moveJudge == false)
                    {
                        stopJudge = true;
                        gameObject.transform.Rotate(new Vector3(0, this.rotateSpeed, 0));
                        count += 1;
                    }
                }
                if (this.gameObject.CompareTag("TurnRightFloor")) //→方向の回転床の場合
                {
                    if (count == 50)
                    {
                        //FixedUpdateで一秒を計測するために50回カウントを行う
                        stopJudge = false;
                        count = 0;
                    }

                    if (stopJudge == false)
                    {
                        movePosition = player.transform.position + moveX;  //movePositionに移動する距離を格納
                        moveJudge = true;  //moveButtonJudge = trueにして、処理を制限する
                    }
                    else if (moveJudge == false)
                    {
                        stopJudge = true;
                        gameObject.transform.Rotate(new Vector3(0, this.rotateSpeed, 0));
                        count += 1;
                    }
                }
                if (this.gameObject.CompareTag("TurnLeftFloor")) //←方向の回転床の場合
                {
                    if (count == 50)
                    {
                        //FixedUpdateで一秒を計測するために50回カウントを行う
                        stopJudge = false;
                        count = 0;
                    }

                    if (stopJudge == false)
                    {
                        movePosition = player.transform.position - moveX;  //movePositionに移動する距離を格納
                        moveJudge = true;  //moveButtonJudge = trueにして、処理を制限する
                    }
                    else if (moveJudge == false)
                    {
                        stopJudge = true;
                        gameObject.transform.Rotate(new Vector3(0, this.rotateSpeed, 0));
                        count += 1;
                    }
                }
                /*-----ここまで回転床の処理-----*/


                /*-----ここから昼夜床の処理-----*/
                if (this.gameObject.CompareTag("DayFloor")) //昼夜床の場合
                {
                    if(player.tag == "Human")
                    {
                        player.tag = "Wolf";
                    }
                    else
                    {
                        player.tag = "Human";
                    }
                }
                /*-----ここまで昼夜床の処理-----*/


                /*-----ここからワープ床の処理-----*/
                if (this.gameObject.CompareTag("Warp1_1On"))
                {
                    this.gameObject.transform.position = Warp1_2.transform.position;
                }

                if (this.gameObject.CompareTag("Warp1_2On"))
                {
                    this.gameObject.transform.position = Warp1_1.transform.position;
                }

                if (this.gameObject.CompareTag("Warp2_1On"))
                {
                    this.gameObject.transform.position = Warp2_2.transform.position;
                }

                if (this.gameObject.CompareTag("Warp2_2On"))
                {
                    this.gameObject.transform.position = Warp2_1.transform.position;
                }

                if (this.gameObject.CompareTag("Warp3_1On"))
                {
                    this.gameObject.transform.position = Warp3_2.transform.position;
                }

                if (this.gameObject.CompareTag("Warp3_2On"))
                {
                    this.gameObject.transform.position = Warp3_1.transform.position;
                }
                    /*-----ここまでワープ床の処理-----*/


                    /*-----ここから落とし穴の処理-----*/
                    if (this.gameObject.CompareTag("HoleFloor"))    //落とし穴の場合
                {
                    if (count == 50)    //カウントが50になったら
                    {
                        //カウントが50に達したので停止判定を偽にし、カウントをリセット
                        stopJudge = false;
                        count = 0;
                        moveJudge = true;
                    }
                    else if (moveJudge == false)    //移動判定が偽の場合
                    {
                        stopJudge = true;   //一時的に動きを止めるために停止判定を真にする
                        count += 1; //FixedUpdateで一秒を計測するために50回カウントを行う
                    }
                    /*-----ここから点滅処理-----*/
                    // 内部時刻を経過させる
                    _time += Time.deltaTime;
                    // 周期cycleで繰り返す値の取得
                    // 0～cycleの範囲の値が得られる
                    var repeatValue = Mathf.Repeat(_time, _cycle);
                    //内部時刻timeにおける明滅状態を反映
                    _target.enabled = repeatValue >= _cycle * 0.2f;
                    /*-----ここまで点滅処理-----*/
                }
                /*-----ここまで落とし穴の処理-----*/


                /*-----ここからゴール床の処理*/
                if (this.gameObject.CompareTag("GoalFloor"))    //ゴール床の場合
                {
                    var tagId = this.gameObject.tag;
                    if (tagId == "Player")
                    {
                        movePosition = new Vector3(0, 0, 0);
                    }
                }
                /*-----ここまでゴール床の処理*/


            }

            /*-----ここから通行止め床の処理-----*/
            if (this.gameObject.CompareTag("StopFloor"))    //通行止め床の場合
            {
                var tagId = this.gameObject.tag;
                if (tagId == "Player")
                {
                    movePosition = new Vector3(0, 0, 0);
                    transform.position = dragDropScript.prePosition;
                }
            }
            /*-----ここまで通行止め床の処理-----*/


            /*-----ここから障害物床の処理-----*/
            if (this.gameObject.CompareTag("障害物床"))
            {
                movePosition = new Vector3(0, 0, 0);
            }
            /*-----ここまで障害物床の処理-----*/


            /*-----ここから敵オブジェクトの処理-----*/
            if (this.gameObject.CompareTag("Enemy"))    //敵の場合
            {
                movePosition = new Vector3(0, 0, 0);
            }
            /*-----ここまで敵オブジェクトの処理-----*/


            if (stopJudge == false) //移動処理
            {
                //回転していないときのみ移動可能
                player.transform.position = Vector3.MoveTowards(player.transform.position, movePosition, speed * Time.deltaTime);   //移動開始(playerオブジェクトが, 目的地に移動, 移動速度)
            }


            //指定した場所にオブジェクトが移動すると、再度移動処理が可能になる
            if (player.transform.position == movePosition) moveJudge = false;
        }
        else //再生中でない場合
        {
            Time.timeScale = 0; //一時停止する
        }

        if(hogehoge == true)
        {
            transform.position = dragDropScript.prePosition;
        }
    }
}