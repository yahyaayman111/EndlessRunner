
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMovement : MonoBehaviour
{
    public float JumpForce = 5f;
    public float playerSpeed = 2f;
    public float horizontalSpeed = 3f;
    public float leftLimit = -5.5f;
    public float rightLimit = 5.5f;

    private Rigidbody rb;
    private bool isGrounded = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = 0f;

      
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = -1f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput = 1f;
        }

        
        Vector3 move = new Vector3(horizontalInput * horizontalSpeed, 0f, playerSpeed) * Time.deltaTime;
        transform.Translate(move, Space.World);

       
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, leftLimit, rightLimit);
        transform.position = pos;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Vector3 jumpDirection =(Vector3.up * JumpForce)+(Vector3.forward *JumpForce);
            rb.AddForce(jumpDirection, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

}


