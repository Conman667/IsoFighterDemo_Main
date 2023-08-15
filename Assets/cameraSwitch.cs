using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSwitch : MonoBehaviour
{

    public GameObject Camera;
    public GameObject isoCamera;

    public gameController cameraController;

    // Start is called before the first frame update
    void Start()
    {
        //private bool x = GetComponent<gameController>().iso;
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraController.iso == false)
        {
            Camera.SetActive(true);
            isoCamera.SetActive(false);
        } else {
            Camera.SetActive(false);
            isoCamera.SetActive(true);
        }
    }
}
