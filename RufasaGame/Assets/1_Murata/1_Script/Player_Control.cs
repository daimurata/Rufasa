using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// プレイヤーの操作
/// </summary>
public class Player_Control : MonoBehaviour
{
    //プレイヤー
    public GameObject Player;                           

    //移動速度
    public float Pl_Mov;                                

    //移動範囲
    public float[] Restriction_X, Restriction_Y;         

    //通常弾、強弾
    public GameObject[] Bullet = new GameObject[2];      

    //HPの画像
    public Image[] HP_Mark = new Image[3];               

    //HPの数値
    public int HP_Life=3;

    //弾の間隔
    public float Bullet_intval;

    //弾の次弾発射時間
    public float Bullet_Time;

    //リザルト表示
    public GameObject Result_Canvas;

    //敵生成をやめる
    public GameObject Enemy_System;

    //時間点滅
    public float Player_Blink = 2;

    //α値
    public float Alpha = 1;

    //点滅分岐
    private bool Flashing = false;

    //切替
    private bool Alpha_Flashing=true;

    //強い弾討ちます
    public GameObject Power_Bullet;

    //変更切替
    public bool Color_Change=false;
    /// <summary>
    /// 初期データ
    /// </summary>
    void Start()
    {
        //Enemy_System探す
        Power_Bullet = GameObject.Find("Enemy_System");
        
    }


    /// <summary>
    /// 常に更新
    /// </summary>
    void Update()
    {
        //移動処理
        Move_Control();
        //移動制限
        Restriction_Mov();

        //HP画像と数字を接続処理
        HP_Control();

        //弾を発射処理
        Bullet_Controller();
        //キャラクター点滅時間
        PlayerBlink();

    }

    /// <summary>
    /// 移動管理
    /// </summary>
    void Move_Control()
    {
        //【プレイヤーのポジション】のコードを短くする
        Vector2 Position= Player.transform.position;

        //左に移動【Aキー】
        if (Input.GetKey(KeyCode.A))
        {
            //左に移動する
            Position.x -= Pl_Mov;
        }

        //右に移動【Dキー】
        if (Input.GetKey(KeyCode.D))
        {
            //右に移動
            Position.x += Pl_Mov;
        }

        //上に移動【Wキー】
        if (Input.GetKey(KeyCode.W))
        {
            //上に移動する
            Position.y += Pl_Mov;
        }

        //下に移動【Sキー】
        if (Input.GetKey(KeyCode.S))
        {
            //下に移動する
            Position.y -= Pl_Mov;
        }
        //【移動データ】を更新する
        Player.transform.position =new  Vector2(Position.x,Position.y);
    }

    /// <summary>
    /// 移動制限
    /// </summary>
    void Restriction_Mov()
    {
        //【Xのポジション】のコードを短くする
        float Pl_X = Player.transform.position.x;
        //【Yのポジション】のコードを短くする
        float Pl_y = Player.transform.position.y;

        //左側制御
        if (Pl_X>=Restriction_X[0])
        {
            //値を代入
            Pl_X = Restriction_X[0];
        }

        //右側制御
        if (Pl_X<=Restriction_X[1])
        {
            //値を代入
            Pl_X = Restriction_X[1];
        }

        //上側制御
        if (Pl_y>=Restriction_Y[0])
        {
            //値を代入
            Pl_y = Restriction_Y[0];
        }

        //下側制御
        if (Pl_y<Restriction_Y[1])
        {
            //値を代入
            Pl_y = Restriction_Y[1];
        }
        //【制限データ】を更新
        Player.transform.position = new Vector2(Pl_X,Pl_y);
    }

    /// <summary>
    /// HP画像と数字を接続
    /// </summary>
    void HP_Control()
    {
        //HPが満タン
        if (HP_Life==3)
        {
            HP_Mark[0].enabled = true;  //HP_1
            HP_Mark[1].enabled = true;  //HP_2
            HP_Mark[2].enabled = true;  //HP_3
        }
        //HPが残り2つ
        if (HP_Life == 2)
        {
            HP_Mark[0].enabled = true;   //HP_1
            HP_Mark[1].enabled = true;   //HP_2
            HP_Mark[2].enabled = false;  //HP_3
        }
        //HPが残り1つ
        if (HP_Life == 1)
        {
            HP_Mark[0].enabled = true;   //HP_1
            HP_Mark[1].enabled = false;  //HP_2
            HP_Mark[2].enabled = false;  //HP_3
        }
        //HPがゼロ
        if (HP_Life == 0)
        {
            HP_Mark[0].enabled = false;  //HP_1
            HP_Mark[1].enabled = false;  //HP_2
            HP_Mark[2].enabled = false;  //HP_3

            Result_Canvas.SetActive(true);//リザルト表示
            Enemy_System.SetActive(false);//敵の生成をしない（非表示）
            Destroy(gameObject);    //このオブジェクトを削除する
        }
    }

    /// <summary>
    /// 弾の発射
    /// </summary>

    void Bullet_Controller()
    {
        //弾の時間を加算
        Bullet_Time += Time.deltaTime;

        //次弾を撃てる時間なら
        if (Bullet_Time>Bullet_intval)
        {
            //左クリック
            if (Input.GetMouseButton(0))
            {
                //通常弾
                Instantiate(Bullet[0], transform.position, Quaternion.identity);
            }
            //弾のリセット
            Bullet_Time = 0;
        }
    }
    /// <summary>
    /// 当たったら
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //敵の弾に触れたとき
        if(collision.name.Contains("Enemy_Bullet Variant")||
            //敵に触れたとき
                collision.name.Contains("Small_Enemy"))
        {
            //キャラクターの点滅　可能
            Flashing = true;
            //HPを1つ下げる
            HP_Life--;
            //触れた敵と弾は削除
            Destroy(collision.gameObject);

            //色変更
            Color_Change = true;

            Enemy_Count Color_mod = Power_Bullet.GetComponent<Enemy_Count>();
            Color_mod.true_col();
        }
    }
    /// <summary> 
    /// キャラクターの点滅 
    /// </summary>

    void PlayerBlink()
    {
        //点滅が可能なら
        if (Flashing == true)
        {
            //切替
            if(Alpha_Flashing==true)
            {
                //α値減算
                Alpha -= 5*Time.deltaTime;
                //0以下になったら
                if (Alpha<=0.0f)
                {
                    //0に固定
                    Alpha = 0.0f;
                    //切替　加算
                    Alpha_Flashing = false;
                }
             //切替　
            }else if(Alpha_Flashing==false)
            {
                //α値加算
                Alpha += 5*Time.deltaTime;
                //1以上になったら
                if (Alpha>=1.0f)
                {
                    //1に固定
                    Alpha = 1.0f;
                    //切替　減算
                    Alpha_Flashing = true;
                }
            }
 


            //減算 α値
            Player_Blink -= Time.deltaTime;
            //キャラを赤くする
            Red_PL();
            //0以下になったら
            if (Player_Blink<=0)
            {
                //初期化　α値
                Alpha = 1f;
                //点滅終了
                Flashing = false;
                //初期化　点滅時間
                Player_Blink = 3.0f;

                //色変え終わり
                Color_Change = false;
                
                //色の変更
                Enemy_Count Color_tru = Power_Bullet.GetComponent<Enemy_Count>();
                Color_tru.False_col();

            }
        }
    }
    /// <summary>
    ///　強力な攻撃
    /// </summary>
    public void MAX_Power()
    {
        //右クリック
        if (Input.GetMouseButtonDown(1))
        {
            //強弾
            Instantiate(Bullet[1], transform.position, Quaternion.identity);

            //PowerDown
            Enemy_Count Down = Power_Bullet.GetComponent<Enemy_Count>();

            //実行
            Down.Power_Down();
        }
    }
    /// <summary>
    /// 色の固定
    /// </summary>
    public void Color_System()
    {
        //falseなら
        if (Color_Change==false)
        {
            //条件付き色固定
            Enemy_Count Cl_PL = Power_Bullet.GetComponent<Enemy_Count>();
            //実行
            Cl_PL.Color_Pl();
        }
    }

    /// <summary>
    /// キャラクターを赤くする
    /// </summary>
    public void Red_PL()
    {
        //時間がたつまで
        if (0 <= Player_Blink && Color_Change == true)
        {
            //赤色に変更
            GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, Alpha);
        }
    }
}
