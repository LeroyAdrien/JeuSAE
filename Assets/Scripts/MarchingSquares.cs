using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MarchingSquares
{
    //Generate Points for the matrix 
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

    public static List<Mur> GenerateWalls(int[,] pointMatrix)
    {
        //int length=pointMatrix.
        int height = pointMatrix.GetLength(0);
        int width = pointMatrix.GetLength(1);
        List<Mur> murs = new List<Mur>();

        for (int i = 0; i < height - 1; i++)
            for (int j = 0; j < width - 1; j++)
            {
                int a = pointMatrix[i, j];
                int b = pointMatrix[i, j + 1];
                int c = pointMatrix[i + 1, j];
                int d = pointMatrix[i + 1, j + 1];

                int compte = BitsToNumber(a, b, c, d);
                murs.Add(GenerateSingleWall((float)i, (float)j, compte));

            }
        return murs;
    }

    public static Mur GenerateSingleWall(float x, float y, int value)
    {
        Mur mur = new Mur(Vector3.zero,Vector3.zero);
        switch (value)
        {
            case 1:
                mur = new Mur(new Vector3(x, y + 0.5f, 0f), new Vector3(x + 0.5f, y, 0f));
                break;
                /*
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 10:
                    break;
                case 11:
                    break;
                case 12:
                    break;
                case 13:
                    break;
                case 14:
                    break;
                case 15:
                    break;
                */
        }
        return mur;
    }

    public static int BitsToNumber(int a, int b, int c, int d)
    {
        return (int)(a * Mathf.Pow(2, 0) +
                      b * Mathf.Pow(2, 1) +
                      c * Mathf.Pow(2, 2) +
                      d * Mathf.Pow(2, 3));
    }

}
public class Mur
{
    public Vector3 posInitial;
    public Vector3 posFinal;

    public Mur(Vector3 posInitial, Vector3 posFinal)
    {
        this.posInitial = posInitial;
        this.posFinal = posFinal;
    }

}


