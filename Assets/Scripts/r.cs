using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class r : MonoBehaviour
{
    public static r Instance;
    [SerializeField] private Cell CellPrefab;
    [SerializeField] private Player PlayerPrefab;
    [SerializeField] private Enemy EnemyPrefab;
    private Grid grid;
    private Player player;

    public Cell start;
    public Cell end;

    private void Awake()
    {
        Instance = this;
    }

    //Crear grid
    private void Start()
    {
        grid = new Grid(PlayerPrefs.GetInt("nxn"), PlayerPrefs.GetInt("nxn"), 1, CellPrefab);

        foreach (Cell node in grid.getArray())
        {
            if (node.isStart)
            {
                start = node;
                int x = node.x;
                int y = node.y;
                player = Instantiate(PlayerPrefab, new Vector2(x, y), Quaternion.identity);
            }
            if (node.isEnemySpawn)
            {
                int x = node.x;
                int y = node.y;
                Instantiate(EnemyPrefab, new Vector2(x, y), Quaternion.identity);
            }
            if (node.isEnd)
            {
                end = node;
            }
        }

        int i = 0;

        while(i< PlayerPrefs.GetInt("m"))
        {
            int random = Random.Range(0, PlayerPrefs.GetInt("nxn") * PlayerPrefs.GetInt("nxn") - 1);
            Cell node = grid.getArray()[random / PlayerPrefs.GetInt("nxn"), random % PlayerPrefs.GetInt("nxn")];
                if (node.isEnd == false && node.isStart == false && node.isEnemySpawn == false && node.isWalkable == true)
                {
                    node.SetWalkable(false);
                    node.SetColor(Color.black);
                    i++;
                }
            
        }
    }

    //Funcion para moverse

    public void MoveCell(int x, int y)
    {
        List<Cell> path = PathManager.Instance.FindPath(grid, (int)player.GetPosition.x, (int)player.GetPosition.y, x, y);

        player.SetPath(path);
    }

    public void MoveEnemy(Enemy enemy, int x, int y)
    {
        List<Cell> path = PathManager.Instance.FindPathEnemy(enemy, grid, x, y, (int)player.GetPosition.x, (int)player.GetPosition.y);

        enemy.SetPath(path);
    }

}
