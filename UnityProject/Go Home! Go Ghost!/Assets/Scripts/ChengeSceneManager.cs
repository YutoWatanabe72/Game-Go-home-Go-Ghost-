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
    private bool tutorialCheck;
    private bool endCheck;
    private bool fadeCheck;
    const float resetTime = 0.0f;

    FadeController fadeController;

    const float changeTime = 2.0f;
    const float fadeTime = 1.0f;

    void Start()
    {
        timer = resetTime;
        startCheck = false;
        tutorialCheck = false;
        resultCheck = false;
        titleCheck = false;
        endCheck = false;
        fadeCheck = false;
        fadeController = GameObject.Find("Panel").GetComponent<FadeController>();
    }

    public void PushGameMainButton()
    {
        startCheck = true;
        fadeCheck = true;
        timer = resetTime;
    }
    public void PushTutorialButton()
    {
        tutorialCheck = true;
        fadeCheck = true;
        timer = resetTime;
    }
    public void PushGameResultButton()
    {
        resultCheck = true;
        fadeCheck = true;
        timer = resetTime;
    }

    public void PushGameTitleButton()
    {
        titleCheck = true;
        fadeCheck = true;
        timer = resetTime;
    }

    public void PushGameEndButton()
    {
        endCheck = true;
        fadeCheck = true;
        timer = resetTime;
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

        if (timer >= fadeTime)
        {
            FadeOut();
        }

        if (timer >= changeTime)
        {
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        if (tutorialCheck)
        {
            //タイトルシーンからチュートリアルシーンへの移動
            LifeGage.playerLife = 30000;//プレイヤーライフのリセット
            SceneManager.LoadScene("TutorialScene");
        }
        if (startCheck)
        {
            //チュートリアルシーンからメインシーンへの移動
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

    private void FadeOut()
    {
        if (fadeCheck)
        {
            fadeController.isFadeOut = true;
        }
    }
}