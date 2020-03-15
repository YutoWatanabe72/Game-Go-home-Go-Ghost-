using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultSceneUI : MonoBehaviour
{
    public GameObject Button;//スコア表示
    public GameObject Button2;//ランキング表示
    public GameObject Ranking;//総合ランキングの表示
    public Text ScoreText;//スコアの表示

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "Score:" + LifeGage.totalScore.ToString();
    }

    public void OnClickButton()
    {
        Button2.SetActive(true);//ランキング表示ボタンをアクティブに
    }

    public void OnClickButton2()
    {
        Ranking.SetActive(true);//ランキングの表示
        Button2.SetActive(false);//ランキング表示ボタンをオフに
    }
}
