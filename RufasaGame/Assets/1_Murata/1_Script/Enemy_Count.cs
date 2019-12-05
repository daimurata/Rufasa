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
    public int Count = 0;

    //敵の生成を終了させる
    public GameObject Enemy_System;

    //Playerを持ってきます
    public GameObject Power_Player;

    //弾の加算（強力な）
    public int MAX_Bullt;

    //色の変更
    public GameObject Color_Ply;

    //点滅処理に追加
    private bool Change_Color=false;

    /// <summary>
    /// 初期データ
    /// </summary>
    void Start()
    {
        //Playerを探す
        Power_Player = GameObject.Find("Player");

        //Playerを探す
        Color_Ply = GameObject.Find("Player");
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
        //小さい場合
       Color_Pl();
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
        if (MAX_Bullt>=5 )
        {
            //赤色にして点滅点滅させる
            if (Change_Color==true)
            {
                //点滅処理
                Player_Color Alfe = Color_Ply.GetComponent<Player_Color>();
                //実行
                Alfe.Alfe_true();
            }
            //黄色に戻す
            else
            {
                //黄色に設定
                Player_Color Col_Ply = Color_Ply.GetComponent<Player_Color>();
                //実行
                Col_Ply.Yellow_Color();
            }
            //弾を撃つことを
            Player_Control GO = Power_Player.GetComponent<Player_Control>();
            //実行
            GO.MAX_Power();
        }
    }
    /// <summary>
    /// 色の変更
    /// </summary>
    public void Color_Pl()
    {
        //5より小さいなら
        if (MAX_Bullt < 5)
        {
            //赤色にして点滅させる
            if (Change_Color==true)
            {
                //点滅処理
                Player_Color Alfe = Color_Ply.GetComponent<Player_Color>();
                //実行
                Alfe.Alfe_true();
            }
            //通常色に戻す
            else
            {
                //通常色に設定
                Player_Color Color_Normal = Color_Ply.GetComponent<Player_Color>();
                //実行
                Color_Normal.Normal_Color();
            }
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

    /// <summary>
    /// 点滅可能とさせる
    /// </summary>
    public void Change_Red()
    {
        //点滅許可
        Change_Color = true;
    }

    /// <summary>
    /// 点滅から戻す
    /// </summary>
    public void Change_Normal()
    {
        //点滅終了
        Change_Color = false;
    }
}
