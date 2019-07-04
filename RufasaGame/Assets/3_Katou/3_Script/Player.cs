using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// プレイヤーを制御するコンポーネント
public class Player : MonoBehaviour
{
    public float m_speed; // 移動の速さ
    public GameObject Shot; // 弾のプレハブ
    public float shotspeed; // 弾の移動の速さ
    public float player_HP; //プレイヤーのHP
    private Vector3 m_velocity; // 速度


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
}