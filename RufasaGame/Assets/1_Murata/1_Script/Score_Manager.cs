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

    //初期
    void Start()
    {
        
    }

    //更新
    void Update()
    {
        Score_Text.text = "Score:" + Score;

        if (Input.GetKeyDown(KeyCode.O))
        {
            Score += Up_Score;
        }
        
    }
}
