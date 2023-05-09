using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Controller : MonoBehaviour
{
    public float speed;
    public float jump;
    public bool isGrounded;
    private Rigidbody rb;
    
    public Transform target;
    public Text text;

    
    public Text text2;


    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = false;
        
    }
    
    void Update ()
    {
        if (isGrounded == true && Input.GetKeyUp (KeyCode.Space)) {
            rb.AddForce(new Vector3(0.0f, jump, 0.0f));
        }

        text.text = "Position: " + target.position.ToString();
        

    }
    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical); 

        rb.AddForce (movement * speed);

        var vel = rb.velocity;  
        float moveSpeed = vel.magnitude;  

        text2.text = "Speed: " + moveSpeed.ToString("0.00");



    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "ground") {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision) {
        if (collision.gameObject.name == "ground") {
            isGrounded = false;
        }
    }

    
}
