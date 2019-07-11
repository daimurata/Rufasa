using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの操作
/// </summary>
public class Player_Control : MonoBehaviour
{
    
    public GameObject Player;   //プレイヤー
    public float Speed, Pl_Mov=1;    //スピード,移動
    public float[] Restriction_X, Restriction_Y;

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
}
