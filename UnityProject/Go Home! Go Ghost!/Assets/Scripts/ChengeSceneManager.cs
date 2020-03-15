using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChengeSceneManager : MonoBehaviour
{
    private float timer;
    private bool startCheck;
    private bool resultCheck;
    private bool titleCheck;
    private bool endCheck;

    const float changeTime = 1.5f;

    void Start()
    {
        timer = 0.0f;
        startCheck = false;
        resultCheck = false;
        titleCheck = false;
        endCheck = false;
    }

    public void PushGameMainButton()
    {
        startCheck = true;
        timer = 0.0f;
    }
    public void PushGameResultButton()
    {
        resultCheck = true;
        timer = 0.0f;
    }

    public void PushGameTitleButton()
    {
        titleCheck = true;
        timer = 0.0f;
    }

    public void PushGameEndButton()
    {
        endCheck = true;
        timer = 0.0f;
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

        timer += Time.deltaTime;
        if(timer >= changeTime)
        {
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        if (startCheck)
        {
            //タイトル画面からメインシーンへの移動
            LifeGage.playerLife = 30000;//プレイヤーライフのリセット
            SceneManager.LoadScene("MainScene");
        }
        if (resultCheck)
        {
            //メインシーンからリザルトシーンへの移動
            SceneManager.LoadScene("ResultScene");
        }
        if (titleCheck)
        {
            //リザルトシーンからタイトルシーンへの移動
            SceneManager.LoadScene("TitleScene");
        }
        if (endCheck)
        {
            //ゲームを終了する処理
            Quit();
        }
    }
}