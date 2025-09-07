using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    


    [Header("---------------Run State---------------")]
    public float playerSpeed = 2;
    public float horizontalSpeed = 3;
    public float rightLimit = 5.5f;
    public float leftLimit = -5.5f;

    [Header("---------------Jump State---------------")]
    public float jumpForce = 5f;
    public float forwardForce = 3f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    public Rigidbody Rb { get; private set; }

    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime, Space.World);

        float x = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * x * horizontalSpeed * Time.deltaTime);
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, leftLimit, rightLimit);
        transform.position = pos;

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            // Add upward + forward force
            Vector3 jumpDirection = (Vector3.up * jumpForce) + (Vector3.forward * forwardForce);
            Rb.AddForce(jumpDirection, ForceMode.Impulse);
        }
    }

    public bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }

   
}
