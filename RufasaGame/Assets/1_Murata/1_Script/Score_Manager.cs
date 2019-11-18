using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace say
{

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
            //デバック
            //Score_Text.text = "Score:" + Score;

            //if (Input.GetKeyDown(KeyCode.O))
            //{
            // Score += Up_Score;
            //}
        }
        /// <summary>
        /// スコア加算
        /// </summary>
        public void Score_UP()
        {
            //スコアの文字に更新
            Score_Text.text = "Score:" + Score;
            //スコアを加算
            Score += Up_Score;
        }
    }
}
