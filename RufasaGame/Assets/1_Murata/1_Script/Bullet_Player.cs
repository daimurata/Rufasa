using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 弾のコントロール
/// </summary>
public class Bullet_Player : MonoBehaviour
{
    //弾の威力
    public int Damage;  

    //弾の速さ
    public float Mov_X;

    //弾を消す場所
    public float Range=9.46f;

    //スコア表示
    public Text Score_Test;

    //加算する数値
    public int Score_Num=100;

    /// <summary>
    /// 初期データ
    /// </summary>
    void Start()
    {

    }

    /// <summary>
    /// 更新データ
    /// </summary>
    void Update()
    {
        //X側方向に進む→
        transform.Translate(Mov_X, 0f, 0f);

        //【弾のポジション】のコードを短くする
        float Des_Bullet = transform.position.x;

        //X方向に一定まで進んだら
        if (Des_Bullet>=Range)
        {
            //弾自信を消す
            Destroy(gameObject);
        }
    }

    //弾に衝突した判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //敵の弾が当たったら
        if (collision.name.Contains("Enemy_Bullet Variant")||
            //もしくは、小さな敵なら
            collision.name.Contains("Small_Enemy"))
        {
            //スコア加算
            Score_Test.text = "Score:" + Score_Num;
            //弾を削除する
            Destroy(collision.gameObject);
            //触れた敵の弾を削除する
            Destroy(gameObject);
        }
    }
}
