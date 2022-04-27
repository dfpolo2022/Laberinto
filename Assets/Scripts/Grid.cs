using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Grid : ScriptableObject
{
    public static Grid Instance;
    private int width;
    private int height;
    private int cellSize;
    private Cell cellPrefab;
    private Cell[,] gridArray;
    private int[] enemySpawn;

    private void Awake()
    {
        Instance = this;
    }

    public Grid (int width, int height, int cellSize, Cell cellPrefab)
    {
        
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.cellPrefab = cellPrefab;

        generateBoard();
    }

    private void generateBoard()
    {
        Cell cell;
        gridArray = new Cell[width, height];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                var p = new Vector2(i, j) * cellSize;
                cell = Instantiate(cellPrefab, p, Quaternion.identity);
                cell.Init(this, (int)p.x, (int)p.y, true, false, false, false);
                cell.SetColor(Color.blue); 
                gridArray[i, j] = cell;
            }
        }

        int startRandom = Random.Range(0, (BoardManager.Instance.n * BoardManager.Instance.n) - 1);
        int endRandom = Random.Range(0, (BoardManager.Instance.n * BoardManager.Instance.n) - 1);

        while (endRandom == startRandom)
        {
            endRandom = Random.Range(0, (BoardManager.Instance.n * BoardManager.Instance.n) - 1);
        }
        int startX = startRandom / BoardManager.Instance.n;
        int startY = startRandom % BoardManager.Instance.n;

        int endX = endRandom / BoardManager.Instance.n;
        int endY = endRandom % BoardManager.Instance.n;

        gridArray[startX, startY].SetStart(true);
        gridArray[endX, endY].SetEnd(true);

        int enemy1, enemy2, enemy3, enemy4;

        switch (PlayerPrefs.GetInt("stage"))
        {
            case 1:
                enemy1 = Random.Range(0, (BoardManager.Instance.n * BoardManager.Instance.n) - 1);
                while(enemy1 == endRandom || enemy1 == startRandom)
                {
                    enemy1 = Random.Range(0, (BoardManager.Instance.n * BoardManager.Instance.n) - 1);
                }

                int oneX = enemy1 / BoardManager.Instance.n;
                int oneY = enemy1 % BoardManager.Instance.n;
                gridArray[oneX, oneY].SetEnemySpawn(true, 1);

                break;

            case 2:
                enemy1 = Random.Range(0, (BoardManager.Instance.n * BoardManager.Instance.n) - 1);
                while (enemy1 == endRandom || enemy1 == startRandom)
                {
                    enemy1 = Random.Range(0, (BoardManager.Instance.n * BoardManager.Instance.n) - 1);
                }
                enemy2 = Random.Range(0, (BoardManager.Instance.n * BoardManager.Instance.n) - 1);
                while (enemy2 == endRandom || enemy2 == startRandom || enemy2 == enemy1)
                {
                    enemy2 = Random.Range(0, (BoardManager.Instance.n * BoardManager.Instance.n) - 1);
                }

                oneX = enemy1 / BoardManager.Instance.n;
                oneY = enemy1 % BoardManager.Instance.n;
                gridArray[oneX, oneY].SetEnemySpawn(true, 1);

                int twoX = enemy2 / BoardManager.Instance.n;
                int twoY = enemy2 % BoardManager.Instance.n;
                gridArray[twoX, twoY].SetEnemySpawn(true, 2);

                break;

            case 3:
                enemy1 = Random.Range(0, (BoardManager.Instance.n * BoardManager.Instance.n) - 1);
                while (enemy1 == endRandom || enemy1 == startRandom)
                {
                    enemy1 = Random.Range(0, (BoardManager.Instance.n * BoardManager.Instance.n) - 1);
                }
                enemy2 = Random.Range(0, (BoardManager.Instance.n * BoardManager.Instance.n) - 1);
                while (enemy2 == endRandom || enemy2 == startRandom || enemy2 == enemy1)
                {
                    enemy2 = Random.Range(0, (BoardManager.Instance.n * BoardManager.Instance.n) - 1);
                }
                enemy3 = Random.Range(0, (BoardManager.Instance.n * BoardManager.Instance.n) - 1);
                while (enemy3 == endRandom || enemy3 == startRandom || enemy3 == enemy1 || enemy3 == enemy2)
                {
                    enemy3 = Random.Range(0, (BoardManager.Instance.n * BoardManager.Instance.n) - 1);
                }

                oneX = enemy1 / BoardManager.Instance.n;
                oneY = enemy1 % BoardManager.Instance.n;
                gridArray[oneX, oneY].SetEnemySpawn(true, 1);

                twoX = enemy2 / BoardManager.Instance.n;
                twoY = enemy2 % BoardManager.Instance.n;
                gridArray[twoX, twoY].SetEnemySpawn(true, 2);

                int threeX = enemy3 / BoardManager.Instance.n;
                int threeY = enemy3 % BoardManager.Instance.n;
                gridArray[threeX, threeY].SetEnemySpawn(true, 3);

                break;

            case 4:
                enemy1 = Random.Range(0, (BoardManager.Instance.n * BoardManager.Instance.n) - 1);
                while (enemy1 == endRandom || enemy1 == startRandom)
                {
                    enemy1 = Random.Range(0, (BoardManager.Instance.n * BoardManager.Instance.n) - 1);
                }
                enemy2 = Random.Range(0, (BoardManager.Instance.n * BoardManager.Instance.n) - 1);
                while (enemy2 == endRandom || enemy2 == startRandom || enemy2 == enemy1)
                {
                    enemy2 = Random.Range(0, (BoardManager.Instance.n * BoardManager.Instance.n) - 1);
                }
                enemy3 = Random.Range(0, (BoardManager.Instance.n * BoardManager.Instance.n) - 1);
                while (enemy3 == endRandom || enemy3 == startRandom || enemy3 == enemy1 || enemy3 == enemy2)
                {
                    enemy3 = Random.Range(0, (BoardManager.Instance.n * BoardManager.Instance.n) - 1);
                }
                enemy4 = Random.Range(0, (BoardManager.Instance.n * BoardManager.Instance.n) - 1);
                while (enemy4 == endRandom || enemy4 == startRandom || enemy4 == enemy1 || enemy4 == enemy2 || enemy4 == enemy3)
                {
                    enemy4 = Random.Range(0, (BoardManager.Instance.n * BoardManager.Instance.n) - 1);
                }

                oneX = enemy1 / BoardManager.Instance.n;
                oneY = enemy1 % BoardManager.Instance.n;
                gridArray[oneX, oneY].SetEnemySpawn(true, 1);

                twoX = enemy2 / BoardManager.Instance.n;
                twoY = enemy2 % BoardManager.Instance.n;
                gridArray[twoX, twoY].SetEnemySpawn(true, 2);

                threeX = enemy3 / BoardManager.Instance.n;
                threeY = enemy3 % BoardManager.Instance.n;
                gridArray[threeX, threeY].SetEnemySpawn(true, 3);

                int fourX = enemy4 / BoardManager.Instance.n;
                int fourY = enemy4 % BoardManager.Instance.n;
                gridArray[fourX, fourY].SetEnemySpawn(true, 4);

                break;
        }

        var center = new Vector2((float)height / 2 - 0.5f, (float)width / 2 - 0.5f);

        Camera.main.transform.position = new Vector3(center.x, center.y, -5);
        Camera.main.orthographicSize = 3 + BoardManager.Instance.n / 2 + BoardManager.Instance.n - 10;
    }

    internal int GetHeight()
    {
        return height;
    }

    internal int GetWidth()
    {
        return width;
    }    

    public Cell GetGridObject(int x, int y)
    {
        return gridArray[x, y];
    }

    internal float GetCellSize()
    {
        return cellSize;
    }

    public Cell[,] getArray()
    {
        return gridArray;
    }
}
