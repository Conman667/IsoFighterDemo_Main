using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bossStates
{

    public static bool iso;

    // Start is called before the first frame update
    void Start()
    {
        iso = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && iso == false)
        {
            Debug.Log("hit!");
            iso = true;
        } else if (Input.GetKeyDown(KeyCode.UpArrow) && iso == true)
        {
            Debug.Log("hit!");
            iso = false;
        }
    }
}
