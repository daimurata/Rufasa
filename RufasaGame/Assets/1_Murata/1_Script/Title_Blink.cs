using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// TitleSceneの点滅処理
/// </summary>
public class Title_Blink : MonoBehaviour
{
    public Text Staert_Text;//点滅する画像

    public bool Chamge = false;//点滅切替

    public float Alpha,Alpha_Speed;//α値とαスピードとクリック


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
        //α値の更新
        Staert_Text.GetComponent<Text>().color = new Color(0, 0, 0, Alpha);

        //α値の点滅処理
        Blink();

        //ゲームシーンに行く
        Click_GO();
    }

    /// <summary>
    /// α値の点滅処理
    /// </summary>
    void Blink()
    {
        //切替（加算）
        if (Chamge==true)
        {
            //α値に加算
            Alpha += Alpha_Speed * Time.deltaTime;

            //α値が1.0f以上になったら
            if (Alpha >= 1.0f)
            {
                //α値を1.0fにする
                Alpha = 1.0f;
                //切替（減算）
                Chamge = false;
            }
        }
        //切替（減算）
        else if (Chamge == false)
        {
            //α値に減算
            Alpha -= Alpha_Speed * Time.deltaTime;

            //α値が0.0f以下になったら
            if (Alpha <= 0.0f)
            {
                //α値を0.0にする
                Alpha = 0.0f;
                //切替（加算）
                Chamge = true;
            }
        }
    }



    /// <summary>
    /// ゲームシーンに行く
    /// </summary>
    void Click_GO()
    {
        //クリックしたら
        if (Input.GetMouseButtonUp(0))
        {
            //ゲームシーンへ移動
            SceneManager.LoadScene("Game_1");
        }
    }
}