using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float moveSpeed;

    public float jumpForce;


    private new Rigidbody rigidbody;


    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        
    }


    void Update()
    {
       Move();
       Jump();
    }


    void Move()
    {
        //get our inputs
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(xInput, 0, zInput) *moveSpeed;
        rigidbody.velocity = dir;

        dir.y = rigidbody.velocity.y;


        Vector3 facingDir = new Vector3(xInput, 0, zInput);
        if (facingDir.magnitude > 0)
        {
            transform.forward = facingDir;
        }
    }


    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            checkJumpForce();
        }
    }


    void checkJumpForce()
    {
        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 

    }
}
