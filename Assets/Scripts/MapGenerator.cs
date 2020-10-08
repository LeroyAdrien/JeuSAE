using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int m_height;
    public int m_width;

    public int m_size;
    public float m_wallThickness;
    // Start is called before the first frame update
    public void GenerateMap()
    {
        ResetPreviousIteration();
        int[,] matrix = MarchingSquares.GeneratePoints(m_height, m_width);

        for (int z = 0; z < m_height; z++)
            for (int x = 0; x < m_width; x++)
            {
                DisplayPoint(x, z, m_size, matrix[z, x]);
            }
        
            List<Mur> wallList = MarchingSquares.GenerateWalls(matrix);
            
            foreach (Mur wall in wallList)
            {
                DisplayWall(wall.posInitial*m_size,wall.posFinal*m_size,m_wallThickness);
            }
            
        
    }
    void DisplayPoint(int x, int z, int size, int value)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Renderer sphereRenderer = sphere.GetComponent<Renderer>();

        sphere.transform.parent = transform;
        sphere.gameObject.tag = "Points";
        sphere.transform.position = new Vector3(x * size,0, z * size);
        sphere.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);


        var tempMaterial = new Material(sphereRenderer.sharedMaterial);
        if (value == 1)
        {
            tempMaterial.color = Color.white;
        }
        else if (value == 0)
        {
            tempMaterial.color = Color.black;
        }

        sphereRenderer.sharedMaterial = tempMaterial;

    }

    void DisplayWall(Vector3 posInitial, Vector3 posFinal, float thickness)
    {
        GameObject rectangle = GameObject.CreatePrimitive(PrimitiveType.Cube);

        Vector3 dirV = posFinal - posInitial;
        float angle = - Mathf.Atan(dirV.z / dirV.x);
        float longueur = Vector3.Distance(posInitial, posFinal);

        rectangle.transform.rotation = Quaternion.Euler(new Vector3(0, angle * 180 / 3.141592654f,0));
        rectangle.transform.position = posInitial + (posFinal - posInitial) / 2;
        rectangle.transform.localScale = new Vector3(longueur , thickness, thickness);

        rectangle.gameObject.tag = "Wall";



    }



    void ResetPreviousIteration()
    {
        GameObject[] pointsToclean = GameObject.FindGameObjectsWithTag("Points");
        GameObject[] wallssToclean = GameObject.FindGameObjectsWithTag("Wall");
        foreach (GameObject point in pointsToclean)
        {
            GameObject.DestroyImmediate(point);
        }

        foreach (GameObject wall in wallssToclean)
        {
            GameObject.DestroyImmediate(wall);
        }
    }
}

