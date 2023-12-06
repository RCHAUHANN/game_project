using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text   timer;
    [SerializeField] float timepassed;
    bool keepTime = false;

    private void Update()
    {
        if (keepTime)
        timepassed += Time.deltaTime;
        updateTimerDisplay();
    }

    private void OnEnable()
    {
        EventManager.onStartGame += StartTimer;
        EventManager.onPlayerDeath += StopTimer;
    }
    private void OnDisable()
    {
        EventManager.onStartGame -= StartTimer;
        EventManager.onPlayerDeath -= StopTimer;
    }

    void StartTimer()
    {
        timepassed = 0;
        keepTime = true;
    }
    void StopTimer()
    {
        keepTime = false;
    }
    void updateTimerDisplay()
    {
        int mins;
        float secs;
        mins = Mathf.FloorToInt( timepassed / 60);
        secs = timepassed % 60;
        timer.text = string.Format("{0}:{1:00}",mins,secs);
    }
}
