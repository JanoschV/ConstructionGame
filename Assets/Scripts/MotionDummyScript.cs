using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class MotionDummyScript : MonoBehaviour
{



    // Update is called once per frame
    Rigidbody _playerRigidBody;


    public float JumpForce;
    public bool Midjump = false;
    public float Speed = 2f;
    public float fallMultiplier = 2.5f;
    public float lowjumpMultiplier = 2f;
    private float startTime;
    private float endTime;
    public List<GameObject> _constructors = new List<GameObject>(5);
    public float offset;
    private float side;
    Animator anim;
    

    void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody>();
        anim = this.gameObject.GetComponent<Animator>();
        _playerRigidBody.freezeRotation = true;
    }

    void Update()
    {

        if (Input.GetKeyDown("space") && !Midjump)
        {
            Debug.Log(_playerRigidBody.velocity.y);
            _playerRigidBody.velocity = Vector3.up * JumpForce;
            Midjump = true;
            anim.SetBool("isJumping", true);
            anim.SetFloat("jumpTime", 5);
        }
        if (Input.GetKeyUp("space"))
        {
            anim.SetBool("isJumping", false);
        }

        if (_playerRigidBody.velocity.y < 0)
        {
            _playerRigidBody.velocity += Vector3.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        else if (_playerRigidBody.velocity.y > 0 && !Input.GetKey("space"))
        {
            _playerRigidBody.velocity += Vector3.up * Physics2D.gravity.y * (lowjumpMultiplier - 1) * Time.deltaTime;
        }

        if (Input.GetKey("a"))
        {
            MoveCharacter(Vector3.left);
            side = -1;
            playerRotate(new Vector3(-90, 0, 0));
            anim.SetBool("isRunning", true);
        }

        if(Input.GetKeyUp("a"))
        {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetKey("d"))
        {
            MoveCharacter(Vector3.right);
            side = 1;
            playerRotate(new Vector3(90,0, 0));
            anim.SetBool("isRunning", true);
        }  

        if(Input.GetKeyUp("d"))
        {
            anim.SetBool("isRunning", false);  
        }

            if (Input.GetKeyDown("down"))
            {
                startTime = Time.time;
            }

            if (Input.GetKeyUp("down"))
            {
                endTime = Time.time - startTime;

                if (endTime <= 0.5)
                {
                    BeamGenerator(_constructors[0], offset/2, side, 1);
                }

                else if (endTime > 0.5)
                {
                    BeamGenerator(_constructors[1], offset/2, side, 1);
                }
            }

            if (Input.GetKeyDown("right"))
            {
                startTime = Time.time;
            }

            if (Input.GetKeyUp("right"))
            {
                endTime = Time.time - startTime;

                if (endTime <= 0.5)
                {
                    BeamGenerator(_constructors[2], offset, 1, 4);
                }

                else if (endTime > 0.5)
                {
                    BeamGenerator(_constructors[3], offset+3, 1, 4);
                }
            }

            if (Input.GetKeyDown("left"))
            {
                startTime = Time.time;
            }

            if (Input.GetKeyUp("left"))
            {
                endTime = Time.time - startTime;

                if (endTime <= 0.5)
                {
                    BeamGenerator(_constructors[2], offset, -1f, 4f);
                }

                else if (endTime > 0.5 && endTime < 1)
                {
                    BeamGenerator(_constructors[3], offset+3, -1f, 4f);
                }
            }

      

        void MoveCharacter(Vector3 direction)
        {
            this.transform.position += direction * Speed * Time.deltaTime;
        }

        void BeamGenerator(GameObject gameObject, float beamoffset, float side, float height)
        {
            Instantiate(gameObject, this.transform.position + new Vector3
                (beamoffset * side, height, 0), Quaternion.identity);
        }

        void playerRotate(Vector3 _playerRotation)
        {
            transform.rotation = Quaternion.LookRotation(_playerRotation);

        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Ground" || other.collider.tag == "Beam")
        {
            Midjump = false;
            anim.SetBool("MidJump", false);
        }

        if (other.collider.tag == "Prize")
        {
            SceneManager.LoadScene(4);
        }

        if(other.collider.tag == "DeadZone")
        {
            SceneManager.LoadScene(3);
        }
    }
}