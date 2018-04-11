using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * This script is used for going through the maze and deleting walls. It contains the cell and the direction that it came from
 * so that the algorithm can back track to the original cell. This code is from the project found here
 * https://blackeagleproject.wordpress.com/2015/08/25/avant-propos-du-tutoriel-n2-creer-un-generateur-de-labyrinthe-avec-unity-en-c/
 **/


public class CellAndRelativePosition {

    public Cell cell;
    public Direction direction;
    
    public enum Direction
    {
        North,South,East,West
    }
    
    public CellAndRelativePosition (Cell cell, Direction direction)
    {
        this.cell = cell;
        this.direction = direction;
    }

}
