using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    HitDetection hitDetection;
    Rigidbody rigidbody;

    Vector3 m_Velocity = Vector3.zero;
    [SerializeField] private float m_SmoothStep = .05f;
    [SerializeField] private float jumpForce = 2f;

    [SerializeField] private bool jump;
    [SerializeField] private float moveSpeed = 2f;

    [SerializeField] private bool grounded;

    float dir;

    private void Awake() {
        //Application.targetFrameRate = 60; 
        //QualitySettings.vSyncCount = 1;   
    }

    void Start()
    {
        Physics.gravity = new Vector3(0,-5,0);
        hitDetection = GetComponent<HitDetection>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }

    private void FixedUpdate() 
    {
        checkIfGrounded();
        handleInput();
        move(dir, false, jump);
        returnToSurface();
    }

    private void returnToSurface() 
    {
        if(grounded)
        {
            transform.position += Vector3.up * 0.01f;
        }
    }
    private void checkIfGrounded() {
        if(hitDetection.isGrounded) {
            grounded = true;
            rigidbody.velocity = new Vector3(rigidbody.velocity.x,0f,rigidbody.velocity.z);
            Physics.gravity = Vector3.zero;
        } else {
            grounded = false;
            Physics.gravity = new Vector3(0,-5f,0);
        }
    }

    private void move(float dir, bool crouch, bool jump)
    {
        Vector3 targetVelocity = new Vector3(dir*moveSpeed, rigidbody.velocity.y, rigidbody.velocity.z);

        rigidbody.velocity = Vector3.SmoothDamp(rigidbody.velocity, targetVelocity,ref m_Velocity, m_SmoothStep);

        if (jump) {
            rigidbody.AddForce(new Vector3(0,jumpForce,0));
        }
    }

    private void handleInput() 
    {
        dir = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.W)) {
            jump = true;
        } else {
            jump = false;
        }
    }
}
