using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MazeAndTerrain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string path = @"C:\Users\Xiaomi\Documents\Maze AI\Mazes\maze.txt";



        Debug.Log("читаем файл");
        StreamReader sr = new StreamReader(path);
        //Debug.Log(sr.ReadToEnd());
        string line;
        var walls = new GameObject[15, 15];
        int j = 0;
       
        while ((line = sr.ReadLine()) != null)
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '#')
                {
                    walls[i, j] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    walls[i, j].transform.position = new Vector3(0 + i * 7, 2, 0 + j * 7);
                    walls[i, j].transform.localScale = new Vector3(7, 5, 7);
                    walls[i, j].GetComponent<Renderer>().material.color = new Color(255,255,255,0.5f);
                }
                else
                if (line[i] == '+')
                {
                    walls[i, j] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    walls[i, j].transform.position = new Vector3(0 + i * 7, 0, 0 + j * 7);
                    walls[i, j].transform.localScale = new Vector3(7, 1, 7);
                    walls[i, j].GetComponent<Renderer>().material.color = new Color(0,0,0,1);
                }
                else
                {
                    walls[i, j] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    walls[i, j].transform.position = new Vector3(0 + i * 7, 0, 0 + j * 7);
                    walls[i, j].transform.localScale = new Vector3(7, 1, 7);
                    walls[i, j].GetComponent<Renderer>().material.color = new Color(0,0,1,1);
                }

            }
            j++;
        }
    }
    /*
       void Update()
   {

   }
   */
}

