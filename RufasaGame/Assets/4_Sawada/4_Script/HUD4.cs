using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUD4 : MonoBehaviour
{
    public GameObject GameoverText;
    //hpゲージ
    public Image hpGauge;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
 private   void Update()
    {
        //プレイヤーを取得
        var play = Player4.instance;
        //HPのゲージを更新
        var m_hp = play.hp;
        var m_hpmax = play.hpmax;
        hpGauge.fillAmount = (float)m_hp / m_hpmax;
        //hpが0になったらゲームオーバーを表示する
        GameoverText.SetActive(!play.gameObject.activeSelf);
    }
}
