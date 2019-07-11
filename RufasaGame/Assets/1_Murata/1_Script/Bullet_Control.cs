using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 弾のコントロール
/// </summary>
public class Bullet_Control : MonoBehaviour
{
    public float Bullet_Speed = 1;  //弾のスピード

    public float[] RestrictionBullet_X, RestrictionBullet_Y;    //範囲制限

    void Start()
    {
        //方向
        GetComponent<Rigidbody2D>().velocity = transform.right.normalized * Bullet_Speed;
    }

    
    void Update()
    {
        
    }

    //void 
}
