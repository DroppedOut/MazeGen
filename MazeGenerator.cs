using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MazeGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string path = @"C:\Users\Xiaomi\Documents\Maze AI\Mazes\maze.txt";



        Debug.Log("читаем файл");
        StreamReader sr = new StreamReader(path);
        //Debug.Log(sr.ReadToEnd());





        // Update is called once per frame
        void Update()
        {

        }
    }
}
