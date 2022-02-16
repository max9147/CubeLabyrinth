using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell
{
    public int X;
    public int Y;
    public bool WallLeft = true;
    public bool WallBottom = true;
    public bool Visited = false;
}

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject mazePart;

    private int mazeWidth = 11;
    private int mazeHeight = 11;

    private void Start()
    {
        StartGeneration();
    }

    public void StartGeneration()
    {
        MazeCell[,] maze = GenerateMaze();

        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                MazeCellData c = Instantiate(mazePart, new Vector3(x * 2, 0, y * 2), Quaternion.identity).GetComponent<MazeCellData>();
                c.WallLeft.SetActive(maze[x, y].WallLeft);
                c.WallBottom.SetActive(maze[x, y].WallBottom);
            }
        }
        GetComponent<NavMeshGenerator>().BakeNavMesh();
    }

    public MazeCell[,] GenerateMaze()
    {
        MazeCell[,] maze = new MazeCell[mazeWidth, mazeHeight];
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                maze[x, y] = new MazeCell { X = x, Y = y };
            }
        }

        for (int x = 0; x < maze.GetLength(0); x++)
        {
            maze[x, mazeHeight - 1].WallLeft = false;
        }

        for (int y = 0; y < maze.GetLength(1); y++)
        {
            maze[mazeWidth - 1, y].WallBottom = false;
        }

        RemoveWalls(maze);
        return maze;
    }

    private void RemoveWalls(MazeCell[,] maze)
    {
        MazeCell current = maze[0, 0];
        current.Visited = true;
        Stack<MazeCell> stack = new Stack<MazeCell>();
        do
        {
            List<MazeCell> unvisited = new List<MazeCell>();

            int x = current.X;
            int y = current.Y;

            if (x > 0 && !maze[x - 1, y].Visited) unvisited.Add(maze[x - 1, y]);
            if (y > 0 && !maze[x, y - 1].Visited) unvisited.Add(maze[x, y - 1]);
            if (x < mazeWidth - 2 && !maze[x + 1, y].Visited) unvisited.Add(maze[x + 1, y]);
            if (y < mazeHeight - 2 && !maze[x, y + 1].Visited) unvisited.Add(maze[x, y + 1]);

            if (unvisited.Count > 0)
            {
                MazeCell chosen = unvisited[Random.Range(0, unvisited.Count)];
                RemoveWall(current, chosen);
                chosen.Visited = true;
                stack.Push(chosen);
                current = chosen;
            }
            else
            {
                current = stack.Pop();
            }

        } while (stack.Count > 0);
    }

    private void RemoveWall(MazeCell a, MazeCell b)
    {
        if (a.X == b.X)
        {
            if (a.Y > b.Y) a.WallBottom = false;
            else b.WallBottom = false;
        }
        else
        {
            if (a.X > b.X) a.WallLeft = false;
            else b.WallLeft = false;
        }
    }    
}