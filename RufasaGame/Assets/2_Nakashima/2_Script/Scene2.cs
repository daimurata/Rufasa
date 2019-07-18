using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene2 : MonoBehaviour
{
    //シーンの名前を入れる
    public string Name;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //クリックしたらー
        if (Input.GetMouseButtonDown(0))
        {
            //移動させまーす
            SceneManager.LoadScene(Name);
        }
    }
}
