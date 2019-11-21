using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 敵の倒した数を記録
/// </summary>
public class Enemy_Count : MonoBehaviour
{
    //敵の数を数える
    public int Count_Enemy;

    //敵の総数
    public int MAX_Enemy;

    //リザルトを表示
    public GameObject Result_Canvas;

    //クリアテキスト
    public Text Clear_Text;

    //カウント
    public int Count = 1;

    //敵の生成を終了させる
    public GameObject Enemy_System;

    /// <summary>
    /// 初期データ
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// 常に更新
    /// </summary>
    void Update()
    {
        //加算した敵の数とMAXの敵の数が同じなら
        if (Count_Enemy==MAX_Enemy)
        {
            //リザルトを表示
            Result_Canvas.SetActive(true);
            //文字の変更（GameClearを表示）
            Clear_Text.text = "GameClear";
            //黄色に変更
            Clear_Text.color = new Color(1,1,0,1);
            //非表示する
            Enemy_System.SetActive(false);
        }
    }

    /// <summary>
    /// 消滅した敵の加算
    /// </summary>
    public void Enemy_Lost()
    {
        //敵の数を加算
        Count_Enemy+=Count;
    }
}
