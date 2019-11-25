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

    //Playerを持ってきます
    public GameObject Power_Player;

    //弾の加算（強力な）
    public int MAX_Bullt;

    /// <summary>
    /// 初期データ
    /// </summary>
    void Start()
    {
        //Player
        Power_Player = GameObject.Find("Player");
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
        //強力な弾撃てる
        Power();
    }

    /// <summary>
    /// 消滅した敵の加算
    /// </summary>
    public void Enemy_Lost()
    {
        //敵の数を加算
        Count_Enemy+=Count;

        //強力な弾加算
        MAX_Bullt += Count;
    }

    /// <summary>
    /// 強力な弾撃ちます
    /// </summary>
    public void Power()
    {
        //強力な弾が5以上なら
        if (MAX_Bullt>=5)
        {
            //黄色に変換
            Power_Player.GetComponent<SpriteRenderer>().color = new Color(1,1,0,1);

            //弾を撃つ
            Player_Control GO = Power_Player.GetComponent<Player_Control>();

            //実行
            GO.MAX_Power();
        }
        //5より小さいなら
        if (MAX_Bullt<5)
        {
            //元の色に戻す
            //Power_Player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
    }
    /// <summary>
    /// 強力な弾撃ち終わり
    /// </summary>

    public void Power_Down()
    {
        //強力な弾ゲージDown
        MAX_Bullt -= 5;
    }
}
