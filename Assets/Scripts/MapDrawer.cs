using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDrawer : MonoBehaviour
{
    public int m_height;
    public int m_width;

    public int m_size;
    // Start is called before the first frame update
    void Start()
    {
        int[,] matrix = MapGenerator.GeneratePoints(m_height, m_width);

        for (int y = 0; y < m_height; y++)
            for (int x = 0; x < m_width; x++)
            {
                DisplayPoint(x, y, m_size, 0);
            }

    }

    // Update is called once per frame
    void Update()
    {

    }

    void DisplayPoint(int x, int y, int size, int value)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Renderer renderer = sphere.GetComponent<Renderer>();


        sphere.transform.position = new Vector3(x * size, y * size, 0);
        sphere.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        
        if(value==0){
            sphere.GetComponent().material.color = new Color(0, 0, 0, 0);
        }
        else if(value==1){
            sphere.GetComponnent().material.color = new Color(1, 1, 1, 1);
        }
        
    }
}
