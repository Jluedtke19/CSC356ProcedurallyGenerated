using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {

    public bool West, North, South, East;
    public bool visited;

    public int xPos, zPos;

	public Cell(bool west, bool north, bool east, bool south, bool visited)
    {
        this.West = west;
        this.North = north;
        this.East = east;
        this.South = south;
        this.visited = visited;
    }
}
