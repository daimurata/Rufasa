using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3.0f);//インスタンスが生成されて3.0秒後に消す
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
