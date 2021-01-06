using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaffoldScript : MonoBehaviour
{ 
    Rigidbody rb;
    private bool onGround;
    public float FallSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onGround)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
            this.transform.position += new Vector3(0, -FallSpeed * Time.deltaTime, 0);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Ground" || col.collider.tag == "Beam" )
        {
            onGround = true;
        }

        if (col.collider.tag =="DeadZone")
        {
            Destroy(this.gameObject);
        }
        
    }
}
