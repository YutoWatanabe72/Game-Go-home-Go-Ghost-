using System.Collections;
using System.Collections.Generic;
using MiniJSON; // Json

/// <summary>
/// Json response manager.
/// </summary>
public class ScoreDataModel
{
    /// <summary>
    /// Deserialize from json.
    /// MemberData型のリストがjsonに入っていると仮定して
    /// </summary>
    /// <returns>The from json.</returns>
    /// <param name="sStrJson">S string json.</param>
    public static List<ScoreData> DeserializeFromJson(string sStrJson)
    {
        var ret = new List<ScoreData>();

        IList jsonList = (IList)Json.Deserialize(sStrJson);

        foreach (IDictionary jsonOne in jsonList)
        {
            //新レコード解析開始
            var tmp = new ScoreData();

            //該当するキー名が jsonOne に存在するか調べ、存在したら取得して変数に格納する。
            if (jsonOne.Contains("Score"))
            {
                tmp.Score = (long)jsonOne["Score"];
            }

            if (jsonOne.Contains("Day"))
            {
                tmp.Day = (string)jsonOne["Day"];
            }

            //現レコード解析終了
            ret.Add(tmp);
        }

        return ret;
    }
}