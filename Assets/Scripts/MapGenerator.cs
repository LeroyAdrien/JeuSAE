using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int m_height;
    public int m_width;

    public int m_size;
    // Start is called before the first frame update
    public void GenerateMap()
    {
        ResetPreviousIteration();
        int[,] matrix = MarchingSquares.GeneratePoints(m_height, m_width);

        for (int y = 0; y < m_height; y++)
            for (int x = 0; x < m_width; x++)
            {
                DisplayPoint(x, y, m_size, matrix[y,x]);
            }
    }
    void DisplayPoint(int x, int y, int size, int value)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Renderer sphereRenderer = sphere.GetComponent<Renderer>();

        sphere.transform.parent=transform;
        sphere.gameObject.tag = "Points";
        sphere.transform.position = new Vector3(x * size, y * size, 0);
        sphere.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

        
        var tempMaterial = new Material(sphereRenderer.sharedMaterial);
        if (value == 1)
        {
            tempMaterial.color =Color.white;
        }
        else if (value == 0)
        {
            tempMaterial.color =Color.black;
        }

        sphereRenderer.sharedMaterial=tempMaterial;

    }

    

    void ResetPreviousIteration()
    {
        GameObject[] pointsToclean = GameObject.FindGameObjectsWithTag("Points");
        foreach (GameObject point in pointsToclean)
        {
            GameObject.DestroyImmediate(point);
        }
    }
}