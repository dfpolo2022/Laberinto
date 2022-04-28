using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI levelNumber;
    //public TextMeshProUGUI timerText;
    public TextMeshProUGUI highLevel;
    public TextMeshProUGUI bestTime;
    public TextMeshProUGUI winMessage;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        levelNumber.text= "LEVEL " + PlayerPrefs.GetInt("stage");
        highLevel.text = "Highest Level: " + PlayerPrefs.GetInt("highLevel");
        bestTime.text = "Best Time: " + PlayerPrefs.GetString("bestTime");
        if (PlayerPrefs.GetInt("winner") == 1)
        {
            winMessage.text = "WINNER!";
        }else if (PlayerPrefs.GetInt("winner") == 0)
        {
            winMessage.text = "";
        }
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
