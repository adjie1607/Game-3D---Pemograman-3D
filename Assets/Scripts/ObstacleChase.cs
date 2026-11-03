using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleChase : MonoBehaviour
{
    public Transform player;      // Referensi ke transform player
    public float chaseSpeed = 3f; // Kecepatan obstacle mengejar
    public float rotateSpeed = 5f; // Kecepatan rotasi obstacle

    void Start()
    {
        // Jika player belum di-assign di Inspector, cari otomatis
        if (player == null)
        {
            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Hitung arah ke player
            Vector3 direction = (player.position - transform.position).normalized;

            // Smooth movement
            Vector3 targetPosition = transform.position + direction * chaseSpeed * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, targetPosition, 0.5f);

            // Smooth rotation menghadap ke player
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
    }
}   