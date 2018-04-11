using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used for the maze generator to determine what wall is deleted. Code for this can be found in this project
//https://blackeagleproject.wordpress.com/2015/08/25/avant-propos-du-tutoriel-n2-creer-un-generateur-de-labyrinthe-avec-unity-en-c/

public static class ListExtensions {

	public static IList<T> Shuffle<T> (this IList<T> list)
    {
        int n = list.Count;

        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
        return list;
    } 
}
