using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AAA_Test : MonoBehaviour
{

    public Vector2 Pos;

    public float[] P;

    public bool Change;
    void Start()
    {
        
    }

    
    void Update()
    {
        // Mov();
        Pos=transform.position;

        if (Change==false)
        {
                Pos.y += 1.0f * Time.deltaTime;
                transform.position = Pos;
                if (2 <= Pos.y)
                {
                    Change = true;
                }
        }

        if (Change==true)
        {
                Pos.y -= 1.0f * Time.deltaTime;
                transform.position = Pos;
                if (-2 >= Pos.y)
                {
                    Change = false;
                }
        }


    }

    void Mov()
    {
        Pos = transform.position;

        if (Change==true)
        {
            if (P[0] <= Pos.y)//&&Change==true)
            {
                // Pos = transform.position;
                Pos.y -= 1 * Time.deltaTime;
                transform.position = Pos;
                if (P[1]>=Pos.y)
                {
                    Change = false;
                }

            }
        }

        if (Change==false)
        {
            if (P[1] <= Pos.y)//&&Change==false)
            {
                // Pos = transform.position;
                Pos.y += 1 * Time.deltaTime;
                transform.position = Pos;
                if (P[0]<=Pos.y)
                {
                    Change = true;
                }
                
            }
        }
       
    }
}
