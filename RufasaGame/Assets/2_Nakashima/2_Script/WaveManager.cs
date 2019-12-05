using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    //ランダムな場所に生成するEnemy
    public GameObject[] waveEnemy = new GameObject[5];

    //ランダムな場所に生成する範囲
    float EnemyPosX, EnemyPosY;

    GameObject[] EnemyTag;

    //ここでcase分の数値を変更する
    public int wave;
    // Start is called before the first frame update
    void Start()
    {
        //ここでランダムな場所に生成させる
        //X軸の範囲
        EnemyPosX = Random.Range(-5f, 5f);
        //Y軸の範囲
        EnemyPosY = Random.Range(-5f, 5f);

        //Enemyの数だけランダムな場所に移動を繰り返す
        for (int i = 0; i < waveEnemy.Length; i++)
        {
            waveEnemy[i].transform.position = new Vector2(EnemyPosX, EnemyPosY);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //ここでEnemyの数が残っているかどうかの判定
        
    }
    public void EnemyCheck()
    {
        //Enemyが減る度にこれを呼び出す
        //Enemyのtagが付いたオブジェクトを探す
        EnemyTag = GameObject.FindGameObjectsWithTag("Enemy");
        //↑の数を表示
        Debug.Log(EnemyTag.Length);

        //タグの数が0個になったら
        if(EnemyTag.Length == 0)
        {
            //次のWaveの表示かな？
            switch (wave)
            {
                case 1:
                    break;
                case 2:
                    break;
            }
        }
    }
}
