using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の生成スクリプト
/// </summary>
public class EnemyRespawn : MonoBehaviour
{
    //敵の数
    public int EnemyCounts;

    //敵の生成するもの
    public GameObject[] Enemy;

    //生成する時間
    public float RespawnTim;

    //時間を空ける
    public float SpawnTim;

    //中ボス出現
    public int Mini_Cuunt=0;

    private int Mini_ros = 3;

    private int Enemy_ros = 40;

    private int Boos_ros = 1;
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
        if (Enemy_ros>=0)
        {
            //敵の数が40以下なら
            if (EnemyCounts <= 40)
            {
                //敵の生成位置をランダムにする
                Instantiate(Enemy[0], new Vector3(9.5f, 2.8f - 7 * Random.value, 0), Quaternion.identity);

                //敵のカウントを1増やす
                EnemyCounts += 1;
                //中ボスカウントを増やす
                Mini_Cuunt += 1;
                Enemy_ros -= 1;
            }
        }


        if (Mini_ros>=0)
        {
            //敵中ボスを生成
            if (Mini_Cuunt == 10)
            {
                //敵の生成位置をランダムにする
                Instantiate(Enemy[1], new Vector3(9.5f, 2.8f - 7 * Random.value, 0), Quaternion.identity);

                //敵の生成位置をランダムにする
                Instantiate(Enemy[1], new Vector3(9.5f, 2.8f - 7 * Random.value, 0), Quaternion.identity);

                //敵の生成位置をランダムにする
                Instantiate(Enemy[1], new Vector3(9.5f, 2.8f - 7 * Random.value, 0), Quaternion.identity);

                //0にする
                Mini_Cuunt = 0;
                Mini_ros -= 1;
            }
        }

        if (Boos_ros>=0)
        {
            //敵の大ボスを生成
            if (EnemyCounts == 39)
            {
                //敵の生成位置をランダムにする
                Instantiate(Enemy[2], new Vector3(9.5f, 2.8f - 7 * Random.value, 0), Quaternion.identity);
                Boos_ros -=1;
            }
        }

    }

    /// <summary>
    /// 敵が倒せなかった時
    /// </summary>
    public void Enemy_Dow()
    {
        EnemyCounts -= 1;

        Enemy_ros += 1;
    }
}
