using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKotak : MonoBehaviour
{
    public float moveSpeed = 5f;      
    public float jumpForce = 5f;      
    public AudioClip jumpClip;        
    public float rotateSpeed = 100f;  

    private Rigidbody rb;
    private AudioSource audioSource;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Gerak WASD
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = (transform.right * moveX + transform.forward * moveZ) * moveSpeed * Time.deltaTime;
        transform.Translate(move, Space.World);

        // Rotasi ke kiri (Q) dan kanan (E)
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0f, -rotateSpeed * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
        }

        // Lompat jika tekan Space dan sedang di tanah
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;

            if (audioSource != null && jumpClip != null)
                audioSource.PlayOneShot(jumpClip);
        }
    }

    // Deteksi player menyentuh tanah
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
