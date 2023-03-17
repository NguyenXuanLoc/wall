using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    public int gridSizeX = 12;
    public int gridSizeY = 5;
    public int gridSizeZ = 3;
    public float gridSpacing = 1f;
    public GameObject cubePrefab;

    void Start()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                for (int z = 0; z < gridSizeZ; z++)
                {
                    Vector3 cubePosition = new Vector3(x * gridSpacing, y * gridSpacing, z * gridSpacing);
                    GameObject cube = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cylinder), cubePosition, Quaternion.identity);
                    cube.transform.localScale = new Vector3(gridSpacing, gridSpacing, gridSpacing);
                    if(x %2 == 0)
                    {
                        cube.GetComponent<Renderer>().material.color = Color.black;
                    }
                    else
                    {
                        cube.GetComponent<Renderer>().material.color = Color.red;
                    }
                    cube.transform.parent = transform;
                }
            }
        }
    }
}