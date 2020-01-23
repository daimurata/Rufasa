using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEtest : MonoBehaviour
{
    public GameObject SEObject;
    SEManager SEManager;
    // Start is called before the first frame update
    void Start()
    {
        SEManager = SEObject.GetComponent<SEManager>();
    }

    // Update is called once per frame
    void Update()
    {
        SEManager.SEcall(1);
    }
}
