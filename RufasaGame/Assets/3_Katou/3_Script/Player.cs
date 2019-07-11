using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// プレイヤーを制御するコンポーネント
public class PLAYER : MonoBehaviour
{
    public float m_speed; // 移動の速さ
    public GameObject Shot; // 弾のプレハブ
    public float shotspeed; // 弾の移動の速さ
    public float player_HP; //プレイヤーのHP
    public int m_hpMax; // HP の最大値
    public int m_hp; // HP
    private Vector3 m_velocity; // 速度                           
    public static PLAYER m_instance; // プレイヤーのインスタンスを管理する static 変数


    // ゲーム開始時に呼び出される関数
    private void Awake()
    {
        // 他のクラスからプレイヤーを参照できるように
        // static 変数にインスタンス情報を格納する
        m_instance = this;

        m_hp = m_hpMax; // HP
    }

    // 毎フレーム呼び出される関数
    private void Update()
    {
        // 矢印キーの入力情報を取得する
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        // 矢印キーが押されている方向にプレイヤーを移動する
        var velocity = new Vector3(h, v) * m_speed;
        transform.localPosition += velocity;

        // プレイヤーが画面外に出ないように位置を制限する
        transform.localPosition = Utils.ClampPosition(transform.localPosition);

        // プレイヤーのスクリーン座標を計算する
        var screenPos = Camera.main.WorldToScreenPoint(transform.position);

        // プレイヤーから見たマウスカーソルの方向を計算する
        var direction = Input.mousePosition - screenPos;

        // マウスカーソルが存在する方向の角度を取得する
        var angle = Utils.GetAngle(Vector3.zero, direction);

        // プレイヤーがマウスカーソルの方向を見るようにする
        var angles = transform.localEulerAngles;
        angles.z = angle - 90;
        transform.localEulerAngles = angles;

        // 移動する
        transform.localPosition += m_velocity;

        if (Input.GetMouseButtonDown(0))
        {

            // 弾（ゲームオブジェクト）の生成
            GameObject clone = Instantiate(Shot, transform.position, Quaternion.identity);

            // クリックした座標の取得（スクリーン座標からワールド座標に変換）
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 向きの生成（Z成分の除去と正規化）
            Vector3 shotForward = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;

            // 弾に速度を与える
            clone.GetComponent<Rigidbody2D>().velocity = shotForward * shotspeed;
        }
    }

    // ダメージを受ける関数
    // 敵とぶつかった時に呼び出される
    public void Damage(int damage)
    {
        // HP を減らす
        m_hp -= damage;

        // HP がまだある場合、ここで処理を終える
        if (0 < m_hp) return;

        // プレイヤーが死亡したので非表示にする
        // 本来であれば、ここでゲームオーバー演出を再生したりする
        gameObject.SetActive(false);
    }

}