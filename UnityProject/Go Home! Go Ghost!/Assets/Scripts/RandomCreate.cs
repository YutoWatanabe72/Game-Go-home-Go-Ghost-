using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCreate : MonoBehaviour
{
    //ライフゲージ回復・得点加算アイテム
    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    //ダメージアイテム
    public GameObject TrapItem1;
    public GameObject TrapItem2;
    public GameObject TrapItem3;
    //床の生成
    public GameObject floar;
    //プレイヤー
    public GameObject player;
    //ステージの長さ
    const float stageLength = 1000.0f;
    //床の生成間隔
    const float floarLength = 40.0f;
    //トラップアイテムの生成間隔
    const float TrapItemLength = 40.0f;

    private int[] stageNum = new int[100];

    void Start()
    {
        CreateStageNum();
        CreateStage();
        CreateItem();
        CreateTrap();
    }


    private void CreateStageNum()
    {
        stageNum[0] = 1;
        for (int i = 1; i < 100; i++)
        {
            int rnd = Random.Range(0, 3);
            switch (rnd)
            {
                case 0:
                    stageNum[i] = stageNum[i - 1];
                    break;
                case 1:
                    if (stageNum[i - 1] == 3)
                    {
                        stageNum[i] = stageNum[i - 1];
                    }
                    else
                    {
                        stageNum[i] = stageNum[i - 1] + 1;
                    }
                    break;
                case 2:
                    if (stageNum[i - 1] == 0)
                    {
                        stageNum[i] = stageNum[i - 1];
                    }
                    else
                    {
                        stageNum[i] = stageNum[i - 1] - 1;
                    }
                    break;
            }
        }
    }

    //床の生成
    private void CreateStage()
    {
        for (int i = 0; i < (stageLength / floarLength) - 1; i++)
        {
            if (stageNum[i] != 0)
            {
                Instantiate(floar, new Vector3(floarLength * (i + 1), -18.0f + (stageNum[i] * 14.0f), 0.0f), transform.rotation);
            }
        }
    }

    //アイテムの生成
    private void CreateItem()
    {
        GameObject hitodama;
        GameObject hitodama2;
        //床と同じY軸のところに生成
        for (int i = 0; i < (stageLength / floarLength) - 1; i++)
        {
            //hitodamaのオブジェクト設定
            int Itemrnd = Random.Range(0, 6);
            switch (Itemrnd)
            {
                case 0:
                case 1:
                case 2:
                    hitodama = Item1;
                    break;
                case 3:
                case 4:
                    hitodama = Item2;
                    break;
                default:
                    hitodama = Item3;
                    break;
            }
            //hitodama2のオブジェクト設定
            int Itemrnd2 = Random.Range(0, 6);
            switch (Itemrnd)
            {
                case 0:
                case 1:
                case 2:
                    hitodama2 = Item1;
                    break;
                case 3:
                case 4:
                    hitodama2 = Item2;
                    break;
                default:
                    hitodama2 = Item3;
                    break;
            }
            //床の位置の上に生成
            Instantiate(hitodama, new Vector3(floarLength * (i + 1), -12.0f + (stageNum[i] * 14.0f), 0.0f), transform.rotation);
            //床の位置と反対側に生成
            if (i % 2 == 1 && stageNum[i] != 0)
            {
                Instantiate(hitodama2, new Vector3(floarLength * (i + 1), 30.0f - (stageNum[i] * 14.0f), 0.0f), transform.rotation);
            }
        }

        //床と床の間に生成
        for (int i = 0; i < (stageLength / floarLength) - 1; i++)
        {

            int Itemrnd = Random.Range(0, 6);
            switch (Itemrnd)
            {
                case 0:
                case 1:
                case 2:
                    hitodama = Item1;
                    break;
                case 3:
                case 4:
                    hitodama = Item2;
                    break;
                default:
                    hitodama = Item3;
                    break;
            }
            //最初の人魂
            if (i == 0)
            {
                Instantiate(hitodama, new Vector3(floarLength * i + 20.0f, -1.5f, 0.0f), transform.rotation);
            }

            switch (stageNum[i] - stageNum[i + 1])
            {
                case -1://次の床が一段上
                    Instantiate(hitodama, new Vector3(floarLength * (i + 1) + 20.0f, -5.0f + (stageNum[i] * 14.0f), 0.0f), transform.rotation);
                    break;
                case 0://次の床が同じ高さ
                    Instantiate(hitodama, new Vector3(floarLength * (i + 1) + 20.0f, 2.0f + (stageNum[i] * 14.0f), 0.0f), transform.rotation);
                    break;
                case 1://次の床が一段下
                    Instantiate(hitodama, new Vector3(floarLength * (i + 1) + 20.0f, -19.0f + (stageNum[i] * 14.0f), 0.0f), transform.rotation);
                    break;
                default:
                    break;
            }

        }
    }

    //トラップアイテムの生成
    private void CreateTrap()
    {
        GameObject TrapItem;

        for (int i = 1; i < (stageLength / TrapItemLength); i++)
        {
            int Itemrnd = Random.Range(0, 3);
            switch (Itemrnd)
            {
                case 0:
                    TrapItem = TrapItem1;
                    break;
                case 1:
                    TrapItem = TrapItem2;
                    break;
                default:
                    TrapItem = TrapItem3;
                    break;
            }
            //ステージ半分までのトラップアイテムの出現
            if ((i < (stageLength / TrapItemLength) / 2) && (i % 2 == 1))
            {
                TrapSet(TrapItem, i);
            }
            //残り距離が半分を切ったらトラップアイテムの出現間隔を短く
            else if (i > (stageLength / TrapItemLength) / 2)
            {
                TrapSet(TrapItem, i);
            }
        }
    }
    //トラップアイテムを出現させる関数
    private void TrapSet(GameObject TrapItem, int num)
    {
        Instantiate(TrapItem, new Vector3((TrapItemLength * (num + 1)) - 5.0f, -12.0f + (stageNum[num] * 14.0f), 0.0f), transform.rotation);
    }
}