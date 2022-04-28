using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public static Enemy Instance;
    List<Cell> path;
    [SerializeField]

    public KeyCode up;
    public KeyCode left;
    public KeyCode right;
    public KeyCode down;

    public Vector2 GetPosition => transform.position;

    public Cell currentCell;
    public int currentCellX;
    public int currentCellY;

    private int waypointIndex = 0;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    { 
        Cell[,] nodes = Grid.Instance.getArray();

        foreach (Cell node in Grid.Instance.getArray())
        {
            if (node.transform.position == this.transform.position)
            {
                this.currentCell = node;
                this.currentCellX = node.x;
                this.currentCellY = node.y;
            }
        }
        
        if (PathManager.Instance.FindPath(Grid.Instance, currentCellX, currentCellY, BoardManager.Instance.end.x, BoardManager.Instance.end.y) != null || PathManager.Instance.FindPath(Grid.Instance, currentCellX, currentCellY, BoardManager.Instance.start.x, BoardManager.Instance.start.y) != null)
        {

        }
        else
        {
            SceneManager.UnloadSceneAsync("SampleScene");
            SceneManager.LoadScene("SampleScene");
        }

        //InvokeRepeating("EnemyMove", 0, (float)1);
    }

    // Update is called once per frame
    void Update()
    {
        HolaFunction();
        
        if (Input.GetKeyDown(up))
        {
            StartCoroutine(Coroutine());
        }
        if (Input.GetKeyDown(down))
        {
            StartCoroutine(Coroutine());
        }
        if (Input.GetKeyDown(left))
        {
            StartCoroutine(Coroutine());
        }
        if (Input.GetKeyDown(right))
        {
            StartCoroutine(Coroutine());
        }

        UpdateCell();

        VerifyPlayer();

    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds((float)0.1);
        EnemyMove();
    }

    void HolaFunction()
    {
        BoardManager.Instance.MoveEnemy(this, currentCellX, currentCellY);
    }

    public void SetPath(List<Cell> path)
    {
        //ResetPosition();
        waypointIndex = path.Count-1;
        this.path = path;
        foreach(Cell node in path)
        {
            Debug.Log(node.ToString());
        }
    }

    public void VerifyPlayer()
    {
        if(this.transform.position == Player.Instance.transform.position)
        {
            if(PlayerPrefs.GetInt("highLevel")< PlayerPrefs.GetInt("stage"))
            {
                PlayerPrefs.SetInt("highLevel", PlayerPrefs.GetInt("stage"));
            }
            SceneManager.LoadScene("StartScene");
            
        }
    }

    public void UpdateCell()
    {
        foreach(Cell node in Grid.Instance.getArray())
        {
            if(node.transform.position == this.transform.position)
            {
                this.currentCell = node;
                this.currentCellX = node.x;
                this.currentCellY = node.y;
            }
        }
    }

    void EnemyMove()
    {
        if (path == null)
        {
            return;
        }

        if (waypointIndex <= path.Count - 1)
        {
            // Move player from current waypoint to the next one
            // using MoveTowards method
            transform.position = path[1].transform.position;

            // If player reaches position of waypoint he walked towards
            // then waypointIndex is increased by 1
            // and player starts to walk to the next waypoint
            if (transform.position == path[1].transform.position)
            {
                waypointIndex += 1;
            }
        }

        //Debug.Log("" + path.Count);

    }
}
