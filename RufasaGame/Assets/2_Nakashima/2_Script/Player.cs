using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //よわよわ弾
    public GameObject Bullet1;
    //つよつよ弾
    public GameObject Bullet2;
    //PlayerのHP
    public int PlayerHP = 3;

    public EnemyBullet enemyBullet;
    int enemybCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerのHPが0になったら～
        if(PlayerHP == 0)
        {
            //Playerを消す
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        //移動させる
        if (Input.GetKey(KeyCode.RightArrow))//右矢印
        {
            transform.Translate(1.0f, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))//左矢印
        {
            transform.Translate(-1.0f, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.UpArrow))//上矢印
        {
            transform.Translate(0.0f, 1.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.DownArrow))//下矢印
        {
            transform.Translate(0.0f, -1.0f, 0.0f);
        }
        //弾の発射（段数制限つけてない）
        if (Input.GetMouseButtonDown(0))//左クリック
        {
            //弱い方の弾
            Instantiate(Bullet1, transform.position, Quaternion.identity);
        }
        if (Input.GetMouseButtonDown(1))//右クリック
        {
            //強い方の弾
            Instantiate(Bullet2, transform.position, Quaternion.identity);
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        //敵に当たったら
        if(collision2D.gameObject.tag == "Enemy")
        {
            //PlayerのHPを減らす
            PlayerHP -= 1;
        }
    }
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        enemybCount = enemyBullet.EnemyBulletDamege;
        //敵の弾に当たったらー
        if(collider2D.gameObject.tag == "EnemyBullet")
        {
            //PlayerのHPを減らす
            PlayerHP -= enemybCount;
            //当たった弾を消す
            Destroy(collider2D.gameObject);
        }
    }
}
