using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GroundScript : MonoBehaviour
{
    public float FallSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0,-FallSpeed * Time.deltaTime,0);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "DeathZone")
        {
            Destroy(this.gameObject);
        }
    }

}
