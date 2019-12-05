using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの色の変更スクリプト
/// </summary>
public class Player_Color : MonoBehaviour
{
    //Enemy_Countを入れる
    public GameObject Enemy_Con;

    //色の設定
    private float Red = 1.0f, Green = 1.0f, Blue = 1.0f, Alpha = 1.0f;

    //切替点滅
    private bool Flashing_Alpha = true;

    //時間点滅 Player_Colorに移動
    public float Player_Blink = 3;

    //点滅分岐 Player_Colorに移動
    private bool Flashing = false;

    //点滅の速さ
    public int Speed_Color;

    /// <summary>
    /// 初期データ
    /// </summary>
    void Start()
    {
        //Enemy_System探す
        Enemy_Con = GameObject.Find("Enemy_System");
    }

    /// <summary>
    /// 常に更新
    /// </summary>
    void Update()
    {
        /*
        //強力な弾を撃つ
        Enemy_Count MAX_Count = Enemy_Con.GetComponent<Enemy_Count>();
        //実行
        MAX_Count.Power();
        //色変え
        MAX_Count.Color_Pl();
        */
    }
    /// <summary>
    /// 通常色にする
    /// </summary>
    public void Normal_Color()
    {
        //赤
        Red = 1.0f;

        //緑
        Green = 1.0f;

        //青の色
        Blue = 1.0f;

        //透明度
        Alpha = 1.0f;

        //反映
        GetComponent<SpriteRenderer>().color = new Color(Red, Green, Blue, Alpha);
    }

    /// <summary>
    ///　黄色にする
    /// </summary>
    public void Yellow_Color()
    {
        //赤
        Red = 1.0f;

        //緑
        Green = 1.0f;

        //青の色
        Blue = 0.0f;

        //透明度
        Alpha = 1.0f;

        //反映
        GetComponent<SpriteRenderer>().color = new Color(Red, Green, Blue, Alpha);
    }

    /// <summary>
    /// 赤色くする
    /// </summary>
    public void Red_Color()
    {
        //赤
        Red = 1.0f;

        //緑
        Green = 0.0f;

        //青の色
        Blue = 0.0f;

        //透明度
       // Alpha = 1.0f;

        //反映
        GetComponent<SpriteRenderer>().color = new Color(Red, Green, Blue, Alpha);
    }
    /// <summary>
    /// α値の変更
    /// </summary>
    public void Alfa_Blink()
    {
        //点滅するタイミング
        if (Flashing==true)
        {
            //不当明度の点滅切替　減算
            if (Flashing_Alpha == true)
            {
                //不当明度を下げる
                Alpha -= Speed_Color * Time.deltaTime;

                //赤色にする
                Red_Color();

                //不当明度が0以下になったら
                if (Alpha <= 0.0f)
                {
                    //不当明度を0にする
                    Alpha = 0.0f;

                    //切替　加算
                    Flashing_Alpha = false;
                }
            }
            //切替　加算
            else if (Flashing_Alpha == false)
            {
                //不当明度を上げる
                Alpha += Speed_Color * Time.deltaTime;

                //赤色にする
                Red_Color();

                //不当明度が1以上になったら
                if (Alpha >= 1.0f)
                {
                    //1に固定
                    Alpha = 1.0f;
                    //切替　減算
                    Flashing_Alpha = true;
                }
            }
            //減算点滅時間
            Player_Blink -=Time.deltaTime;
            //0以下になったら
            if (Player_Blink<=0)
            {
                //点滅終了
                Flashing = false;

                //初期化　点滅時間
                Player_Blink = 3.0f;

                //通常の色に変更
                //Normal_Color();
                Enemy_Count Change = Enemy_Con.GetComponent<Enemy_Count>();
                Change.Change_Normal();
            }
        }
    }
    /// <summary>
    /// 点滅開始合図
    /// </summary>
    public void Alfe_true()
    {
        //点滅開始
        Flashing = true;
    }

}
