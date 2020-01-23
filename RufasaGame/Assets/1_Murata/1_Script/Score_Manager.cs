using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    /// <summary>
    /// スコアのスクリプト
    /// </summary>
public class Score_Manager : MonoBehaviour
{
    public Text Score_Text;     //Textオブジェクト
    public int Score = 0;       //スコア数字
    public int Up_Score = 100;  //加算する数値
    public int Up_Mini_Score = 500; //中ボスの加算する数値
    public int Up_Big_Score = 1000; //大ボスの加算する数値
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
        //スコアの文字に更新
        Score_Text.text = "Score:" + Score;
    }
    /// <summary>
        /// スコア加算
        /// </summary>
    public void Score_UP()
    {
        //スコアの文字に更新
       // Score_Text.text = "Score:" + Score;
        //スコアを加算
        Score += Up_Score;
    }
    /// <summary>
    /// スコア加算　（中ボス）
    /// </summary>
    public void Score_Mini_UP()
    {
        //スコアの文字に更新
        //Score_Text.text = "Score:" + Score;
        //スコアを加算
        Score += Up_Mini_Score;
    }
    /// <summary>
    /// スコア加算（大ボス）
    /// </summary>
    public void Score_Big_UP()
    {
        //スコアの文字に更新
        // Score_Text.text = "Score:" + Score;
        //スコアを加算
        Score += Up_Big_Score;
    }


}
