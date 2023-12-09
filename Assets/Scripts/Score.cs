using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Score : MonoBehaviour
{
    [SerializeField]TMP_Text scoreText;
    
    [SerializeField] int score;
    [SerializeField] int ScoreToWin =500;

    private void Start()
    {
        
    }
    private void OnEnable()
    {
        EventManager.onStartGame += ResetScore;
        
        EventManager.onScorePOints += AddScore;
    }

    private void OnDisable()
    {
        EventManager.onStartGame -= ResetScore;
        
        EventManager.onScorePOints -= AddScore;
    }

    void AddScore(int amt)
    {
        score += amt;
        DisplayScore();

        if(score >= ScoreToWin)
        {
            LoadNextLevel();
        }

    }

    void ResetScore()
    {
        score = 0;
        DisplayScore();
    }

    void DisplayScore()
    {
        scoreText.text = score.ToString();
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene("Level2");
    }
  
}
