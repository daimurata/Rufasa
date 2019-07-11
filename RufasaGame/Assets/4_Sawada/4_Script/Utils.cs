using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    // 移動可能な範囲
    public static Vector2 moveLimit = new Vector2(8.4f, 4.7f);
    // 指定された位置を移動可能な範囲に収めた値を返す
    public static Vector3 Clamppostion(Vector3 positon)
    {
        return new Vector3
    (
            Mathf.Clamp(positon.x,-moveLimit.x,moveLimit.x),
            Mathf.Clamp(positon.y,-moveLimit.y,moveLimit.y),
            0
            );
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
