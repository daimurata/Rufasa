using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の弾コントロール
/// </summary>
public class Bullet_Enemy : MonoBehaviour
{
    //弾の威力
    public int Damege;

    //弾の速さ
    public float Mov_x;

    //弾を消す場所
    public float Range = -9.46f;
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
        //X側方向に進む←
        transform.Translate(Mov_x,0f,0f);

        //【弾のポジション】
        float Des_Bullet = transform.position.x;

        //X方向に一定まで進んだら
        if (Range>=Des_Bullet)
        {
            //弾自信を消す
            Destroy(gameObject);
        }
    }
}
