using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefab : MonoBehaviour
{
    public static EnemyPrefab ep;
   public int enemycost;
    public GameObject enemyprefab;
    // Start is called before the first frame update
    void Start()
    {
     
        //4秒ごとに敵が出現する
        InvokeRepeating("Prefab", 4, 1);

    }
    void Prefab()
    {
        if (enemycost >= 40)
            return;
        //敵の出現位置
        Instantiate(enemyprefab, new Vector3(8.5f, 4.7f -8 * Random.value, 0),Quaternion.identity);
        enemycost += 1;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
