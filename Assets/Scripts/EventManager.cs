using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void StartGameDelegate();
    public static StartGameDelegate onStartGame;
    public static StartGameDelegate onPlayerDeath;


    public delegate void TakeDamageDelegate(float amt);
    public static TakeDamageDelegate onTakeDamage;

    public delegate void ScorePointDelegate(int amt);
    public static ScorePointDelegate onScorePOints;


    public static void StartGame()
    {
        if (onStartGame != null)
            onStartGame();
    }


    public static void TakeDamage(float percent)
    {
        Debug.Log("take damage : " + percent);
        if (onTakeDamage != null)
            onTakeDamage(percent);
    }

    public static void PlayerDeath()
    {
        if (onPlayerDeath != null)
            onPlayerDeath();
    }

    public static void ScorePoints(int score)
    {
        if (onScorePOints != null)
            onScorePOints(score);
    }
}
