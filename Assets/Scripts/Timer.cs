using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public static Timer Instance;
    public TextMeshProUGUI timerText;
    public bool timerActive;

    public float timePassed;
    private TimeSpan timerTime;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = PlayerPrefs.GetString("timer");
        timerActive = false;
    }

    public void startTimer()
    {
        timerActive = true;
        timePassed = 0F;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        timePassed = PlayerPrefs.GetFloat("totalTime");
        while (timerActive)
        {
            timePassed += Time.deltaTime;
            timerTime = TimeSpan.FromSeconds(timePassed);
            string cronometerText = timerTime.ToString("mm':'ss':'ff");
            timerText.text = cronometerText;
            yield return null;
        }
    }
}
