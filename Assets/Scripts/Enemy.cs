using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public static Enemy Instance;
    List<Cell> path;
    [SerializeField]


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
        InvokeRepeating("HolaFunction", 2, (float)2);
    }

    // Update is called once per frame
    void Update()
    {
        //BoardManager.Instance.MoveEnemy(this, Player.Instance.currentCellX, Player.Instance.currentCellY);
        EnemyMove();
    }

    void HolaFunction()
    {
        Debug.Log("Hola");
        BoardManager.Instance.MoveEnemy(this, Player.Instance.currentCellX, Player.Instance.currentCellY);
    }

    public void SetPath(List<Cell> path)
    {
        //ResetPosition();
        waypointIndex = 0;
        this.path = path;
    }

    void EnemyMove()
    {
        if (path == null)
        {
            return;
        }

        /*if (path[1] == Grid.Instance.getArray()[path[0].x, path[0].y + 1])
        {
            BoardManager.Instance.MoveEnemy(this, currentCellX, currentCellY + 1);
        }

        if (path[1] == Grid.Instance.getArray()[path[0].x, path[0].y - 1])
        {
            BoardManager.Instance.MoveEnemy(this, currentCellX, currentCellY - 1);
        }

        if (path[1] == Grid.Instance.getArray()[path[0].x + 1, path[0].y])
        {
            BoardManager.Instance.MoveEnemy(this, currentCellX + 1, currentCellY);
        }

        if (path[1] == Grid.Instance.getArray()[path[0].x - 1, path[0].y])
        {
            BoardManager.Instance.MoveEnemy(this, currentCellX - 1, currentCellY);
        }*/

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

        //Debug.Log("" + path.Count);

    }
}
