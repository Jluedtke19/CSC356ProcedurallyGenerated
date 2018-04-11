using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * The maze is generated with this cell object. This code is from the project that is found on this website:
 * https://blackeagleproject.wordpress.com/2015/08/25/avant-propos-du-tutoriel-n2-creer-un-generateur-de-labyrinthe-avec-unity-en-c/.
 * We added the obstacle boolean that determines if a cell is an obstacle or not. 
 **/

public class Cell : MonoBehaviour {

    public bool West, North, South, East;
    public bool visited;

    public int xPos, zPos;

    public bool isObstacle;
	public Cell(bool west, bool north, bool east, bool south, bool visited, bool obstacle)
    {
        this.West = west;
        this.North = north;
        this.East = east;
        this.South = south;
        this.visited = visited;
        this.isObstacle = obstacle;
    }
}
