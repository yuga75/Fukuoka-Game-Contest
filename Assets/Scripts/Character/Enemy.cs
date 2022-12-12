using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    MainEvent mainEvent;
    public GameObject enemy;   //(操作)移動したいオブジェクトを設定
    Vector3 movePosition;　//移動する距離を格納
    public int speed = 1;　//1マス毎に移動するスピード
    public Vector3 moveY = new Vector3(0, 1, 0);　//(1マス毎の)Y軸の移動距離
    public Vector3 moveX = new Vector3(1, 0, 0);　//(1マス毎の)X軸の移動距離
    [SerializeField] bool moveJudge; //移動中の判定
    [SerializeField] bool stopJudge;
    string startTag;
    public string direction;
    public string enemyState;
    public Vector3 firstPosition;
    public Vector3 transPosition;

    int count = 0;
    float rotateSpeed = 7.2f;

    // 点滅させる対象
    [SerializeField] private Renderer _target;
    // 点滅周期[s]
    [SerializeField] private float _cycle = 0.25f;

    private float _time;

    public GameObject Warp1_1;
    public GameObject Warp1_2;
    public GameObject Warp2_1;
    public GameObject Warp2_2;
    public GameObject Warp3_1;
    public GameObject Warp3_2;

    public Vector3 warp1_1;
    public Vector3 warp1_2;
    public Vector3 warp2_1;
    public Vector3 warp2_2;
    public Vector3 warp3_1;
    public Vector3 warp3_2;

    public GameObject PlayButton;
    public GameObject PauseButton;
    public GameObject FastButton;
    public GameObject ResetButton;

    MainEvent playButton;
    MainEvent pauseButton;
    MainEvent fastButton;
    MainEvent resetButton;

    public Sprite enemyUp;      //敵上向き画像
    public Sprite enemyDown;    //敵下向き画像
    public Sprite enemyRight;   //敵右向き画像
    public Sprite enemyLeft;    //敵左向き画像
    // 画像描画用のコンポーネント
    SpriteRenderer sr;

    public GameObject ObstacleFloor;
    public GameObject StopFloor;

    public GameObject Player;
    PlayerTest playerTest;

    void Start()
    {
        enemyState = "Noon";
        startTag = this.gameObject.tag;
        moveJudge = false; //⑤初期設定
        sr = gameObject.GetComponent<SpriteRenderer>();
        firstPosition = enemy.transform.position;

        PlayButton = GameObject.Find("PlayButton");
        playButton = PlayButton.GetComponent<MainEvent>();
        PauseButton = GameObject.Find("PauseButton");
        pauseButton = PauseButton.GetComponent<MainEvent>();
        FastButton = GameObject.Find("FastButton");
        fastButton = FastButton.GetComponent<MainEvent>();
        ResetButton = GameObject.Find("ResetButton");
        resetButton = ResetButton.GetComponent<MainEvent>();

        ObstacleFloor = GameObject.Find("ObstacleFloor");
        StopFloor = GameObject.Find("StopFloor");

        Player = GameObject.Find("Player");
        playerTest = Player.GetComponent<PlayerTest>();

        //Player = GameObject.Find("Player");
        //playerTest = Player.GetComponent<PlayerTest>();

        if (this.gameObject.tag == "EnemyUp")
        {
            sr.sprite = enemyUp;
            direction = "Up";
        }

        else if (this.gameObject.tag == "EnemyDown")
        {
            sr.sprite = enemyDown;
            direction = "Down";
        }
        else if (this.gameObject.tag == "EnemyRight")
        {
            sr.sprite = enemyRight;
            direction = "Right";
        }
        else if (this.gameObject.tag == "EnemyLeft")
        {
            sr.sprite = enemyLeft;
            direction = "Left";
        }


        /*-----設置していないワープオブジェクトは下記のようにコメントアウトしてください
         *-----コメントアウトされていないとバグります-----*/
        //warp1_1 = GameObject.Find("Warp1_1").transform.position;
        //warp1_2 = GameObject.Find("Warp1_2").transform.position;
        warp2_1 = GameObject.Find("Warp2_1").transform.position;
        warp2_2 = GameObject.Find("Warp2_2").transform.position;
        //warp3_1 = GameObject.Find("Warp3_1").transform.position;
        //warp3_2 = GameObject.Find("Warp3_2").transform.position;
    }

    void FixedUpdate()
    {
        Time.timeScale = 1;
        //移動場所設定
        if (moveJudge == false && stopJudge == false)
        {
            if (direction == "Up")
            {
                sr.sprite = enemyUp;
                movePosition = enemy.transform.position + moveY;  //movePositionに移動する距離を格納
                moveJudge = true;  //moveButtonJudge = trueにして、移動を制限する
            }
            if (direction == "Down")
            {

                sr.sprite = enemyDown;
                movePosition = enemy.transform.position + -moveY;
                moveJudge = true;

            }
            if (direction == "Right")
            {

                sr.sprite = enemyRight;
                movePosition = enemy.transform.position + moveX;
                moveJudge = true;
            }
            if (direction == "Left")
            {

                sr.sprite = enemyLeft;
                movePosition = enemy.transform.position + -moveX;
                moveJudge = true;
            }
        }

        if (playerTest.playerState == "Human")
        {
            enemyState = "Noon";
        }
        else
        {
            enemyState = "Night";
        }

        if (stopJudge == false)
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, movePosition, speed * Time.deltaTime);   //移動開始(playerオブジェクトが, 目的地に移動, 移動速度)
        }

        //指定した場所にオブジェクトが移動すると、再度移動が可能になる
        if (enemy.transform.position == movePosition)
        {
            moveJudge = false;
            stopJudge = true;
        }

    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (stopJudge == true)
        {
            /*-----ここから通常床の処理-----*/
            if (col.gameObject.tag == "NormalFloor")
            {
                stopJudge = false;
            }
            /*-----ここまで通常床の処理-----*/


            /*-----ここから回転床の処理-----*/
            if (col.gameObject.tag == "TurnUpOn")
            {
                Debug.Log("Hit");
                if (count == 50)
                {
                    //FixedUpdateで一秒を計測するために50回カウントを行う
                    if (this.gameObject.tag == "EnemyUp"
                       || this.gameObject.tag == "EnemyDown"
                       || this.gameObject.tag == "EnemyRight"
                       || this.gameObject.tag == "EnemyLeft"
                      )
                    {
                        sr.sprite = enemyUp;
                    }
                    stopJudge = false;
                    count = 0;
                    direction = "Up";
                    this.tag = "Enemy" + direction;
                    Debug.Log("TurnUp" + direction);
                }

                if (stopJudge == false)
                {
                    movePosition = enemy.transform.position + moveY;  //movePositionに移動する距離を格納
                    moveJudge = true;  //moveButtonJudge = trueにして、処理を制限する
                }
                else if (moveJudge == false)
                {
                    gameObject.transform.Rotate(new Vector3(0, this.rotateSpeed, 0));
                    count += 1;
                    Debug.Log("TurnUp" + count);
                }
            }

            if (col.gameObject.tag == "TurnDownOn")
            {
                if (count == 50)
                {
                    //FixedUpdateで一秒を計測するために50回カウントを行う
                    if (this.gameObject.tag == "EnemyUp"
                       || this.gameObject.tag == "EnemyDown"
                       || this.gameObject.tag == "EnemyRight"
                       || this.gameObject.tag == "EnemyLeft"
                       )
                    {
                        sr.sprite = enemyDown;
                    }
                    stopJudge = false;
                    count = 0;
                    direction = "Down";
                    this.tag = "Enemy" + direction;
                    Debug.Log("TurnDown" + direction);
                }

                if (stopJudge == false)
                {
                    movePosition = enemy.transform.position + -moveY;  //movePositionに移動する距離を格納
                    moveJudge = true;  //moveButtonJudge = trueにして、処理を制限する
                }
                else if (moveJudge == false)
                {
                    gameObject.transform.Rotate(new Vector3(0, this.rotateSpeed, 0));
                    count += 1;
                    Debug.Log("TurnDown" + count);
                }
            }

            if (col.gameObject.tag == "TurnRightOn")
            {
                if (count == 50)
                {
                    //FixedUpdateで一秒を計測するために50回カウントを行う
                    if (this.gameObject.tag == "EnemyUp"
                       || this.gameObject.tag == "EnemyDown"
                       || this.gameObject.tag == "EnemyRight"
                       || this.gameObject.tag == "EnemyLeft"
                       )
                    {
                        sr.sprite = enemyRight;
                    }
                    stopJudge = false;
                    count = 0;
                    direction = "Right";
                    this.tag = "Enemy" + direction;
                    Debug.Log("TurnRight" + direction);
                }

                if (stopJudge == false)
                {
                    movePosition = enemy.transform.position + moveX;  //movePositionに移動する距離を格納
                    moveJudge = true;  //moveButtonJudge = trueにして、処理を制限する
                }
                else if (moveJudge == false)
                {
                    gameObject.transform.Rotate(new Vector3(0, this.rotateSpeed, 0));
                    count += 1;
                    Debug.Log("TurnRight" + count);
                }
            }

            if (col.gameObject.tag == "TurnLeftOn")
            {
                if (count == 50)
                {
                    //FixedUpdateで一秒を計測するために50回カウントを行う
                    if (this.gameObject.tag == "EnemyUp"
                       || this.gameObject.tag == "EnemyDown"
                       || this.gameObject.tag == "EnemyRight"
                       || this.gameObject.tag == "EnemyLeft"
                       )
                    {
                        sr.sprite = enemyLeft;
                    }
                    stopJudge = false;
                    count = 0;
                    direction = "Left";
                    this.tag = enemyState + direction;
                    Debug.Log("TurnLeft" + direction);
                }

                if (stopJudge == false)
                {
                    movePosition = enemy.transform.position + -moveX;  //movePositionに移動する距離を格納
                    moveJudge = true;  //moveButtonJudge = trueにして、処理を制限する
                }
                else if (moveJudge == false)
                {
                    gameObject.transform.Rotate(new Vector3(0, this.rotateSpeed, 0));
                    count += 1;
                    Debug.Log("TurnLeft" + count);
                }
            }
            /*-----ここまで回転床の処理-----*/


            /*-----ここから昼夜床の処理-----*/
            if (col.gameObject.tag == "DayOn")
            {
                Debug.Log("HitDay");
                if (enemyState == "Noon")
                {
                    enemyState = "Night";
                    this.tag = "Enemy" + direction;
                    Debug.Log(enemyState);
                }
                else
                {
                    enemyState = "Noon";
                    this.tag = "Enemy" + direction;
                    Debug.Log(enemyState);
                }
                stopJudge = false;
            }
            /*-----ここまで昼夜床の処理-----*/


            /*-----ここから落とし穴の処理-----*/
            if (col.gameObject.tag == "HoleOn")
            {
                if (count == 50)
                {
                    stopJudge = false;
                    count = 0;
                }

                if (stopJudge == false)
                {
                    if (direction == "Up")
                    {
                        movePosition = enemy.transform.position + moveY;
                    }
                    else if (direction == "Down")
                    {
                        movePosition = enemy.transform.position + -moveY;
                    }
                    else if (direction == "Right")
                    {
                        movePosition = enemy.transform.position + moveX;
                    }
                    else
                    {
                        movePosition = enemy.transform.position + -moveX;
                    }
                    moveJudge = true;  //moveButtonJudge = trueにして、処理を制限する
                }
                else if (moveJudge == false)
                {
                    gameObject.transform.Rotate(new Vector3(0, 360, 0));

                    // 内部時刻を経過させる
                    _time += Time.deltaTime;

                    // 周期cycleで繰り返す値の取得
                    // 0～cycleの範囲の値が得られる
                    var repeatValue = Mathf.Repeat(_time, _cycle);

                    // 内部時刻timeにおける明滅状態を反映
                    _target.enabled = repeatValue >= _cycle * 0.5f;

                    count += 1;
                    Debug.Log("Hole" + count);
                }
            }
            /*-----ここまで落とし穴の処理-----*/


            /*-----ここからワープ床の処理-----*/
            if (col.gameObject.tag == "Warp1_1On")
            {
                if (stopJudge == true)
                {
                    stopJudge = false;
                    enemy.gameObject.transform.position = warp1_2;
                    Debug.Log("Hit1_1");
                }
                else
                {
                    Debug.Log("Arrived1_1");
                }
            }
            else if (col.gameObject.tag == "Warp1_2On" && stopJudge == true)
            {
                if (stopJudge == true)
                {
                    stopJudge = false;
                    enemy.gameObject.transform.position = warp1_1;
                    Debug.Log("Hit1_2");
                }
                else
                {
                    Debug.Log("Arrived1_2");
                }
            }

            if (col.gameObject.tag == "Warp2_1On" && stopJudge == true)
            {
                if (stopJudge == true)
                {
                    stopJudge = false;
                    enemy.gameObject.transform.position = warp2_2;
                    Debug.Log("Hit2_1");
                }
                else
                {
                    Debug.Log("Arrived2_1");
                }
            }
            else if (col.gameObject.tag == "Warp2_2On" && stopJudge == true)
            {
                if (stopJudge == true)
                {
                    stopJudge = false;
                    enemy.gameObject.transform.position = warp2_1;
                    Debug.Log("Hit2_2");
                }
                else
                {
                    Debug.Log("Arrived2_2");
                }
            }

            if (col.gameObject.tag == "Warp3_1On" && stopJudge == true)
            {
                if (stopJudge == true)
                {
                    stopJudge = false;
                    enemy.gameObject.transform.position = warp3_2;
                    Debug.Log("Hit3_1");
                }
                else
                {
                    Debug.Log("Arrived3_1");
                }
            }
            else if (col.gameObject.tag == "Warp3_2On" && stopJudge == true)
            {
                if (stopJudge == true)
                {
                    stopJudge = false;
                    enemy.gameObject.transform.position = warp3_1;
                    Debug.Log("Hit3_2");
                }
                else
                {
                    Debug.Log("Arrived3_2");
                }
            }
            /*-----ここまでワープ床の処理-----*/


            /*-----ここからゴール床の処理-----*/
            if (col.gameObject.tag == "GoalHuman")
            {
                stopJudge = false;
            }
            /*-----ここまでゴール床の処理-----*/
        }


        /*-----ここから通行止め床の処理-----*/
        if (col.gameObject.tag == "StopOn")
        {
            Debug.Log("HitStop");
            if (enemyState == "Night")
            {
                stopJudge = false;
            }
        }
        /*-----ここから通行止め床の処理-----*/


        /*-----ここからプレイヤーの処理-----*/
        if (col.gameObject.tag == "HumanUp"
            || col.gameObject.tag == "HumanDown"
            || col.gameObject.tag == "HumanRight"
            || col.gameObject.tag == "HumanLeft"
            || col.gameObject.tag == "WolfUp"
            || col.gameObject.tag == "WolfDown"
            || col.gameObject.tag == "WolfRight"
            || col.gameObject.tag == "WolfLeft"
            )
        {
            stopJudge = true;
            movePosition = enemy.transform.position;
            Debug.Log("HitPlayer");
            StartCoroutine(Failed());
        }
        /*-----ここまでプレイヤ―の処理-----*/
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        /*-----ここから障害物床の処理-----*/
        if (col.gameObject.tag == "ObstacleFloor")
        {
            if (direction == "Up")
            {
                direction = "Down";
                sr.sprite = enemyDown;
                movePosition = enemy.transform.position + -moveY;
            }
            else if (direction == "Down")
            {
                direction = "Up";
                sr.sprite = enemyUp;
                movePosition = enemy.transform.position + moveY;
            }
            else if (direction == "Right")
            {
                direction = "Left";
                sr.sprite = enemyLeft;
                movePosition = enemy.transform.position + -moveX;
            }
            else if (direction == "Left")
            {
                direction = "Right";
                sr.sprite = enemyRight;
                movePosition = enemy.transform.position + moveX;
            }
            stopJudge = false;
        }
        /*-----ここまで障害物床の処理-----*/
    }

    IEnumerator Failed()
    {
        yield return new WaitForSeconds(3);
        StartCoroutine(Reset());
    }

    IEnumerator Reset()
    {
        //終わるまで待ってほしい処理を書く
        //例：敵が倒れるアニメーションを開始
        yield return new WaitForSeconds(0);

        //再開してから実行したい処理を書く
        //例：敵オブジェクトを破壊
        this.gameObject.transform.position = firstPosition;
        this.tag = startTag;
        Start();
    }
}
