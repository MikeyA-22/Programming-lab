using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour, IDataPersistence
{
    public float moveSpeed;
    
    public float jumpForce;

    private new Transform transform;

    private new Rigidbody rigidbody;
    public int health = GlobalInstance.Instance.Health;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();

        GlobalInstance.Instance.currenthealth(health);
        
        
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


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(5);
        }
    }

    private void TakeDamage(int damage)
    {

        health -= damage;


        GlobalInstance.Instance.currenthealth(health);

        Debug.Log(health);
    }

    //game data
    public void  SaveData(ref GameData data)
    {

        data.playerPosition = transform.position;
    }

    public void LoadData(GameData data)
    {
        transform.position = data.playerPosition;
    }

}
