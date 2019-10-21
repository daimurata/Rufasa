using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 弾のコントロール
/// </summary>
public class Bullet_Control : MonoBehaviour
{
    public int Damage;  //弾の威力

    public float Mov_X;   //弾の速さ

    private float Range=9.46f;   //弾を消す場所

    void Start()
    {

    }

    
    void Update()
    {
        //X側方向に進む→
        transform.Translate(Mov_X, 0f, 0f);

        //【ボールのポジション】のコードを短くする
        float Des_Bull = transform.position.x;

        //X方向に一定まで進んだら
        if (Des_Bull>=Range)
        {
            //弾自信を消す
            Destroy(gameObject);
        }
    }
}
