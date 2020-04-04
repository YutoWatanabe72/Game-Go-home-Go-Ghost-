using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;

    //カメラのポジション
    const float cameraPosY = 10f;
    const float cameraPosZ = -10f;

    //キャラクターの移動スピード
    public static float playerSpeed;
    private float runSpeed = 30.0f;
    private float maxRun = 45.0f;
    private float reverseRun = -25.0f;
    private float slowRun = 10.0f;

    //キャラクターのジャンプ
    private float jumpPower = 4000f;//ジャンプの強さ
    bool canJump = true;//ジャンプ可能かどうかの判定

    //フィーバータイム
    bool feverEvent = false;//フィーバータイムの判定
    int feverCount = 0;//フィーバータイムになるまでに獲得したカウント数
    const int needFeverCount = 10;//フィーバータイムに必要なアイテムカウント数
    const float feverCheckTime = 5f;//フィーバータイムの時間
    private float feverTime;
    private bool fever;

    const float stageDist = 1000f;//プレイステージの距離

    //HPゲージの回復量
    const int recoverLevel1 = 1000;
    const int recoverLevel2 = 1500;
    const int recoverLevel3 = 2000;

    float deltaTime;//プレイヤーのステータス管理時間
    float destroyTime = 0.25f;//アイテムの消滅時間

    int scoreA;//10点アイテムのカウント数
    int scoreB;//50点アイテムのカウント数
    int scoreC;//100点アイテムのカウント数
    const int scoreMagB = 5;//スコアの倍率
    const int scoreMagC = 10;//　〃

    public GameObject toresultButton;//リザルトシーンへのシーン遷移ボタン
    Button toResult;
    public GameObject Clear;//クリア表示
    public GameObject GameOver;//ゲームオーバー表示
    public GameObject winIrast;//ゲームクリア時のキャラクターのイラスト
    public GameObject loseIrast;//ゲームオーバー時のキャラクターのイラスト
    public GameObject defIrast;//初期イラストの表示
    public GameObject feverIrast;//フィーバータイム中のイラスト
    public Text distansText;//ゴールまでの距離の表示
    public GameObject startText;//スタートロゴの表示
    public GameObject chasecamera;//カメラのポジション

    private playerState state;//プレイヤーのステータス
    private float stateResetTime = 3f;//プレイヤーのステータスをリセットする時間
    private bool Freeze;//プレイヤーが停止しているかどうか
    private bool StartLogoDisp;

    //現在のステータスを表示する画像
    public GameObject freeze;
    public GameObject reverse;
    public GameObject slow;
    enum playerState
    {
        Run,
        Fever,
        Reverse,
        Slow,
        Freeze,
        Gameend
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerSpeed = runSpeed;
        //ステータスのリセット
        scoreA = 0;
        scoreB = 0;
        scoreC = 0;
        state = playerState.Run;
        deltaTime = 0;
        feverTime = 0f;
        //boolの初期化
        fever = false;
        Freeze = false;
        StartLogoDisp = false;
    }

    void Update()
    {
        //タイマーの起動
        this.deltaTime += Time.deltaTime;
        feverTime += Time.deltaTime;

        //プレイヤーとカメラの自動移動
        PlayerandCameraMove();

        //ステータスのリセット
        StatusReset();

        //フィーバータイムの判定
        FeverCheck(feverCount);

        //キャラクターのジャンプ処理
        CanJump();

        //プレイヤーがスタート地点(ｘ=０)に着いたらスタートのテキスト表示
        StartLogoOn();

        //得点処理→Mainに渡すために点数を簡略化
        LifeGage.totalCount = scoreA + (scoreB * scoreMagB) + (scoreC * scoreMagC);

        //ゲームオーバーになった時の処理
        GameEnd();
    }

    /// <summary>
    /// スタート時のロゴの表示
    /// </summary>
    private void StartLogoOn()
    {
        if (!StartLogoDisp)
        {
            if (this.transform.position.x >= -10)
            {
                startText.SetActive(true);
            }
            if (this.transform.position.x >= 20)
            {
                startText.SetActive(false);
                StartLogoDisp = true;
            }
        }
    }

    /// <summary>
    /// プレイヤーとカメラの自動移動
    /// </summary>
    private void PlayerandCameraMove()
    {
        //カメラの自動追尾
        if (chasecamera.transform.position.x <= stageDist || chasecamera.transform.position.x - transform.position.x > 40)
        {
            chasecamera.transform.position = new Vector3(transform.position.x + 40, cameraPosY, cameraPosZ);
        }

        //キャラクターの自動移動
        rb2d.velocity = new Vector2(playerSpeed, rb2d.velocity.y);
        reverse.transform.position = new Vector2(transform.position.x, transform.position.y);
        slow.transform.position = new Vector2(transform.position.x, transform.position.y);
        freeze.transform.position = this.transform.position;

        //ゴールまでの距離の表示
        distansText.text = Mathf.Floor(stageDist - transform.position.x).ToString() + "m/1000m";
    }

    //プレイヤーの当たり判定とジャンプ可否の処理
    public void OnCollisionEnter2D(Collision2D hit)
    {
        //床と接触していればジャンプカウントのリセット
        if (hit.gameObject.CompareTag("Ground") && !Freeze)
        {
            canJump = true;
        }
    }

    private void OnTriggerStay2D(Collider2D stay)
    {
        //ブロック上であればジャンプできるようにする
        if (stay.gameObject.tag == "jump" && !Freeze)
        {
            canJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D exit)
    {
        //ブロックを離れたら自動的にジャンプができないようにする
        if (exit.gameObject.tag == "jump")
        {
            canJump = false;
        }
    }

    /// <summary>
    /// アイテムとの接触処理
    /// </summary>
    /// <param name="hit">当たったアイテム</param>
    void OnTriggerEnter2D(Collider2D hit)
    {
        //ライフゲージの回復・得点の加算
        if (hit.gameObject.tag == "recover1")
        {
            hit.transform.localScale = new Vector2(1, 1);
            LifeGage.playerLife += recoverLevel1;
            scoreA++;
            feverCount++;
            Destroy(hit.gameObject, destroyTime);
        }

        if (hit.gameObject.tag == "recover2")
        {
            hit.transform.localScale = new Vector2(1, 1);
            LifeGage.playerLife += recoverLevel2;
            scoreB++;
            feverCount++;
            Destroy(hit.gameObject, destroyTime);
        }

        if (hit.gameObject.tag == "recover3")
        {
            hit.transform.localScale = new Vector2(1, 1);
            LifeGage.playerLife += recoverLevel3;
            scoreC++;
            feverCount++;
            Destroy(hit.gameObject, destroyTime);
        }

        //トラップアイテムによるプレイヤーのステータスの変更
        if (hit.gameObject.tag == "TrapItemfreeze" || hit.gameObject.tag == "TrapItemreverse" || hit.gameObject.tag == "TrapItemslow")
        {
            if (!fever)
            {
                if (hit.gameObject.tag == "TrapItemreverse")
                {
                    SetState(playerState.Reverse);
                    reverse.SetActive(true);
                    slow.SetActive(false);
                    freeze.SetActive(false);
                }
                if (hit.gameObject.tag == "TrapItemslow")
                {
                    SetState(playerState.Slow);
                    slow.SetActive(true);
                    reverse.SetActive(false);
                    freeze.SetActive(false);
                }
                if (hit.gameObject.tag == "TrapItemfreeze")
                {
                    SetState(playerState.Freeze);
                    freeze.SetActive(true);
                    reverse.SetActive(false);
                    slow.SetActive(false);
                }
                Destroy(hit.gameObject);
            }
            else
            {
                Destroy(hit.gameObject, destroyTime);
            }
        }
    }

    /// <summary>
    /// ステータス別の行動
    /// </summary>
    /// <param name="tempstate">プレイヤーのステータス</param>
    void SetState(playerState tempstate)
    {
        state = tempstate;
        Debug.Log(state);
        if (tempstate == playerState.Run)//通常
        {
            playerSpeed = runSpeed;
            deltaTime = 0f;
            Freeze = false;
            animator.SetBool("Freez",false);
            canJump = true;
        }
        else if (tempstate == playerState.Fever)//フィーバータイム中
        {
            playerSpeed = maxRun;
            deltaTime = 0f;
            animator.SetBool("Reverse", false);
            Freeze = false;
            canJump = true;
        }
        else if (tempstate == playerState.Reverse)//逆走
        {
            playerSpeed = reverseRun;
            animator.SetTrigger("ReverseTrigger");
            deltaTime = 0f;
        }
        else if (tempstate == playerState.Slow)//スロウ
        {
            playerSpeed = slowRun;
            deltaTime = 0f;
        }
        else if (tempstate == playerState.Freeze)//フリーズ
        {
            playerSpeed = 0f;
            animator.SetBool("Reverse", false);
            animator.SetBool("Freez",true);
            deltaTime = 0f;
            Freeze = true;
            canJump = false;
        }
        else if (tempstate == playerState.Gameend)//ゲーム終了
        {
            playerSpeed = 0f;
        }
    }

    /// <summary>
    /// ステータスのリセット
    /// </summary>
    private void StatusReset()
    {
        if (state != playerState.Fever)
        {
            if (deltaTime >= stateResetTime)
            {
                SetState(playerState.Run);
                reverse.SetActive(false);
                animator.SetBool("Reverse", false);
                slow.SetActive(false);
                freeze.SetActive(false);
            }
        }
        else
        {
            reverse.SetActive(false);
            slow.SetActive(false);
            freeze.SetActive(false);

            if (deltaTime >= feverCheckTime)
            {
                SetState(playerState.Run);
            }
        }
    }

    /// <summary>
    /// ジャンプ処理
    /// </summary>
    private void CanJump()
    {
        if (Input.GetKeyDown("space"))
        {
            if (canJump)
            {
                rb2d.AddForce(Vector2.up * jumpPower);
                canJump = false;
            }
        }
    }

    /// <summary>
    /// フィーバータイムかどうかのチェック
    /// </summary>
    /// <param name="count">アイテムのカウント</param>
    void FeverCheck(int count)
    {
        //フィーバータイムを満たしているかチェック
        if (!feverEvent)
        {
            if (count >= needFeverCount)
            {
                feverEvent = true;
                feverIrast.transform.position = new Vector2(transform.position.x, transform.position.y);
                feverIrast.SetActive(true);
                fever = true;
                feverTime = 0f;
                SetState(playerState.Fever);
            }
        }
        else
        {
            feverIrast.transform.position = new Vector3(transform.position.x, transform.position.y, 1);
            //フィーバータイム終了後の処理
            if (feverTime >= feverCheckTime)
            {
                feverEvent = false;
                feverCount = 0;
                fever = false;
                feverIrast.SetActive(false);
            }
        }
    }

    //アニメーションイベント（リバース時）
    public void Reverse()
    {
        animator.SetBool("Reverse", true);
    }

    /// <summary>
    ///ゲームオーバー後の処理 
    /// </summary>
    void GameEnd()
    {
        if (this.transform.position.x >= stageDist || LifeGage.playerLife <= 0)
        {
            canJump = false;//ジャンプ不可
            LifeGage.endflag = true;//体力ゲージの自動減少の停止
            toresultButton.SetActive(true);//シーン遷移のボタン表示
            toResult = GameObject.Find("Canvas/ToResult").GetComponent<Button>();
            toResult.Select();

            if (LifeGage.playerLife <= 0)
            {
                //ゲームオーバー時のUI変更
                loseIrast.transform.position = new Vector2(transform.position.x, transform.position.y);
                GameOver.SetActive(true);
                defIrast.SetActive(false);
                loseIrast.SetActive(true);
            }
            else
            {
                //ゲームクリア時のUI変更
                winIrast.transform.position = new Vector2(transform.position.x, transform.position.y);
                Clear.SetActive(true);
                defIrast.SetActive(false);
                winIrast.SetActive(true);
            }
        }
    }
}
