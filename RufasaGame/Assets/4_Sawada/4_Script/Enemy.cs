using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //プレイヤーに与えるダメージ
    public int m_damge;
    //hp
    public int hp;
    //移動スピード
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //横一直線に移動する
        transform.Translate(-Vector3.right * speed * Time.deltaTime);
        if (transform.position.x <- 9)
        {
            Destroy(gameObject);
           
        }
    }
    //弾にぶつかったらダメージを受ける
    private void OnTriggerEnter2D(Collider2D collison)
    {
        //プレイヤーにぶつかったらダメージを与える
        if (collison.name.Contains("player"))
        {
            var player = collison.GetComponent<Player>();
            player.Dmage(m_damge);
            return;
        }
        //弾に当たったらダメージを受ける
        if (collison.name.Contains("shot"))
        {
            Destroy(collison.gameObject);
            hp--;
            if (0 < hp) return;
            Destroy(gameObject);
          
        }
    }
}
