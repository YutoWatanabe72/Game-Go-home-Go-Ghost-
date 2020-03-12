using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChengeSceneManager : MonoBehaviour
{
    public void PushGameMainButton()
    {
        //タイトル画面からメインシーンへの移動
        LifeGage.playerLife = 30000;//プレイヤーライフのリセット
        SceneManager.LoadScene("MainScene");
    }
    public void PushGameResultButton()
    {
        //メインシーンからリザルトシーンへの移動
        SceneManager.LoadScene("ResultScene");
    }

    public void PushGameTitleButton()
    {
        //リザルトシーンからタイトルシーンへの移動
        SceneManager.LoadScene("TitleScene");
    }

    public void PushGameEndButton()
    {
        //ゲームを終了する処理
        Quit();
    }
    void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
             UnityEngine.Application.Quit();
        #endif
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) Quit();
    }
}