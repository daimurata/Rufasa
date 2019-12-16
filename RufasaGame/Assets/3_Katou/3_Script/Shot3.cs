using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// プレイヤーが発射する弾を制御するコンポーネント
public class Shot3 : MonoBehaviour
{
    private Vector3 m_velocity; // 速度
    public float lifetime;      //自動消滅時間
    public Score scoreComp;  //Scoreコンポーネント

    void Start()
    {
        //シーン内にあるScoreコンポーネントを確保
        scoreComp = GameObject.Find("ScoreText").GetComponent<Score>();
    }

    // 毎フレーム呼び出される関数
    private void Update()
    {
        // 移動する
        transform.localPosition += m_velocity;

        Destroy(this.gameObject, lifetime); //設定時間後弾丸は消滅する
    }

    // 弾を発射する時に初期化するための関数
    public void Init(float angle, float speed)
    {
        // 弾の発射角度をベクトルに変換する
        var direction = Utils3.GetDirection(angle);

        // 発射角度と速さから速度を求める
        m_velocity = direction * speed;

        // 弾が進行方向を向くようにする
        var angles = transform.localEulerAngles;
        angles.z = angle - 90;
        transform.localEulerAngles = angles;

    }

    //衝突時処理：Scoreコンポーネントの衝突時メソッドにタグを渡す
    void OnCollisionEnter(Collision collision)
    {
        scoreComp.HitShot(collision.gameObject.tag);
    }

}