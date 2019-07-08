using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //敵のHP
    public int EnemyHP;
    //弾のスクリプトから変数を受け取れるようにする、弾が2種類あるから分けた
    public Bullet bullet1;
    public Bullet bullet2;
    //BulletのDamegeの値を入れるための変数
    int bCount1;
    int bCount2;

    //敵が撃つ弾
    public GameObject EnemyBullet;
    //弾を撃つ時間を入れる変数
    float BulletTime;

    //Playerの位置を取得するため
    //Transform playerpos;
    //敵の移動速度
    float EnemySpeed = 0.03f;

    float rot;
    Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //敵のHPが0になったら～
        if (EnemyHP == 0)
        { 
            //敵自身を消す
            Destroy(gameObject);
        }
        //呼び出しー
        EnemyAttack();
        EnemyMove();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        bCount1 = bullet1.Damege;
        bCount2 = bullet2.Damege;

        if (col.gameObject.tag == "Bullet1")
        {
            //敵のHPを減らす
            EnemyHP -= bCount1;
            //当たった弾を消す
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Bullet2")
        {
            EnemyHP -= bCount2;
            //当たった弾を消す
            Destroy(col.gameObject);
        }     
    }

    void EnemyMove()
    {
        //プレイヤーの位置を取得
        var playerpos = GameObject.FindWithTag("Player").transform.position;
        GameObject.Find("Player").transform.position = new Vector3(playerpos.x, playerpos.y, playerpos.z);

        rot = Mathf.Atan2(playerpos.y - transform.position.y, playerpos.x - transform.position.x);
        pos = transform.position;
        pos.x += EnemySpeed * Mathf.Cos(rot);
        pos.y += EnemySpeed * Mathf.Sin(rot);
        transform.position = pos;

        //現状ただ左に移動
        //transform.Translate(Vector3.left* EnemySpeed * Time.deltaTime);
    }

    void EnemyAttack()
    {
        //時間を徐々に足す
        BulletTime += Time.deltaTime;
        //とりあえず3s毎
        if(BulletTime >= 3f)
        {
            //0sに戻す
            BulletTime = 0f;
            Instantiate(EnemyBullet, transform.position, Quaternion.identity);
        }
    }
}
