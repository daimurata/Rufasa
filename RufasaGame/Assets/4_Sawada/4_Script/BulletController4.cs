using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController4 : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        //弾の移動処理
        transform.Translate(0, 0.2f, 0);
        //弾が画面端まできたら消す
        if (transform.position.x > 9)
        {
            Destroy(gameObject);
        }
    }
}
