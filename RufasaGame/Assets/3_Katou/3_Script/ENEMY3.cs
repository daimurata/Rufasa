using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 敵の出現位置の種類
public enum RESPAWN_TYPE
{
   
    RIGHT, // 右
   
    SIZEOF, // 敵の出現位置の数
}

// 敵を制御するコンポーネント
public class ENEMY3: MonoBehaviour
{
    public GameObject explosionPrefab;   //爆発エフェクトのPrefab
    public Vector2 m_respawnPosInside; // 敵の出現位置（内側）
    public Vector2 m_respawnPosOutside; // 敵の出現位置（外側）
    public float m_speed; // 移動する速さ
    public int m_hpMax; // HP の最大値
    public int m_damage; // この敵がプレイヤーに与えるダメージ
    public float lifetime;      //自動消滅時間
    private int m_hp; // HP
    private Vector3 m_direction; // 進行方向
    public bool m_isFollow; // プレイヤーを追尾する場合 true

    // 敵が生成された時に呼び出される関数
    private void Start()
    {
        // HP を初期化する
        m_hp = m_hpMax;

        Destroy(gameObject, lifetime); //設定時間後敵は消滅する
    }

    // 毎フレーム呼び出される関数
    private void Update()
    {
        // プレイヤーを追尾する場合
        if (m_isFollow)
        {
            // プレイヤーの現在位置へ向かうベクトルを作成する
            var angle = Utils3.GetAngle(
                transform.localPosition,
                PLAYER3.m_instance.transform.localPosition);
            var direction = Utils3.GetDirection(angle);

            // プレイヤーが存在する方向に移動する
            transform.localPosition += direction * m_speed;

            // プレイヤーが存在する方向を向く
            var angles = transform.localEulerAngles;
            angles.z = angle - 90;
            transform.localEulerAngles = angles;
            return;
        }

        // まっすぐ移動する
        transform.localPosition += m_direction * m_speed;
    }

    // 敵が出現する時に初期化する関数
    public void Init(RESPAWN_TYPE respawnType)
    {
        var pos = Vector3.zero;

        // 指定された出現位置の種類に応じて、
        // 出現位置と進行方向を決定する
        switch (respawnType)
        {
         

            // 出現位置が右の場合
            case RESPAWN_TYPE.RIGHT:
                pos.x = m_respawnPosOutside.x;
                pos.y = Random.Range(
                    -m_respawnPosInside.y, m_respawnPosInside.y);
                m_direction = Vector2.left;
                break;

          
        }

        // 位置を反映する
        transform.localPosition = pos;
    }

    // 他のオブジェクトと衝突した時に呼び出される関数
    private void OnTriggerEnter2D(Collider2D collision)
    {

        // プレイヤーと衝突した場合
        if (collision.name.Contains("Player"))
        {
            // プレイヤーにダメージを与える
            var player = collision.GetComponent<PLAYER3>();
            player.Damage(m_damage);
            return;
        }

        // 弾と衝突した場合
        if (collision.name.Contains("Shot"))
        {
            // 弾を削除する
            Destroy(collision.gameObject);

            // 敵の HP を減らす
            m_hp--;

            // 敵の HP がまだ残っている場合はここで処理を終える
            if (0 < m_hp) return;
            // 爆発エフェクトを生成する	
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);

            // 敵を削除する
            Destroy(gameObject);
        }
    }
}
