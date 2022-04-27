using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI levelNumber;
    //public TextMeshProUGUI timerText;
    public TextMeshProUGUI highLevel;
    public TextMeshProUGUI bestTime;

    // Start is called before the first frame update
    void Start()
    {
        levelNumber.text= "LEVEL " + PlayerPrefs.GetInt("stage");
        highLevel.text = "Highest Level: " + PlayerPrefs.GetInt("highLevel");
        bestTime.text = "Best Time: " + PlayerPrefs.GetString("bestTime");
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateLevel();
        //UpdateTimer();
    }

    void UpdateLevel()
    {
        levelNumber.text = "LEVEL " + PlayerPrefs.GetInt("stage");
    }

    void UpdateTimer()
    {

    }
}
