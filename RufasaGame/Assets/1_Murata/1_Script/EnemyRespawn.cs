using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の生成スクリプト
/// </summary>
public class EnemyRespawn : MonoBehaviour
{
    //敵の数
    public int EnemyCount;

    //敵の生成するもの
    public GameObject Enemy;

    //生成する時間
    public float RespawnTim;

    //時間を空ける
    public float SpawnTim;

    /// <summary>
    /// 初期
    /// </summary>
    void Start()
    {

    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        //時間の追加
        RespawnTim += Time.deltaTime;

        //生成する時間が5秒以上なら
        if (RespawnTim>=SpawnTim)
        {
            //生成
            EnemyControl();
            //時間のリセット
            RespawnTim = 0;
        }
    }
    /// <summary>
    /// 敵を生成する
    /// </summary>
    void EnemyControl()
    {
        //敵の数が40以下なら
        if (EnemyCount<=40)
        {
            //敵の生成位置をランダムにする
            Instantiate(Enemy, new Vector3(9.5f,2.8f -7*Random.value,0), Quaternion.identity);

            //敵のカウントを1増やす
            EnemyCount += 1;
        }
    }
}
