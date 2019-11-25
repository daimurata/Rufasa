using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の動作処理
/// </summary>
public class Enemy_Control : MonoBehaviour
{
    //敵のHP
    public int Enemy_Life;

    //移動スピード
    public float Enemy_Speed;

    //座標
    private Vector2 Pos;

    //敵の弾
    public GameObject Enemy_Bullet;

    //弾を撃つ時間
    public float Shoot_Tim;

    //リセットする時間
    public float Reset_Tim;

    //敵を消す場所
    public float Range = -9.46f;
    //倒せなくても生成させる
    public GameObject Enemy_Dow;

    /// <summary>
    /// 初期データ
    /// </summary>
    void Start()
    {
        //Enemy_System探す
        Enemy_Dow = GameObject.Find("Enemy_System");
    }

    
    /// <summary>
    /// 常に更新
    /// </summary>
    void Update()
    {
        //敵の座標を代入
        Pos = transform.position;

        //座標Xに減算処理
        Pos.x -= Enemy_Speed * Time.deltaTime;

        //反映
        transform.position = Pos;

        //敵が弾を撃つ処理
        Bullet_Shoot();

        //X方向に一定まで進んだら
        if (Range>=transform.position.x)
        {
            //敵生成数に減算
            EnemyRespawn Dow = Enemy_Dow.GetComponent<EnemyRespawn>();
            //減算　実行
            Dow.Enemy_Dow();
            //自信を消す
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 敵が弾を撃つ処理
    /// </summary>
    void Bullet_Shoot()
    {
        //時間を加算
        Reset_Tim += Time.deltaTime;

        //弾を撃つ時間を過ぎると撃つ
        if (Reset_Tim>=Shoot_Tim)
        {
            //弾生成
            Instantiate(Enemy_Bullet,transform.position,Quaternion.identity);

            //0に戻す
            Reset_Tim = 0;
        }
    }
}
