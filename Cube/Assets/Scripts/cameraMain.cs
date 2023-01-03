using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMain : MonoBehaviour
{
    // Start is called before the first frame update
    Animator an;
    void Start()
    {
        an = GetComponent<Animator>();/*
        an.SetInteger("status", 1);*/
    }

    // Update is called once per frame
    void Update()
    {

    }
   /* public void btn_start()
    {
        *//*float timeExchange = 1;*/

        /*timeExchange -= 0.01f;*/
        /*        if (timeExchange <= 0)
                {
                    an.SetInteger("status", 2);

                }*//*
        an.SetInteger("status", 1);
        Debug.Log("clicked");
    }*/
}
