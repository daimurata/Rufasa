using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet2 : MonoBehaviour
{

    //弾の威力
    public int EnemyBulletDamege = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        //X側→方向にまっすぐ移動
        transform.Translate(-1.0f, 0.0f, 0.0f);
        //X方向に一定まで進んだら
        if (transform.position.x < -10.0f)
        {
            //弾自身を消す
            Destroy(gameObject);
        }
    }
}
