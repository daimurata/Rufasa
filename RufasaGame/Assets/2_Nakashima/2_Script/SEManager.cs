using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    //SEを入れていく
    public AudioClip[] SE = new AudioClip[3];
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void SEcall(int SENum)
    {
        //配列にあった数字を入れればその音が出る
        audioSource.PlayOneShot(SE[SENum]);
        Debug.Log(SE[SENum]);
    }
}
