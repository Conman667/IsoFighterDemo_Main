using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pIsoController : MonoBehaviour
{

    public gameController controller;
    public static bool isobool = false;

    public float speed = 5f;
    public float jump = 10f;
    public float groundD = 1.9f;
    public LayerMask groundLayer;

    private bool isMoving;

    private Vector3 positionInit = new Vector3 (-21.57f,11.81f,-82.39f);
    private Vector3 directionUp = new Vector3 (4.68f, 0f,0f);
    private Vector3 directionDown = new Vector3(-4.68f, 0f,0f);
    private Vector3 directionLeft = new Vector3(0f,0f, -4.68f);
    private Vector3 directionRight = new Vector3(0f,0f, 4.68f);

    private Vector3 posOld;
    private Vector3 posNew;

    public float extraGrav = 9.8f;

    public float timeToMove = 0.15f;

    //4.68

    //private static float[,,] positions = new float[,,] {{{-21.57f,11.81f,-82.39},{-21.57f,11.81f,-87.07f}}}

    Rigidbody myRB;

    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();

        //isobool = controller.iso;
        
        transform.position = positionInit;

    }

    

    // Update is called once per frame
    void Update()
    {

        bool IsGround(){
            return Physics.Raycast(transform.position, Vector3.down, out hit, groundD, groundLayer);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.x < -21.57f && controller.iso && !isMoving && IsGround())
        {
            StartCoroutine(MovePlayer(directionUp));

        } else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.x < -35.61f && controller.iso && !isMoving && IsGround())
        {
            StartCoroutine(MovePlayer(directionDown));

        } else if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.z < -96.43f && controller.iso && !isMoving && IsGround())
        {
            StartCoroutine(MovePlayer(directionLeft));

        } else if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.z < -82.39f && controller.iso && !isMoving && IsGround())
        {
            StartCoroutine(MovePlayer(directionRight));
        } else if (Input.GetKeyDown(KeyCode.Space) && controller.iso && !isMoving && IsGround())
        {
            myRB.AddForce( Vector3.up * jump, ForceMode.Impulse);
        }

        if (!IsGround())
        {
            Vector3 jSpeed = myRB.velocity;
            jSpeed.y -= extraGrav * Time.deltaTime;
            myRB.velocity = jSpeed;
        }

        /*

        float ratio = (float)framesElapsed / frameCount;

        transform.position = Vector3.Lerp(posOld, posNew, ratio);

        framesElapsed = (framesElapsed + 1) % (frameCount+1);

        
        bool IsGround(){
            return Physics.Raycast(transform.position, Vector3.down, out hit, groundD, groundLayer);
        }

        if (controller.iso)
        {
            move = Input.GetAxis("Horizontal");
        } else {
            move = 0.0f;
        }

        myRB.velocity = new Vector3(move * speed, myRB.velocity.y, 0);

        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGround())
        {
            myRB.AddForce( Vector3.up * jump, ForceMode.Impulse);
        }
        */
        
        

        //Debug.Log(controller.iso);
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0;

        posOld = transform.position;
        posNew = posOld + direction;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(posOld, posNew, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = posNew;

        isMoving = false;
    }
}
