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

    public bool Chamge = false,Click_Chamge=false;//点滅切替

    public float Alpha,Alpha_Speed,click;//α値とαスピードとクリック


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
        //α値の変動
        Staert_Text.GetComponent<Text>().color = new Color(0, 0, 0, Alpha);
        //点滅0より小さい時
        Blink_false();
        //点滅1より大きいとき
        Blink_true();

        Click_GO();
    }
    /// <summary>
    /// 0より小さい時
    /// </summary>
   　void Blink_false()
    {
        //Chamgeがfarceなら
        if (Chamge==false)
        {
            //α値を下げる
            Alpha -= Alpha_Speed * Time.deltaTime;
            //α値が0以下なら
            if (Alpha<=0.0f)
            {
                //α値を0にする
                Alpha = 0.0f;
                //Chamgeをtrueにする
                Chamge = true;
            }
        }
    }
    /// <summary>
    /// 1より大きい時
    /// </summary>
    void Blink_true()
    {
        //Chamgeがtrueなら
        if (Chamge == true)
        {
            //α値を上げる
            Alpha += Alpha_Speed * Time.deltaTime;
            //α値が1以上なら
            if (Alpha >= 1.0f)
            {
                //α値を1にする
                Alpha = 1.0f;
                //Chamgeをtrueにする
                Chamge = false;
            }
        }
    }
    /// <summary>
    /// クリックしてシーン移動
    /// </summary>
    public void Scene_GO()
    {
        //クリックしたよ
        Click_Chamge = true;
    }
    /// <summary>
    /// クリックされたら
    /// </summary>
    void Click_GO()
    {
        //Click_Chamgeがtrueなら
        if (Click_Chamge == true)
        {
            //clickに加算
            click += Time.deltaTime;
        }
        //clickが1以上なら
        if (click >= 1)
        {
            //clickは1
            click = 1;
            //ゲームシーンへ移動
            SceneManager.LoadScene("Game_1");
        }
    }
}