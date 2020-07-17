using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeGage : MonoBehaviour
{
    public static int playerLife = 30000;//キャラクターのHP
    public static int totalCount;//スコアアイテムの合計個数
    public static bool endflag;//ゲームオーバーフラグ
    private int Score;//合計スコア
    public static int totalScore;//トータルスコア
    private int defaultlife;//キャラクターの最大HP
    const int autoDamage = 10;//1フレームごとのダメージ量
    const int scoreMag = 10;//スコアの加算倍率

    Slider slider;
    public Text ScoreText;//スコアの表示

    // Start is called before the first frame update
    void Start()
    {
        //初期化
        totalCount = 0;
        Score = 0;
        defaultlife = playerLife;
        totalScore = 0;

        slider = GameObject.Find("LifeGage").GetComponent<Slider>();
        slider.maxValue = playerLife;
        slider.value = slider.maxValue;

        endflag = false;
    }

    // Update is called once per frame
    void Update()
    {
        //HPがdefaultlife以上にならないようにする処理
        if(playerLife >= defaultlife)
        {
            playerLife = defaultlife;
        }

        //ライフゲージの自動減少
        if (!endflag)
        {
            playerLife -= autoDamage;
        }

        //現在のライフの表示
        slider.value = playerLife;

        Score = totalCount * scoreMag;//スコアの計算

        totalScore = Score + playerLife;//トータルスコアの計算

        //現在のスコアの表示（アイテム取得による得点のみの）
        ScoreText.text = "Score:" + Score.ToString();
    }
}
