using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Tambahkan ini

public class LatihanIncrementingScore : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreUI;

    void Start()
    {
        UpdateScoreUI();
    }

    // Fungsi untuk menambah score
    public void AddScore(int amount)
    {
        score += 10;
        UpdateScoreUI();

        // Cek menang
        if (score >= 100)
        {
            SceneManager.LoadScene("Scene Menang");
        }
    }

    // Fungsi untuk mengurangi score
    public void KenaEnemy(int amount)
    {
        score -= 100;
        UpdateScoreUI();

        // Cek kalah
        if (score <= -10)
        {
            SceneManager.LoadScene("Scene Kalah");
        }
    }

    public void KurangScore(int amount)
    {
        score -= 10;
        UpdateScoreUI();
        // Cek kalah
        if (score <= -10)
        {
            SceneManager.LoadScene("Scene Kalah");
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreUI != null)
            scoreUI.text = score.ToString();
    }

    // Getter skor untuk script lain
    public int GetScore()
    {
        return score;
    }
}
