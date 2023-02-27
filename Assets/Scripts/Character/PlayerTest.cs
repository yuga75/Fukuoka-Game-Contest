using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    MainEvent mainEvent;
    public DragDropScript dropScript;
    public GameObject player;   //(操作)移動したいオブジェクトを設定
    Vector3 movePosition;　//移動する距離を格納
    public int speed = 1;　//1マス毎に移動するスピード
    public Vector3 moveY = new Vector3(0, 1, 0);　//(1マス毎の)Y軸の移動距離
    public Vector3 moveX = new Vector3(1, 0, 0);　//(1マス毎の)X軸の移動距離
    bool moveJudge; //移動中の判定
    bool stopJudge;
    bool firstJudge;
    public Vector3 currentPosition;
    string startTag;
    public string direction;
    public string playerState;
    public Vector3 firstPosition;
    public Vector3 transPosition;
    Quaternion rotatePosition;
    Vector3 tmp;

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

    public GameObject ControllButton;
    ControllButton controllButton;

    public Sprite humanUp;      //人間上向き画像
    public Sprite humanDown;    //人間下向き画像
    public Sprite humanRight;   //人間右向き画像
    public Sprite humanLeft;    //人間左向き画像
    public Sprite humanGoal;    //人間ゴール画像
    public Sprite humanOut;     //人間失敗画像
    public Sprite wolfUp;       //狼上向き画像
    public Sprite wolfDown;     //狼下向き画像
    public Sprite wolfRight;    //狼右向き画像
    public Sprite wolfLeft;     //狼左向き画像
    public Sprite wolfGoal;     //狼ゴール画像
    public Sprite wolfOut;      //狼失敗画像
    // 画像描画用のコンポーネント
    SpriteRenderer sr;

    public GameObject Enemy;
    Enemy enemy;

    public GameObject bgm;
    AudioSource BGM;

    AudioSource audioSource;

    public AudioClip footstepsSound;
    public AudioClip TurnFloorSound;
    public AudioClip WarpFloorSound;
    public AudioClip HoleFloorSound;
    public AudioClip DayFloorSound;
    public AudioClip playerClearSound;
    public AudioClip playerFailedSound;

    bool OneTime;
    public void Start()
    {
        startTag = this.gameObject.tag;
        moveJudge = false; //⑤初期設定
        sr = gameObject.GetComponent<SpriteRenderer>();

        ControllButton = GameObject.Find("ControllButton(empty)");
        controllButton = ControllButton.GetComponent<ControllButton>();

        Enemy = GameObject.Find("Enemy");
        enemy = Enemy.GetComponent<Enemy>();

        firstPosition = this.gameObject.transform.position;

        audioSource = GetComponent<AudioSource>();

        bgm = GameObject.Find("BGM");
        BGM = bgm.GetComponent<AudioSource>();

        rotatePosition = this.gameObject.transform.rotation;

        OneTime = true;

        if (this.gameObject.tag == "HumanUp")
        {
            playerState = "Human";
            sr.sprite = humanUp;
            direction = "Up";
        }
        else if (this.gameObject.tag == "WolfUp")
        {
            playerState = "Wolf";
            sr.sprite = wolfUp;
            direction = "Up";
        }
        else if (this.gameObject.tag == "HumanDown")
        {
            playerState = "Human";
            sr.sprite = humanDown;
            direction = "Down";
        }
        else if (this.gameObject.tag == "WolfDown")
        {
            playerState = "Wolf";
            sr.sprite = wolfDown;
            direction = "Down";
        }
        else if (this.gameObject.tag == "HumanRight")
        {
            playerState = "Human";
            sr.sprite = humanRight;
            direction = "Right";
        }
        else if (this.gameObject.tag == "WolfRight")
        {
            playerState = "Wolf";
            sr.sprite = wolfRight;
            direction = "Right";
        }
        else if (this.gameObject.tag == "HumanLeft")
        {
            playerState = "Human";
            sr.sprite = humanLeft;
            direction = "Left";
        }
        else if (this.gameObject.tag == "WolfLeft")
        {
            playerState = "Wolf";
            sr.sprite = wolfLeft;
            direction = "Left";
        }


        /*-----設置していないワープオブジェクトは下記のようにコメントアウトしてください
         *-----コメントアウトされていないとバグります-----*/
        warp1_1 = GameObject.Find("Warp1_1").transform.position;
        warp1_2 = GameObject.Find("Warp1_2").transform.position;
        warp2_1 = GameObject.Find("Warp2_1").transform.position;
        warp2_2 = GameObject.Find("Warp2_2").transform.position;
        warp3_1 = GameObject.Find("Warp3_1").transform.position;
        warp3_2 = GameObject.Find("Warp3_2").transform.position;
    }

    private void Update()
    {
        if (controllButton.play == true
            && (playerState != "humanFailed" || playerState != "wolfFailed"))
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }

        if ((stopJudge == true) && (count % 2 == 0))
        {
            if (controllButton.fast == true)
            {
                speed = 2;
                rotateSpeed = 14.4f;
            }
            else
            {
                speed = 1;
                rotateSpeed = 7.2f;
            }
        }
        else if (stopJudge == false)
        {
            if (controllButton.fast == true)
            {
                speed = 2;
                rotateSpeed = 14.4f;
                _cycle = 0.125f;
            }
            else
            {
                speed = 1;
                rotateSpeed = 7.2f;
                _cycle = 0.25f;
            }
        }

        if((playerState == "humanFailed" || playerState == "wolfFailed") && enemy.enemyState == "Failed")
        {
            StartCoroutine(Failed());
        }
    }

    void FixedUpdate()
    {
        //移動場所設定
        if (moveJudge == false 
            && stopJudge == false
            && (playerState != "humanFailed" || playerState != "wolfFailed"))
        {
            if (direction == "Up")
            {
                movePosition = player.transform.position + moveY;  //movePositionに移動する距離を格納
                moveJudge = true;  //moveButtonJudge = trueにして、移動を制限する
            }
            if (direction == "Down")
            {
                movePosition = player.transform.position + -moveY;
                moveJudge = true;
            }
            if (direction == "Right")
            {
                movePosition = player.transform.position + moveX;
                moveJudge = true;
            }
            if (direction == "Left")
            {
                movePosition = player.transform.position + -moveX;
                moveJudge = true;
            }

        }

        tmp = GameObject.Find("Player").transform.position;

        if (stopJudge == false)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, movePosition, speed * Time.deltaTime);   //移動開始(playerオブジェクトが, 目的地に移動, 移動速度)
            audioSource.enabled = footstepsSound;
        }


        //指定した場所にオブジェクトが移動すると、再度移動が可能になる
        if (player.transform.position == movePosition)
        {
            moveJudge = false;
            stopJudge = true;
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (controllButton.play == true
            && (playerState != "humanFailed" || playerState != "wolfFailed"))
        {
            if (stopJudge == true)
            {
                /*-----ここから通常床の処理-----*/
                if ((col.gameObject.tag == "NormalFloor"
                    || col.gameObject.tag == "TurnUpOff"
                    || col.gameObject.tag == "TurnDownOff"
                    || col.gameObject.tag == "TurnRightOff"
                    || col.gameObject.tag == "TurnLeftOff"
                    || col.gameObject.tag == "DayOn"
                    || col.gameObject.tag == "Warp1_1Off"
                    || col.gameObject.tag == "Warp1_2Off"
                    || col.gameObject.tag == "Warp2_1Off"
                    || col.gameObject.tag == "Warp2_2Off"
                    || col.gameObject.tag == "Warp3_1Off"
                    || col.gameObject.tag == "Warp3_2Off"
                    || col.gameObject.tag == "HoleOff"
                    || col.gameObject.tag == "StopOff"
                    || col.gameObject.tag == "NormalFloor2")
                    && col.gameObject.tag != "Enemy"
                    && playerState != "Failed")
                {
                    audioSource.PlayOneShot(footstepsSound);
                    stopJudge = false;
                }
                /*-----ここまで通常床の処理-----*/


                /*-----ここから回転床の処理-----*/
                if (col.gameObject.tag == "TurnUpOn")
                {
                    if (count == 50)
                    {
                        //FixedUpdateで一秒を計測するために50回カウントを行う
                        if (this.gameObject.tag == "HumanDown"
                           || this.gameObject.tag == "HumanRight"
                           || this.gameObject.tag == "HumanLeft"
                          )
                        {
                            sr.sprite = humanUp;
                        }
                        else if (this.gameObject.tag == "WolfDown"
                                || this.gameObject.tag == "WolfRight"
                                || this.gameObject.tag == "WolfLeft"
                                )
                        {
                            sr.sprite = wolfUp;
                        }
                        stopJudge = false;
                        count = 0;
                        direction = "Up";
                        this.tag = playerState + direction;
                        Debug.Log("TurnUp" + direction);
                    }

                    if (this.gameObject.tag == "HumanUp"
                        || this.gameObject.tag == "WolfUp")
                    {
                        stopJudge = false;
                    }

                    if (stopJudge == false)
                    {
                        movePosition = player.transform.position + moveY;  //movePositionに移動する距離を格納
                        moveJudge = true;  //moveButtonJudge = trueにして、処理を制限する
                    }
                    else if (moveJudge == false)
                    {
                        gameObject.transform.Rotate(new Vector3(0, this.rotateSpeed, 0));
                        if ((controllButton.fast == true) && (count % 2 == 0))
                        {
                            count += 2;
                        }
                        else
                        {
                            count += 1;
                        }
                        Debug.Log("TurnUp" + count);
                    }
                }

                if (col.gameObject.tag == "TurnDownOn")
                {
                    if (count == 50)
                    {
                        //FixedUpdateで一秒を計測するために50回カウントを行う
                        if (this.gameObject.tag == "HumanUp"
                           || this.gameObject.tag == "HumanRight"
                           || this.gameObject.tag == "HumanLeft"
                           )
                        {
                            sr.sprite = humanDown;
                        }
                        else if (this.gameObject.tag == "WolfUp"
                                || this.gameObject.tag == "WolfRight"
                                || this.gameObject.tag == "WolfLeft"
                                )
                        {
                            sr.sprite = wolfDown;
                        }
                        stopJudge = false;
                        count = 0;
                        direction = "Down";
                        this.tag = playerState + direction;
                        Debug.Log("TurnDown" + direction);
                    }

                    if (this.gameObject.tag == "HumanDown"
                        || this.gameObject.tag == "WolfDown")
                    {
                        stopJudge = false;
                    }

                    if (stopJudge == false)
                    {
                        movePosition = player.transform.position + -moveY;  //movePositionに移動する距離を格納
                        moveJudge = true;  //moveButtonJudge = trueにして、処理を制限する
                    }
                    else if (moveJudge == false)
                    {
                        gameObject.transform.Rotate(new Vector3(0, this.rotateSpeed, 0));
                        if ((controllButton.fast == true) && (count % 2 == 0))
                        {
                            count += 2;
                        }
                        else
                        {
                            count += 1;
                        }
                        Debug.Log("TurnDown" + count);
                    }
                }

                if (col.gameObject.tag == "TurnRightOn")
                {
                    if (count == 50)
                    {
                        //FixedUpdateで一秒を計測するために50回カウントを行う
                        if (this.gameObject.tag == "HumanUp"
                           || this.gameObject.tag == "HumanDown"
                           || this.gameObject.tag == "HumanLeft"
                           )
                        {
                            sr.sprite = humanRight;
                        }
                        else if (this.gameObject.tag == "WolfUp"
                                || this.gameObject.tag == "WolfDown"
                                || this.gameObject.tag == "WolfLeft"
                                )
                        {
                            sr.sprite = wolfRight;
                        }
                        stopJudge = false;
                        count = 0;
                        direction = "Right";
                        this.tag = playerState + direction;
                        Debug.Log("TurnRight" + direction);
                    }

                    if (this.gameObject.tag == "HumanRight"
                        || this.gameObject.tag == "WolfRight")
                    {
                        stopJudge = false;
                    }

                    if (stopJudge == false)
                    {
                        movePosition = player.transform.position + moveX;  //movePositionに移動する距離を格納
                        moveJudge = true;  //moveButtonJudge = trueにして、処理を制限する
                    }
                    else if (moveJudge == false)
                    {
                        gameObject.transform.Rotate(new Vector3(0, this.rotateSpeed, 0));
                        if ((controllButton.fast == true) && (count % 2 == 0))
                        {
                            count += 2;
                        }
                        else
                        {
                            count += 1;
                        }
                        Debug.Log("TurnRight" + count);
                    }
                }

                if (col.gameObject.tag == "TurnLeftOn")
                {
                    if (count == 50)
                    {
                        //FixedUpdateで一秒を計測するために50回カウントを行う
                        if (this.gameObject.tag == "HumanUp"
                           || this.gameObject.tag == "HumanDown"
                           || this.gameObject.tag == "HumanRight"
                           )
                        {
                            sr.sprite = humanLeft;
                        }
                        else if (this.gameObject.tag == "WolfUp"
                                || this.gameObject.tag == "WolfDown"
                                || this.gameObject.tag == "WolfRight"
                                )
                        {
                            sr.sprite = wolfLeft;
                        }
                        stopJudge = false;
                        count = 0;
                        direction = "Left";
                        this.tag = playerState + direction;
                        Debug.Log("TurnLeft" + direction);
                    }

                    if (this.gameObject.tag == "HumanLeft"
                        || this.gameObject.tag == "WolfLeft")
                    {
                        stopJudge = false;
                    }

                    if (stopJudge == false)
                    {
                        movePosition = player.transform.position + -moveX;  //movePositionに移動する距離を格納
                        moveJudge = true;  //moveButtonJudge = trueにして、処理を制限する
                    }
                    else if (moveJudge == false)
                    {
                        gameObject.transform.Rotate(new Vector3(0, this.rotateSpeed, 0));
                        if ((controllButton.fast == true) && (count % 2 == 0))
                        {
                            count += 2;
                        }
                        else
                        {
                            count += 1;
                        }
                        Debug.Log("TurnLeft" + count);
                    }
                }
                /*-----ここまで回転床の処理-----*/


                /*-----ここから落とし穴の処理-----*/
                if (col.gameObject.tag == "HoleOn")
                {
                    if (count == 50)
                    {
                        stopJudge = false;
                        this.gameObject.SetActive(true);
                        count = 0;
                    }

                    if (stopJudge == false)
                    {
                        this.gameObject.SetActive(true);
                        if (direction == "Up")
                        {
                            movePosition = player.transform.position + moveY;
                        }
                        else if (direction == "Down")
                        {
                            movePosition = player.transform.position + -moveY;
                        }
                        else if (direction == "Right")
                        {
                            movePosition = player.transform.position + moveX;
                        }
                        else
                        {
                            movePosition = player.transform.position + -moveX;
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
                        if (count % 4 == 50 % 4)
                        {
                            _target.enabled = repeatValue >= _cycle * 0.5f;
                        }

                        if ((controllButton.fast == true) && (count % 2 == 0))
                        {
                            count += 2;
                        }
                        else
                        {
                            count += 1;
                        }
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
                        player.gameObject.transform.position = warp1_2;
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
                        player.gameObject.transform.position = warp1_1;
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
                        player.gameObject.transform.position = warp2_2;
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
                        player.gameObject.transform.position = warp2_1;
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
                        player.gameObject.transform.position = warp3_2;
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
                        player.gameObject.transform.position = warp3_1;
                        Debug.Log("Hit3_2");
                    }
                    else
                    {
                        Debug.Log("Arrived3_2");
                    }
                }
                /*-----ここまでワープ床の処理-----*/

                /*-----ここからゴール床の処理-----*/
                if (col.gameObject.tag == "GoalHuman" && OneTime == true)
                {
                    if (playerState == "Human")
                    {
                        StartCoroutine(Cleared());
                    }
                    else
                    {
                        playerState = "wolfFailed";
                        this.gameObject.tag = "WolfFailed";
                    }
                    OneTime = false;
                }
                if (col.gameObject.tag == "GoalWolf" && OneTime == true)
                {
                    if (playerState == "Human")
                    {
                        playerState = "humanFailed";
                        this.gameObject.tag = "HumanFailed";
                    }
                    else
                    {
                        StartCoroutine(Cleared());
                    }
                    OneTime = false;
                }
                /*-----ここまでゴール床の処理-----*/


                
            }

            /*-----ここから通行止め床の処理-----*/
            if (col.gameObject.tag == "StopOn")
            {
                Debug.Log("HitStop");
                if (playerState == "Human")
                {
                    stopJudge = true;
                    movePosition = player.transform.position;
                    playerState = "humanFailed";
                    this.gameObject.tag = "HumanFailed";
                }
                else
                {
                    stopJudge = false;
                }
            }
            /*-----ここから通行止め床の処理-----*/

            /*-----ここから障害物・敵の処理-----*/
            if (col.gameObject.tag == "ObstacleFloor"
                || col.gameObject.tag == "EnemyUp"
                || col.gameObject.tag == "EnemyDown"
                || col.gameObject.tag == "EnemyRight"
                || col.gameObject.tag == "EnemyLeft"
                )
            {
                stopJudge = true;
                movePosition = tmp;
                Debug.Log("HitObstacle");

                if (playerState == "Human")
                {
                    playerState = "humanFailed";
                    this.gameObject.tag = "HumanFailed";
                }
                else
                {
                    playerState = "wolfFailed";
                    this.gameObject.tag = "WolfFailed";
                }
            }
            /*-----ここまで障害物・敵の処理-----*/
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "DayOn")
        {
            audioSource.PlayOneShot(DayFloorSound);
            if (playerState == "Human")
            {
                playerState = "Wolf";
                this.tag = playerState + direction;
                if (direction == "Up")
                {
                    sr.sprite = wolfUp;
                }
                else if (direction == "Down")
                {
                    sr.sprite = wolfDown;
                }
                else if (direction == "Right")
                {
                    sr.sprite = wolfRight;
                }
                else if (direction == "Left")
                {
                    sr.sprite = wolfLeft;
                }
            }
            else
            {
                playerState = "Human";
                this.tag = playerState + direction;
                if (direction == "Up")
                {
                    sr.sprite = humanUp;
                }
                else if (direction == "Down")
                {
                    sr.sprite = humanDown;
                }
                else if (direction == "Right")
                {
                    sr.sprite = humanRight;
                }
                else if (direction == "Left")
                {
                    sr.sprite = humanLeft;
                }
            }
        }

        if (other.gameObject.tag == "Warp1_1On"
            || other.gameObject.tag == "Warp1_2On"
            || other.gameObject.tag == "Warp2_1On"
            || other.gameObject.tag == "Warp2_2On"
            || other.gameObject.tag == "Warp3_1On"
            || other.gameObject.tag == "Warp3_2On")
        {
            audioSource.PlayOneShot(WarpFloorSound);
        }

        if(other.gameObject.tag == "TurnUpOn"
            || other.gameObject.tag == "TurnDownOn"
            || other.gameObject.tag == "TurnRightOn"
            || other.gameObject.tag == "TurnLeftOn")
        {
            audioSource.PlayOneShot(TurnFloorSound);
        }

        if(other.gameObject.tag == "HoleOn")
        {
            audioSource.PlayOneShot(HoleFloorSound);
        }
    }

    IEnumerator Cleared()
    {
        audioSource.enabled = !footstepsSound;
        if (playerState == "Human")
        {
            this.gameObject.tag = "HumanGoaled";
            sr.sprite = humanGoal;
            playerState = "Cleared";
        }
        else
        {
            this.gameObject.tag = "WolfGoaled";
            sr.sprite = wolfGoal;
            playerState = "Cleared";
        }
        audioSource.PlayOneShot(playerClearSound);
        Time.timeScale = 0;
        yield return new WaitForSeconds(2);
        
    }

    IEnumerator Failed()
    {
        audioSource.enabled = !footstepsSound;
        audioSource.PlayOneShot(playerFailedSound);
        this.gameObject.transform.rotation = rotatePosition;
        if (playerState == "humanFailed")
        {
            sr.sprite = humanOut;
            direction = "";
        }
        else if(playerState == "wolfFailed")
        {
            sr.sprite = wolfOut;
            direction = "";
        }
        yield return new WaitForSeconds(3);
    }
}
