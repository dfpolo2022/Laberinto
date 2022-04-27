using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;
    [SerializeField] private Cell CellPrefab;
    [SerializeField] private Player PlayerPrefab;
    [SerializeField] private Enemy EnemyPrefab;
    private Grid grid;
    private Player player;
    public int n;

    private void Awake()
    {
        Instance = this;
    }

    //Crear grid
    private void Start()
    {
        grid = new Grid(n, n, 1, CellPrefab);

        foreach (Cell node in grid.getArray())
        {
            if (node.isStart)
            {
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
        }
    }

    //Funcion para moverse

    public void MoveCell(int x, int y)
    {
        List<Cell> path = PathManager.Instance.FindPath(grid, (int)player.GetPosition.x, (int)player.GetPosition.y, x, y);

        //Debug.Log("" + path.Count);

        player.SetPath(path);
    }

    public void MoveEnemy(Enemy enemy, int x, int y)
    {
        List<Cell> path = PathManager.Instance.FindPath(grid, (int)player.GetPosition.x, (int)player.GetPosition.y, x, y);

        //List<Cell> path2 = PathManager.Instance.FindPathEnemy(enemy, grid, x, y, (int)player.GetPosition.x, (int)player.GetPosition.y);

        Debug.Log("" + path.Count);

        enemy.SetPath(path);
    }

}
