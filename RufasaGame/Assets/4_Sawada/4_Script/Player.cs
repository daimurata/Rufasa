using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//プレイヤーを制御するスクリプト
public class Player : MonoBehaviour
{
    //hpの最大値
    public int hpmax;
    //hp
    public int hp;
    //弾の発射間隔
    public float shotintval;
    // 弾の発射タイミングを管理するタイマー
    public float shottime;
    //弾のプレハブ
    public GameObject bulletprefab;
    //移動の速さ
    public float m_speed;
    //他のスクリプトで参照にされる時に使う
    public static Player instance;
    // Start is called before the first frame update
    private void Awake()
    {
        //hp
        hp = hpmax;
        //このスクリプト
        instance = this;
    }
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
        //プレイヤーの位置
        var pos = transform.localPosition;
        //プレイヤーの向き
        var rot = transform.localRotation;
        //WASDの入力情報を取得
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        //プレイヤーの移動処理
        var velocity = new Vector3(h, v) * m_speed;
        transform.localPosition += velocity;
        // プレイヤーが画面外に出ないように位置を制限する
        transform.localPosition = Utils.Clamppostion(transform.localPosition);
        //弾の発射タイミングを管理するタイマーを更新する
        shottime += Time.deltaTime;
        //まだ弾の発射タイミングではない場合は、ここで処理を終える
        if (shottime < shotintval) return;
        //弾の発射タイミングを管理するタイマーをリセットする
        shottime = 0;
        //弾を発射する
        if (Input.GetMouseButton(0))
        {
            Instantiate(bulletprefab, pos, rot);
        }
    }
    //ダメージを受けた時の処理
    public void Dmage(int dmage)
    {
        hp -= dmage;
        if (0 < hp) return;
        gameObject.SetActive(false);
    }
}
