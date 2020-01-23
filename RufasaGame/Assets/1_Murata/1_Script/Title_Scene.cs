using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Title画面に行く
/// </summary>
public class Title_Scene : MonoBehaviour
{
    /// <summary>
    /// 初期データ
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// 常に更新
    /// </summary>
    void Update()
    {
        
    }

    /// <summary>
    /// ボタンをあされた場合の処理
    /// </summary>
    public void OnClick()
    {
        //読み込むシーン
        SceneManager.LoadScene("Title_0");
    }
}
