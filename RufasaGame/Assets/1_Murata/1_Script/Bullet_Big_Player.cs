﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 大きい弾のスクリプト
/// </summary>
public class Bullet_Big_Player : MonoBehaviour
{
    //弾の速さ
    public float Mov_X;

    //弾を消す場所
    public float Range = 9.46f;

    //スコア表示
   //public GameObject Score_Test;

    //倒した数を加算
    //public GameObject Enemy;

    //大きい弾のHP
    public int Big_Bullet_HP=5;
    /// <summary>
    /// 初期データ
    /// </summary>
    void Start()
    {
        //Scoreを探す
        //Score_Test = GameObject.Find("Score");
        //Enemy_System探す
       // Enemy = GameObject.Find("Enemy_System");
    }

    /// <summary>
    /// 常に更新
    /// </summary>
    void Update()
    {
        //X側方向に進む→
        transform.Translate(Mov_X, 0f, 0f);

        //【弾のポジション】のコードを短くする
        float Des_Bullet = transform.position.x;

        //X方向に一定まで進んだら
        if (Des_Bullet >= Range||Big_Bullet_HP<=0)
        {
            //弾自信を消す
            Destroy(gameObject);
        }
    }
    /// <summary>
    ///  弾に衝突した判定 触れている間
    /// </summary>
    private void OnTriggerStay2D(Collider2D collider)
    {
        
        //小さな敵に弾が当たったら
        if (collider.name.Contains("Small_Enemy")||
                //中ボスに触れたとき
                collider.name.Contains("Enemy_Mini") ||
                //大ボスに触れたとき
                collider.name.Contains("Boss_Enemy"))
        {
            //スコア加算
            //Score_Manager Say = Score_Test.GetComponent<Score_Manager>();
            //Score_ManagerのScore_UPを実行
            //Say.Score_UP();
            //触れた敵の弾を削除する
            //Destroy(collision.gameObject);

            //敵の加算
            //Enemy_Count Sum = Enemy.GetComponent<Enemy_Count>();
            //実行
            //Sum.Enemy_Lost();

            //弾を削除する
            // Destroy(gameObject);

            //弾のHPを減算
            Big_Bullet_HP-=1;
        }
        //敵の弾がプレイヤーの弾に当たったら
        if (collider.name.Contains("Enemy_Bullet Variant"))
        {
            //触れた敵の弾を削除する
            Destroy(collider.gameObject);

            //弾を削除する
            //Destroy(gameObject);

            //弾のHPを減算
            Big_Bullet_HP-=1;
        }

        //HPが0以下になったら
        /*if (Big_Bullet_HP>=0)
        {
            //弾を削除する
            Destroy(gameObject);
        }*/

    }
}
