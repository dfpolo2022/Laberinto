using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private GameObject Inner;
    private Grid grid;
    public bool isWalkable;
    public int x, y ;
    public int gCost, hCost, fCost;
    public Cell pastCell;
    public bool isEnd;
    public bool isStart;
    public bool isEnemySpawn;
    public int enemyNumber;

    public void Init(Grid grid, int x, int y, bool isWalkable, bool isEnd, bool isStart, bool isEnemySpawn)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        this.isWalkable = isWalkable;
        this.isEnd = isEnd;
        this.isStart = isStart;
        this.isEnemySpawn = isEnemySpawn;
    }

    public Vector2 Position => transform.position;

    public void SetColor(Color color)
    {
        Inner.GetComponent<SpriteRenderer>().color = color;
    }

    internal void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    internal void SetWalkable(bool v)
    {
        isWalkable = v;
        SetColor(Color.black);
    }

    internal void SetEnd(bool v)
    {
        isEnd = v;
        SetColor(Color.red);
    }

    internal void SetStart(bool v)
    {
        isStart = v;
    }

    internal void SetEnemySpawn(bool v, int n)
    {
        isEnemySpawn = v;
        switch (n)
        {
            case 1:
                enemyNumber = 1;
                break;

            case 2:
                enemyNumber = 2;
                break;

            case 3:
                enemyNumber = 3;
                break;

            case 4:
                enemyNumber = 4;
                break;
        }
    }

    public override string ToString()
    {
        return "Cell "+x + "," + y;
    }
}
