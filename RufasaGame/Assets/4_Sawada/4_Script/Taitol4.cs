using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Taitol4 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ゲーム画面に移動する
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Main");
        }
    }
}
