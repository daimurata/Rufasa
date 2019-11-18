using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Game画面に行く（再読み込み）
/// </summary>
public class Game_Scene : MonoBehaviour
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
        SceneManager.LoadScene("Game_1");
    }
}
