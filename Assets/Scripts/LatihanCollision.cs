using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatihanCollision : MonoBehaviour
{
    public GameObject jumpscareImage; 
    public AudioSource jumpscareAudio;
    public AudioSource coinAudio;
    public AudioSource obstacleAudio;
    public AudioSource enemyAudio;
    public LatihanIncrementingScore scoreManager;

    void Start()
    {
        if (jumpscareImage != null)
            jumpscareImage.SetActive(false); 

        if (scoreManager == null)
            scoreManager = FindObjectOfType<LatihanIncrementingScore>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Secret"))
        {
            Debug.Log("Kamu masuk collison secret");
            if (jumpscareImage != null)
                jumpscareImage.SetActive(true);
            if (jumpscareAudio != null)
                jumpscareAudio.Play();
        }
        else if (other.gameObject.CompareTag("Coin"))
        {
            Debug.Log("Koin diambil!");
            if (scoreManager != null)
                scoreManager.AddScore(10);
            if (coinAudio != null)
                coinAudio.Play();
            Destroy(other.gameObject); 
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Kena musuh! Score berkurang 100.");
            if (enemyAudio != null)
                enemyAudio.Play();
            if (scoreManager != null)
                scoreManager.KenaEnemy(-100); 

            Destroy(other.gameObject); 
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Kena obstacle! Score berkurang 10.");
            if (scoreManager != null)
                scoreManager.KurangScore(-10);
            if (obstacleAudio != null)
                obstacleAudio.Play();
            Destroy(other.gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Secret"))
        {
            Debug.Log("Kamu tetap di collison musuh");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Secret"))
        {
            Debug.Log("Kamu keluar collison Secret");
            if (jumpscareImage != null)
                jumpscareImage.SetActive(false);
        }
    }
}
