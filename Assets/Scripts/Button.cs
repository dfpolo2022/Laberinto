using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public string nextScene;

    // Start is called before the first frame update
    void Start()
    {
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
        ChangeScene();
    }
}
