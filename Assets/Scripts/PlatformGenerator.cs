using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlatformGenerator : MonoBehaviour
{
    float nextTime = 0;
    public float interval = 1;
    public Rigidbody Platform;
    public Rigidbody LeftBarrier;
    public Rigidbody RightBarrier;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            int randX = UnityEngine.Random.Range
            (Convert.ToInt32(LeftBarrier.position.x+29), (Convert.ToInt32(RightBarrier.position.x-29)));
            int randY = UnityEngine.Random.Range(10, 35);
            Instantiate(Platform, new Vector3(randX, randY, 0),Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    
        if (Time.time >= nextTime)
        {
            //do something here every interval seconds
            InstantiatePiece();
            nextTime += interval;
        }
    }
       
    void InstantiatePiece()
    {
        int rand = UnityEngine.Random.Range(-10,14);

        Instantiate(Platform, new Vector3(rand, 50, 0), Quaternion.identity);
        Debug.Log(rand);
    }
}
