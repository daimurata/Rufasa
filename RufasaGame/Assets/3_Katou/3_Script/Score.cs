using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText; //Text用変数
    private int score = 0; //スコア計算用変数

    void Start()
    {
        score = 0;
        SetScore();   //初期スコアを代入して表示
    }

    void Update()
    {
       
    }

    //OnCollisionEnterから変更、当たったオブジェクトのタグを渡される
    public void HitShot(string hittag)
    {
        if (hittag == "Enemy")
        {
            score += 100;
        }
        else if (hittag == "Enemy 1")
        {
            score += 150;
        }
        else if (hittag == "Enemy 2")
        {
            score += 200;
        }
        else if (hittag == "Enemy 3")
        {
            score += 300;
        }

        SetScore();
    }

    void SetScore()
    {
        scoreText.text = string.Format("Score:{0}", score);
    }
}
