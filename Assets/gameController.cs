using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gameController : MonoBehaviour
{
    public bool iso;
    public GameObject animation;

    // Start is called before the first frame update
    void Start()
    {
        iso = false;
        animation.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote) && iso == false)
        {
            Debug.Log("hit!");
            iso = true;
        } else if (Input.GetKeyDown(KeyCode.BackQuote) && iso == true)
        {
            Debug.Log("hit!");
            iso = false;
        }
    }

    void bossState()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote) && iso == false)
        {
            Debug.Log("hit!");
            iso = true;
        } else if (Input.GetKeyDown(KeyCode.BackQuote) && iso == true)
        {
            Debug.Log("hit!");
            iso = false;
        }
    }
}
