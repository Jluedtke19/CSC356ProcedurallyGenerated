using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour {

    public int width, height;

    public VisualCell visualCellPrefab;

    public Cell[,] cells;

    private Vector2 randomCellPos;
    private VisualCell visualCellInst;

    private List<CellAndRelativePosition> neighbors;

	void Start () {
        cells = new Cell[width, height];
        Init();
	}
	
    void Init()
    {
        for(int i = 0; i <width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                cells[i, j] = new Cell(false, false, false, false, false);
                cells[i, j].xPos = i;
                cells[i, j].zPos = j;
            }
        }
        RandomCell();
        InitVisualCell();
    }

    void RandomCell()
    {
        randomCellPos = new Vector2((int)Random.Range(0, width), (int)Random.Range(0, height));

        GenerateMaze((int)randomCellPos.x, (int)randomCellPos.y);
    }

    void GenerateMaze(int x, int y)
    {
        Cell currentCell = cells[x, y];
        neighbors = new List<CellAndRelativePosition>();
        if (currentCell.visited == true) return;
        currentCell.visited = true;

        if(x + 1 < width && cells[x +1, y].visited == false)
        {
            neighbors.Add(new CellAndRelativePosition(cells[x + 1, y], CellAndRelativePosition.Direction.East));
        }
        if (y + 1 < height && cells[x, y + 1].visited == false)
        {
            neighbors.Add(new CellAndRelativePosition(cells[x, y + 1], CellAndRelativePosition.Direction.South));
        }
        if (x - 1 >= 0 && cells[x - 1, y].visited == false)
        {
            neighbors.Add(new CellAndRelativePosition(cells[x - 1, y], CellAndRelativePosition.Direction.West));
        }
        if (y - 1 >= 0 && cells[x, y - 1].visited == false)
        {
            neighbors.Add(new CellAndRelativePosition(cells[x, y - 1], CellAndRelativePosition.Direction.North));
        }

        if (neighbors.Count == 0) return;
        neighbors.Shuffle();

        foreach(CellAndRelativePosition selectedcell in neighbors)
        {
            if(selectedcell.direction == CellAndRelativePosition.Direction.East)
            {
                if (selectedcell.cell.visited) continue;
                currentCell.East = true;
                selectedcell.cell.West = true;
                GenerateMaze(x + 1, y);
            }
            if (selectedcell.direction == CellAndRelativePosition.Direction.South)
            {
                if (selectedcell.cell.visited) continue;
                currentCell.South = true;
                selectedcell.cell.North = true;
                GenerateMaze(x, y + 1);
            }
            if (selectedcell.direction == CellAndRelativePosition.Direction.West)
            {
                if (selectedcell.cell.visited) continue;
                currentCell.West = true;
                selectedcell.cell.East = true;
                GenerateMaze(x - 1, y);
            }
            if (selectedcell.direction == CellAndRelativePosition.Direction.North)
            {
                if (selectedcell.cell.visited) continue;
                currentCell.North = true;
                selectedcell.cell.South = true;
                GenerateMaze(x, y - 1);
            }
        }
    }

    void InitVisualCell()
    {
        foreach (Cell cell in cells)
        {
            visualCellInst = Instantiate(visualCellPrefab, new Vector3(cell.xPos * 3, 0, height * 3f - cell.zPos * 3), Quaternion.identity) as VisualCell;
            visualCellInst.transform.parent = transform;
            visualCellInst.North.gameObject.SetActive(!cell.North);
            visualCellInst.South.gameObject.SetActive(!cell.South);
            visualCellInst.East.gameObject.SetActive(!cell.East);
            visualCellInst.West.gameObject.SetActive(!cell.West);

            visualCellInst.transform.name = cell.xPos.ToString() + "_" + cell.zPos.ToString();
        }
    }
}
