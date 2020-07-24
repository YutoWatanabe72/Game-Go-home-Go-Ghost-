using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultSceneUI : MonoBehaviour
{
    public GameObject Ranking;//総合ランキングの表示
    public Text ScoreText;//スコアの表示

    void Start()
    {
        ScoreText.text = "Score:" + LifeGage.totalScore.ToString();
    }

    public void OnClickButton2()
    {
        Ranking.SetActive(true);//ランキングの表示
    }
}
