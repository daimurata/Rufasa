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
    public float[] Enemy_Speed;

    //座標
    public Vector2 Pos;

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

    //弾のダメージ数
    public int HP_Damage=1;

    //多き弾のダメージ数
    public int HP_BIG_Damage=3;

    //スコア表示
    public GameObject Score_Text;

    //移動切替 trueなら←方向へ
    public bool X_GO=true;

    //移動切替 trueなら↕方向へ
    public bool Y_GO = true;

    //Y座標の移動範囲
    public float[] Y_Restriction;

    //Y座標チェンジ
    private bool Y_Change;

    /// <summary>
    /// 初期データ
    /// </summary>
    void Start()
    {
        //Enemy_System探す
        Enemy_Dow = GameObject.Find("Enemy_System");

        //Scoreを探す
        Score_Text = GameObject.Find("Score");
    }

    
    /// <summary>
    /// 常に更新
    /// </summary>
    void Update()
    {
        //X方向に進む
        X_Move();
        //Y方向に進む
        Y_Move();
        //XY方向に進む
        XY_Move();
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
    /// <summary>
    /// 当たり判定
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //小さな弾（プレイヤー）
        if (collider.name.Contains("Ball"))
        {
            //小さい弾のダメージ計算
            Enemy_Life -= HP_Damage;
        }
        //大きい弾（プレイヤー）
        if (collider.name.Contains("Ball_BIG"))
        {
            //大きい弾のダメージ計算
            Enemy_Life -= HP_BIG_Damage;
        }
        //プレイヤーに突撃（特攻）
        if (collider.name.Contains("Player"))
        {
            //特攻計算
            Enemy_Life -= HP_Damage;
        }
            //HPが0以下なら
        if (Enemy_Life <= 0)
        {
            //倒した敵の加算
            Enemy_Count Count_Destroy = Enemy_Dow.GetComponent<Enemy_Count>();
            //実行
            Count_Destroy.Enemy_Lost();

            //X方向に移動する敵のスコア加算
            if (X_GO==true&&Y_GO==false)
            {
                //スコアを加算する
               Score_Manager Enemy_Score = Score_Text.GetComponent<Score_Manager>();
                //実行
                Enemy_Score.Score_UP();
            }

            //Y方向に移動する敵のスコア加算
            if (Y_GO == true && X_GO == false)
            {
                //スコアを加算する
                Score_Manager Enemy_Mini_Score = Score_Text.GetComponent<Score_Manager>();
                //実行
                Enemy_Mini_Score.Score_Big_UP();
            }

            //XY方向に移動する敵のスコア加算
            if (Y_GO == true && X_GO == true)
            {
                //スコアを加算する
                Score_Manager Enemy_BIG_Score = Score_Text.GetComponent<Score_Manager>();
                //実行
                Enemy_BIG_Score. Score_Mini_UP();
            }

            //自信を削除
            Destroy(gameObject);

        }
    }
    /// <summary>
    /// X方向に移動
    /// </summary>
    private void X_Move()
    {
        //X方向←の方向に進む
        if (X_GO==true&&Y_GO==false)
        {
            //敵の座標を代入
            Pos = transform.position;

            //座標Xに減算処理
            Pos.x -= Enemy_Speed[0] * Time.deltaTime;

            //反映
            transform.position = Pos;

            //敵が弾を撃つ処理
            Bullet_Shoot();

            //X方向に一定まで進んだら
            if (Range >= transform.position.x)
            {
                //敵生成数に減算
                EnemyRespawn Dow = Enemy_Dow.GetComponent<EnemyRespawn>();
                //減算　実行
                Dow.Enemy_Dow();
                //自信を消す
                Destroy(gameObject);
            }
        }
       
    }
    /// <summary>
    /// Y方向に移動
    /// </summary>
    private void Y_Move()
    {
        //Y方向↕の方向に進む
        if (Y_GO == true&&X_GO==false)
        {
            //敵の座標を代入
            Pos = transform.position;

            Pos.x -= 0.1f*Time.deltaTime;
            //Y座標下に移動
            if (Y_Change == true)
            {
                //座標Xに減算処理
                Pos.y -= Enemy_Speed[1] * Time.deltaTime;

                //反映
                transform.position = Pos;
                //Y座標が制限以上なら
                if (Y_Restriction[1] >= Pos.y)
                {
                    //上に移動
                    Y_Change = false;
                }
            }

            //Y座標上に移動
            if (Y_Change == false)
            {
                //座標Xに減算処理
                Pos.y += Enemy_Speed[1] * Time.deltaTime;

                //反映
                transform.position = Pos;
                //Y座標が制限以下なら
                if (Y_Restriction[0] <= Pos.y)
                {
                    //下に移動
                    Y_Change = true;
                }
            }
            transform.position = Pos;
            
            //敵が弾を撃つ処理
            Bullet_Shoot();
        }
    }
    /// <summary>
    /// XY方向に移動
    /// </summary>
    private void XY_Move()
    {
        //XY方向に進む
        if (X_GO==true&&Y_GO==true)
        {
            //敵の座標を代入
            Pos = transform.position;

            //座標Xに減算処理
            Pos.x -= Enemy_Speed[0] * Time.deltaTime;

            //Y座標下に移動
            if (Y_Change == true)
            {
                //座標Xに減算処理
                Pos.y -= Enemy_Speed[1] * Time.deltaTime;

                //反映
                transform.position = Pos;
                //Y座標が制限以上なら
                if (Y_Restriction[1] >= Pos.y)
                {
                    //上に移動
                    Y_Change = false;
                }
            }

            //Y座標上に移動
            if (Y_Change == false)
            {
                //座標Xに減算処理
                Pos.y += Enemy_Speed[1] * Time.deltaTime;

                //反映
                transform.position = Pos;
                //Y座標が制限以下なら
                if (Y_Restriction[0] <= Pos.y)
                {
                    //下に移動
                    Y_Change = true;
                }
            }

            //敵が弾を撃つ処理
            Bullet_Shoot();

            //X方向に一定まで進んだら
            if (Range >= transform.position.x)
            {
                //敵生成数に減算
                EnemyRespawn Dow = Enemy_Dow.GetComponent<EnemyRespawn>();
                //減算　実行
                Dow.Enemy_Dow();
                //自信を消す
                Destroy(gameObject);
            }
        }

    }

}
