using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public string nextScene;
    public bool resetter;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("nxn", 10);
        PlayerPrefs.SetInt("m", 15);
        PlayerPrefs.SetFloat("totalTime", 0);
        PlayerPrefs.SetString("timer", "00:00:00");
        PlayerPrefs.SetInt("stage", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    private void OnMouseDown()
    {
        if (resetter)
        {
            PlayerPrefs.SetInt("highLevel", 0);
            PlayerPrefs.SetString("bestTime", "");
            PlayerPrefs.SetFloat("bestTimeFloat", 0);
            UIManager.Instance.highLevel.text = "Highest Level: " + PlayerPrefs.GetInt("highLevel");
            UIManager.Instance.bestTime.text = "Best Time: " + PlayerPrefs.GetString("bestTime");
        }
        else
        {
            PlayerPrefs.SetInt("winner", 0);
            ChangeScene();
        }
        
    }

    public void GetGridSize(float size)
    {
        PlayerPrefs.SetInt("nxn", (int)size);
    }

    public void GetObstacleSize(float size)
    {
        PlayerPrefs.SetInt("m", (int)size);
    }
}
