using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ref: https://drive.google.com/file/d/1WiF2LwM-6WvEnas9vw32YrYPly9K0Qrv/view

public class Player : MonoBehaviour
{
    public static Player Instance;
    public KeyCode up;
    public KeyCode left;
    public KeyCode right;
    public KeyCode down;
    List<Cell> path;
    [SerializeField]

    public Vector2 GetPosition => transform.position;

    public Cell currentCell;
    public int currentCellX;
    public int currentCellY;

    // Index of current waypoint from which Enemy walks
    // to the next one
    private int waypointIndex = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Timer.Instance.startTimer();

        foreach (Cell node in Grid.Instance.getArray())
        {
            if (node.isStart)
            {
                int x = node.x;
                int y = node.y;
                currentCell = Grid.Instance.getArray()[x, y];
                currentCellX = currentCell.x;
                currentCellY = currentCell.y;
            }
        }
        if(PathManager.Instance.FindPath(Grid.Instance, currentCellX, currentCellY, r.Instance.end.x, r.Instance.end.y) != null)
        {
            
        }
        else
        {
            SceneManager.UnloadSceneAsync("SampleScene");
            SceneManager.LoadScene("SampleScene");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(up))
        {
            r.Instance.MoveCell(currentCellX, currentCellY+1);
        }
        if (Input.GetKeyDown(down))
        {
            r.Instance.MoveCell(currentCellX, currentCellY - 1);
        }
        if (Input.GetKeyDown(left))
        {
            r.Instance.MoveCell(currentCellX - 1, currentCellY);
        }
        if (Input.GetKeyDown(right))
        {
            r.Instance.MoveCell(currentCellX + 1, currentCellY);
        }
        Move();
        VerifyEnd();
    }

    public void SetPath(List<Cell> path)
    {
        //ResetPosition();
        waypointIndex = 0;
        this.path = path;
    }

    public void VerifyEnd()
    {
        if (this.transform.position == r.Instance.end.transform.position)
        {
            int i = PlayerPrefs.GetInt("stage");
            if(i == 4)
            {
                if(PlayerPrefs.GetFloat("bestTimeFloat") == 0)
                {
                    PlayerPrefs.SetFloat("bestTimeFloat", Timer.Instance.timePassed);
                    PlayerPrefs.SetString("bestTime", Timer.Instance.timerText.text);
                }
                if(Timer.Instance.timePassed < PlayerPrefs.GetFloat("bestTimeFloat"))
                {
                    PlayerPrefs.SetFloat("bestTimeFloat", Timer.Instance.timePassed);
                    PlayerPrefs.SetString("bestTime", Timer.Instance.timerText.text);
                }
                PlayerPrefs.SetInt("winner", 1);
                PlayerPrefs.SetInt("highLevel", 4);
                SceneManager.LoadScene("StartScene");
            }
            else
            {
                PlayerPrefs.SetFloat("totalTime", Timer.Instance.timePassed);
                PlayerPrefs.SetString("timer", Timer.Instance.timerText.text);
                PlayerPrefs.SetInt("stage", i + 1);
                SceneManager.UnloadSceneAsync("SampleScene");
                SceneManager.LoadScene("SampleScene");
            }
            
        }
    }

    private void Move()
    {
        // If player didn't reach last waypoint it can move
        // If player reached last waypoint then it stops
        if (path == null)
        {
            return;
        }
            

        if (waypointIndex <= path.Count - 1)
        {
            // Move player from current waypoint to the next one
            // using MoveTowards method
            transform.position = path[waypointIndex].transform.position;

            // If player reaches position of waypoint he walked towards
            // then waypointIndex is increased by 1
            // and player starts to walk to the next waypoint
            if (transform.position == path[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
    }
}
