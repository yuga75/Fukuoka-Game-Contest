﻿using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;   //(操作)移動したいオブジェクトを設定
    public Vector3 movePosition;　//移動する距離を格納
    public int speed = 5;　//1マス毎に移動するスピード
    public float rotateSpeed = 7.2f;   //回転スピード
    public Vector3 moveY = new Vector3(0, 1, 0);　//(1マス毎の)Y軸の移動距離
    public Vector3 moveX = new Vector3(1, 0, 0);　//(1マス毎の)X軸の移動距離
    int count = 0;
    bool hogehoge;
    bool firstMoveJudge;    //最初のフレームの移動判定
    bool moveJudge; //移動中の判定
    bool rotateJudge;   //回転中の判定

    void Start()
    {
        //初期設定
        firstMoveJudge = true;
        moveJudge = false;
        rotateJudge = false;
    }

    void FixedUpdate()
    {
        //移動場所設定
        //移動を行うと、moveJudge = true に変わり、一時的に移動の分岐処理を無効化
        if (hogehoge == true)   //再生判定が真である
        {
            //最初のフレームは独立した移動処理を行う
            if (firstMoveJudge == true && this.gameObject.CompareTag("通常床"))
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, movePosition, speed * Time.deltaTime);
                firstMoveJudge = false;
            }
            else
            {
                movePosition = new Vector3(0, 0, 0);
            }

            if (moveJudge == false)
            {

                /*-----ここから回転床の処理-----*/
                if (this.gameObject.CompareTag("回転床"))
                {
                    if (count == 50)
                    {
                        rotateJudge = false;
                        count = 0;
                    }

                    if (rotateJudge == false)
                    {
                        movePosition = player.transform.position + moveY;  //movePositionに移動する距離を格納
                        moveJudge = true;  //moveButtonJudge = trueにして、移動を制限する
                    }
                    else if(moveJudge == false)
                    {
                        rotateJudge = true;
                        gameObject.transform.Rotate(new Vector3(0, this.rotateSpeed, 0));
                        count += 1;
                    }
                }
                /*-----ここまで回転床の処理-----*/

                /*-----ここから昼夜床の処理-----*/
                /*-----ここまで昼夜床の処理-----*/

                /*-----ここからワープ床の処理-----*/
                /*-----ここまでワープ床の処理-----*/

                /*-----ここから落とし穴の処理-----*/
                /*-----ここまで落とし穴の処理-----*/

                /*-----ここから通行止め床の処理-----*/
                if (this.gameObject.CompareTag("通行止め床"))
                {

                }
                /*-----ここまで通行止め床の処理-----*/
            }
        }

        if (rotateJudge == false)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, movePosition, speed * Time.deltaTime);   //移動開始(playerオブジェクトが, 目的地に移動, 移動速度)
        }


        //指定した場所にオブジェクトが移動すると、再度移動処理が可能になる
        if (player.transform.position == movePosition) moveJudge = false;
    }
}