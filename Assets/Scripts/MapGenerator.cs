using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MapGenerator
{
    public static int[,] GeneratePoints(int height, int width)
    {
        int[,] matrix = new int[height, width];
        for (int y = 0; y < height; y++)
            for (int x = 0; x < width; x++)
            {
                matrix[y, x] = Random.Range(0, 2);
            }
        return matrix;
    }
/*
    public static List<Vector3[]> GenerateLines(int[,] pointMatrix)
    {

    }
    */
}
