using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    [SerializeField]TMP_Text scoreText;
    [SerializeField] TMP_Text hiscoreText;
    [SerializeField] int score;
    [SerializeField] int hiScore;

    private void Start()
    {
        LoadHiScore();
    }
    private void OnEnable()
    {
        EventManager.onStartGame += ResetScore;
        EventManager.onPlayerDeath += CheckNewHiScore;
        EventManager.onScorePOints += AddScore;
    }

    private void OnDisable()
    {
        EventManager.onStartGame -= ResetScore;
        EventManager.onPlayerDeath -= CheckNewHiScore;
        EventManager.onScorePOints -= AddScore;
    }

    void AddScore(int amt)
    {
        score += amt;
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

    void LoadHiScore()
    {
        hiScore = PlayerPrefs.GetInt("HighScore", 0);
        displayHiScore();
    }
     void CheckNewHiScore()
    {
        if (score > hiScore) { 
            PlayerPrefs.SetInt("HighScore", score);
            displayHiScore();   
        }

    }
    void displayHiScore()
    {
        hiscoreText.text = hiScore.ToString();
    }
}
