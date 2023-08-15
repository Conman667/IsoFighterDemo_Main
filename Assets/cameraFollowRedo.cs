using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class cameraFollowRedo : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    float time = 0.3f;
    float elapsedTime = 0.0f;

    Vector3 posOld;
    Vector3 posNew;

    float yPos;
    float zPos;

    public float offset = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        posOld = new Vector3(player.transform.position.x + (enemy.transform.position.x - player.transform.position.x)/2, 2f, -35f);
        transform.position = posOld;
    }

    // Update is called once per frame
    void Update()
    {
        if (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(posOld, posNew, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            
        } else
        {
            elapsedTime = 0.0f;
            Center();
        }

        
    }

    void Center()
    {
        if (player.transform.position.y > 2f || enemy.transform.position.y > 2f)
        {
            yPos = player.transform.position.y + (enemy.transform.position.y - player.transform.position.y)/2f;
        } else
        {
            yPos = 2f;
        }

        if (Math.Abs(enemy.transform.position.x - player.transform.position.x) > 10)
        {
            zPos = -35f + (Math.Abs(enemy.transform.position.x - player.transform.position.x) * offset);
        }
        else
        {
            zPos = -35f;
        }
        posNew = new Vector3(player.transform.position.x + (enemy.transform.position.x - player.transform.position.x) / 2, yPos, zPos);
        posOld = transform.position;
    }
}
