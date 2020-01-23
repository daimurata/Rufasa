using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タイトル画面のRufasaに追加
/// </summary>
public class Tittle_Player : MonoBehaviour
{
    //Rufasa
    public GameObject Player;

    //移動
    private float Mov;

    //スピード
    private float Speed=1;

    //移動範囲が最大
    private float Max_Range=0.5f;

    //移動範囲が最小
    private float Min_Range=-2.5f;

    //切替
    private bool Change=true;
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
        //上下移動
        Loop_Player();
    }
    /// <summary>
    /// 上下移動
    /// </summary>
    private void Loop_Player()
    {
        //コードを短くした
        Vector2 Position = Player.transform.position;

        //上に動く
        if (Change==true)
        {
            //時間で動く
            Position.y += Speed*Time.deltaTime;
            //移動範囲以上に行ったら【最大】
            if (Position.y>=Max_Range)
            {
                //切り替える
                Change = false;
            }
        }
        //下に動く
        else if (Change==false)
        {
            //時間で動く
            Position.y -= Speed * Time.deltaTime;
            //移動範囲以上に行ったら【最小】
            if (Position.y<=Min_Range)
            {
                //切り替える
                Change = true;
            }
        }
        //データの更新
        Player.transform.position = new Vector2(Position.x,Position.y);
    }
}
