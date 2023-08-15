using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpecial : MonoBehaviour
{
    public gameController controller;
    public GameObject lazer;
    public GameObject marker;


    float timer;
    float delayEffect = 0.3f;

    public GameObject zoom;

    private float[] xPos = new float[] { -21.57f, -26.25f, -30.93f, -35.61f };
    private float[] zPos = new float[] { -82.39f, -87.07f, -91.75f, -96.43f };


    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpecialMove", 1.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            for (int i = 0; i < 9; i++)
            {
                timer += Time.deltaTime;
                if(timer > delayEffect)
                {
                    StartCoroutine(IsoPlace(marker, lazer, zPos, xPos));
                }
                
                //new WaitForSeconds(0.3f);
            }
            timer = 0f;
            //new WaitForSeconds(0.3f);
            //controller.iso = false;
        }
    }

    void SpecialMove()
    {
        zoom.SetActive(true);

        timer += Time.deltaTime;
        if (timer > delayEffect)
        {
            controller.iso = true;

            for(int i = 0; i < 9; i++) 
            {
                StartCoroutine(IsoPlace(marker,lazer,zPos, xPos));
            }

            zoom.SetActive(false);
            controller.iso = false;
        }
    }

    void Shoot()
    {
        int x = Random.Range(1, 4);
        int z = Random.Range(1, 4);
        //Vector3 hitPos = new Vector3(xPos[x], 10.11f, zPos[z]);
        Instantiate(marker, new Vector3(xPos[x], 10.11f, zPos[z]), Quaternion.identity);


    }

    private IEnumerator IsoPlace(GameObject ob1, GameObject ob2, float[] zp, float[] xp)
    {

        int x = Random.Range(0, 4);
        int z = Random.Range(0, 4);

        Vector3 hitPos = new Vector3(xp[x], 10.11f, zp[z]);

        float tm = 0.0f;
        float dl = 0.3f;

        GameObject clone = (GameObject)Instantiate(ob1, hitPos, Quaternion.identity);
        Destroy(clone, 0.3f);

        //tm += Time.deltaTime;

        //if(tm > dl) 
        //{ 
        new WaitForSecondsRealtime(0.3f);
            GameObject clone2 = (GameObject)Instantiate(ob2);
            Destroy(clone2, 0.5f);
        
        //}

        yield return null;
    }
}
