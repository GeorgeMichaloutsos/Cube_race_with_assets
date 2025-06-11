using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public int forwardForce = 2000;
    public int sideForce = 500;
    public int jumpforce = 300;
    private float rightBorder = 6.9f;
    private float leftBorder = -6.9f;
    private bool isGrounded = true;
    public Score score;
    private bool isGameOver = false;
    // Start is called before the first frame update

    public Animator anim; // ftiaxnw metavliti gia na kserei poion animator tha xrisimopoihsei
    private string jumpanim = "onJump"; // poia parametro tha allazw
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true)
        {
            return;
        }

        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("a") && transform.position.x > leftBorder)
        {
            rb.AddForce(-sideForce * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyDown("space") && isGrounded == true)
        {
            rb.AddForce(0, jumpforce, 0);
            anim.SetBool(jumpanim, true);
        }

        if (Input.GetKey("d") && transform.position.x < rightBorder)
        {
            rb.AddForce(sideForce * Time.deltaTime, 0, 0);

            if (transform.position.x < leftBorder)
            {
                rb.position = new Vector3(leftBorder, rb.position.y, rb.position.z);
                rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
            }
            else if (transform.position.y > rightBorder)
            {
                rb.position = new Vector3(rightBorder, rb.position.y, rb.position.z);
                rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
            }
        }
               
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacles")
        {
                score.GameOver();
                isGameOver = true;
        }

    }
    void OnCollisionStay(Collision collision) 
        {
            if (collision.gameObject.name == "Ground")
            {
                isGrounded = true;
            anim.SetBool(jumpanim, false);
        }
                          
        }

        void OnCollisionExit(Collision collision) 
        {
            if (collision.gameObject.name == "Ground")
            {
                isGrounded = false;
            }
        }


    
}
