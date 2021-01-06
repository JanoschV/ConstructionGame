using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamScript : MonoBehaviour
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

            new WaitForSeconds(5);
            rb.isKinematic = false;
            rb.useGravity = true;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Scaffold")
        {
            onGround = true;
        }

        if(col.collider.tag=="DeathZone")
        {
            Destroy(this.gameObject);
        }
    }
}