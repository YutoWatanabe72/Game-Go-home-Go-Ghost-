using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using System; 
using UnityEngine.Networking;

public class MainManager : MonoBehaviour
{
    [SerializeField] private Text _displayField = default;
    public GameObject panel;
    public GameObject Connectted;
    public GameObject noConnected;

    private List<ScoreData> _memberList;

    /// <summary>
    /// ボタンを押してウェブリクエストを行ってjsonをゲット
    /// </summary>
    public void OnClickGetJsonFromWebRequest()
    {
        panel.SetActive(true);//wait画像の表示
        _displayField.text = null;
        GetJsonFromWebRequest();
    }

    /// <summary>
    /// ランキングの表示
    /// </summary>
    public void OnClickShowMemberList()
    {
        string sStrOutput = "";
        int count = 0;

        if (null == _memberList)
        {
            sStrOutput = "no list !";
        }
        else
        {
            //リストの内容を表示
            foreach (ScoreData memberOne in _memberList)
            {
                count++;
                sStrOutput += $"{count}位  score:{memberOne.Score} day:{DateTime.Parse(memberOne.Day).ToShortDateString()} \n";
            }
        }

        _displayField.text = sStrOutput;
    }

    /// <summary>
    /// ウェブリクエストを行ってjsonをゲット
    /// </summary>
    private void GetJsonFromWebRequest()
    {
        StartCoroutine(
            DownloadJson(
                CallbackWebRequestSuccess, 
                CallbackWebRequestFailed 
            )
        );
    }

    /// <summary>
    /// ウェブリクエストが成功したとき
    /// </summary>
    /// <param name="response">Response.</param>
    private void CallbackWebRequestSuccess(string response)
    {
        _memberList = ScoreDataModel.DeserializeFromJson(response);

        panel.SetActive(false) ;//wait画像の非表示
        Connectted.SetActive(true);
    }

    /// <summary>
    /// ウェブリクエストが失敗したとき
    /// </summary>
    private void CallbackWebRequestFailed()
    {
        // jsonデータ取得に失敗した
        _displayField.text = "WebRequest Failed";
        panel.SetActive(false);//wait画像の非表示
        noConnected.SetActive(true);
    }

    /// <summary>
    /// jsonのダウンロード
    /// </summary>
    /// <returns>The json</returns>
    /// <param name="cbkSuccess">Cbk success</param>
    /// <param name="cbkFailed">Cbk failed./param>
    private IEnumerator DownloadJson(Action<string> cbkSuccess = null, Action cbkFailed = null)
    {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost/GameRanking/gamescore/getScore");
        yield return www.SendWebRequest();
        if (www.error != null)
        {
            //レスポンスエラーの場合
            //Debug.LogError(www.error);
            if (null != cbkFailed)
            {
                cbkFailed();
            }
        }
        else if (www.isDone)
        {
            // リクエスト成功の場合
            //Debug.Log($"Success:{www.downloadHandler.text}");
            if (null != cbkSuccess)
            {
                cbkSuccess(www.downloadHandler.text);
            }
        }
    }

    /// <summary>
    /// クリックしたらスコアの送信
    /// </summary>
    public void OnClickSetMessage()
    {
        SetJsonFromWWW();
    }

    /// <summary>
    /// スコアの送信
    /// </summary>
    private void SetJsonFromWWW()
    {
        string sTgtURL = "http://localhost/GameRanking/gamescore/setScore";

        int score = LifeGage.totalScore;
       
        StartCoroutine(SetMessage(sTgtURL, score, WebRequestSuccess, CallbackWebRequestFailed));
    }


    private IEnumerator SetMessage(string url, int score, Action<string> cbkSuccess = null, Action cbkFaild = null)
    {
        WWWForm form = new WWWForm();
        form.AddField("Score", score);

        UnityWebRequest webRequest = UnityWebRequest.Post(url, form);

        //表示するスコアデータの数
        webRequest.timeout = 5;

        yield return webRequest.SendWebRequest();

        if (webRequest.error != null)
        {
            if (null != cbkFaild)
            {
                cbkFaild();
            }
        }
        else if (webRequest.isDone)
        {
            Debug.Log($"Success:{webRequest.downloadHandler.text}");
            if (null != cbkSuccess)
            {
                cbkSuccess(webRequest.downloadHandler.text);
            }
        }
    }
    private void WebRequestSuccess(string response)
    {
        //_displayField.text = response;
    }
}
