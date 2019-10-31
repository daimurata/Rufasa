using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// プレイヤーの操作
/// </summary>
public class Player_Control : MonoBehaviour
{
    
    public GameObject Player;                            //プレイヤー
    public float Pl_Mov;                                 //移動速度
    public float[] Restriction_X, Restriction_Y;         //移動範囲

    public GameObject[] Bullet = new GameObject[2];      //通常弾、強弾
    public Image[] HP_Mark = new Image[3];               //HPの画像
    public int HP_Life=3;                                //HPの数値

    /// <summary>
    /// 初期データ
    /// </summary>
    void Start()
    {
        
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

        /////////
        ///デバック用
        /////////
        if (Input.GetKeyDown(KeyCode.X)) //Xキー
        {
            HP_Life--;//HPが1減る
        }
        if (Input.GetKeyDown(KeyCode.Z))　//Zキー
        {
            HP_Life++;//HPが1増える
        }
        //////////
        ///デバック用
        //////////

        //弾を発射処理
        Bullet_Controller();
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
            Destroy(gameObject);    //このオブジェクトを削除する
        }
    }

    /// <summary>
    /// 弾の発射
    /// </summary>

    void Bullet_Controller()
    {
        //左クリック
        if (Input.GetMouseButtonDown(0))
        {
            //通常弾
            Instantiate(Bullet[0],transform.position, Quaternion.identity);
        }
        //右クリック
        if (Input.GetMouseButtonDown(1))
        {
            //強弾
            Instantiate(Bullet[1], transform.position, Quaternion.identity);
        }
    }
}
