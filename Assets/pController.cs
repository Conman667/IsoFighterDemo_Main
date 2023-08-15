using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pController : MonoBehaviour
{

    public gameController controller;
    public static bool isobool = false;

    public float speed = 5f;
    public float jump = 5f;
    public float groundD = 1.9f;
    public LayerMask groundLayer;
    private float move = 0.0f;

    public float extraGrav = 9.8f;

    Rigidbody myRB;

    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();

        //isobool = controller.iso;
        

    }

    

    // Update is called once per frame
    void Update()
    {

        bool IsGround(){
            return Physics.Raycast(transform.position, Vector3.down, out hit, groundD, groundLayer);
        }

        if (!controller.iso)
        {
            move = Input.GetAxis("Horizontal");
        } else {
            move = 0.0f;
        }

        myRB.velocity = new Vector3(move * speed, myRB.velocity.y, 0);

        if (Input.GetKeyDown(KeyCode.Space) && IsGround())
        {
            myRB.AddForce( Vector3.up * jump, ForceMode.Impulse);
        }

        if (!IsGround())
        {
            Vector3 jSpeed = myRB.velocity;
            jSpeed.y -= extraGrav * Time.deltaTime;
            myRB.velocity = jSpeed;
        }
        
        

        //Debug.Log(controller.iso);
    }
}
