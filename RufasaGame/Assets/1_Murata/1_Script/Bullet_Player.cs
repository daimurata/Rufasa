using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
