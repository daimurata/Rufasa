using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager2 : MonoBehaviour
{
    //勝利時の画像と、敗北時の画像
    public GameObject WinImage;
    public GameObject LoseImage;
    //ボタン2個
    public GameObject[] button = new GameObject[2];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //EnemyのTagが残っているかどうかの判定
        //０になったらシーンを移動させる、移動させる前に処理を入れる
        GameObject PlayerObj = GameObject.FindGameObjectWithTag("Player");
        GameObject EnemyObj = GameObject.FindGameObjectWithTag("Enemy");
        if (EnemyObj == null)
        {
            //ここで勝利の処理
            WinImage.SetActive(true);
            Invoke("ButtonActive", 2f);
        }
        if (PlayerObj == null)
        {
            //ここでゲームオーバー処理いれましょねー
            LoseImage.SetActive(true);
            Invoke("ButtonActive", 2f);
        }
    }
    void ButtonActive()
    {
        //ボタンのActiveを変える
        button[0].SetActive(true);
        button[1].SetActive(true);
    }
}
