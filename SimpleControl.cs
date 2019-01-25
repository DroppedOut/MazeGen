using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using System.IO;
using System.Threading;

public class SimpleControl : MonoBehaviour {
	
	//all left wheels
    public GameObject[] LeftWheels;
	//all right wheels
    public GameObject[] RightWheels;

    public GameObject LeftTrack;

    public GameObject RightTrack;
    
    public float wheelsSpeed = 0.1f;
    public float tracksSpeed = 0.1f;
    public float forwardSpeed = 0.1f;
    public float rotateSpeed = 1f;
    public bool CanForward = true;
    public bool Back = true;
    public bool ToggleCharacterControl = false;
  //  string CommandFilePath = @"C:\Users\Xiaomi\Documents\Maze AI\Mazes\controls.txt";


    // Use this for initialization
    void Start () {



    }
  
    void GoBack()
    {
        //Left wheels rotate
        foreach (GameObject wheelL in LeftWheels)
        {
            wheelL.transform.Rotate(new Vector3(-wheelsSpeed, 0f, 0f));
        }
        //Right wheels rotate
        foreach (GameObject wheelR in RightWheels)
        {
            wheelR.transform.Rotate(new Vector3(-wheelsSpeed, 0f, 0f));
        }
        //left track texture offset
        LeftTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0, Time.deltaTime * -tracksSpeed);
        //right track texture offset
        RightTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0, Time.deltaTime * -tracksSpeed);
        //Move Tank
        transform.Translate(new Vector3(0f, 0f, -forwardSpeed));

    }
    void Forward()
    {
        if ((CanForward) && (!ToggleCharacterControl))
        { 
        foreach (GameObject wheelL in LeftWheels)
        {
            wheelL.transform.Rotate(new Vector3(wheelsSpeed, 0f, 0f));
        }
        //Right wheels rotate
        foreach (GameObject wheelR in RightWheels)
        {
            wheelR.transform.Rotate(new Vector3(wheelsSpeed, 0f, 0f));
        }
        //left track texture offset
        LeftTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0, Time.deltaTime * tracksSpeed);
        //right track texture offset
        RightTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0, Time.deltaTime * tracksSpeed);

        //Move Tank

        transform.Translate(new Vector3(0f, 0f, forwardSpeed));
        }

    }
    void TurnLeft(int deg=1)
    {
        //Left wheels rotate
        foreach (GameObject wheelL in LeftWheels)
        {
            wheelL.transform.Rotate(new Vector3(-wheelsSpeed, 0f, 0f));
        }
        //Right wheels rotate
        foreach (GameObject wheelR in RightWheels)
        {
            wheelR.transform.Rotate(new Vector3(wheelsSpeed, 0f, 0f));
        }
        //left track texture offset
        LeftTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0, Time.deltaTime * -tracksSpeed);
        //right track texture offset
        RightTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0, Time.deltaTime * tracksSpeed);
        //Rotate Tank
        transform.Rotate(new Vector3(0f, -deg, 0f));
    }
    void TurnRight(int deg = 1) {
        //Left wheels rotate
        foreach (GameObject wheelL in LeftWheels)
        {
            wheelL.transform.Rotate(new Vector3(wheelsSpeed, 0f, 0f));
        }
        //Right wheels rotate
        foreach (GameObject wheelR in RightWheels)
        {
            wheelR.transform.Rotate(new Vector3(-wheelsSpeed, 0f, 0f));
        }
        //left track texture offset
        LeftTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0, Time.deltaTime * tracksSpeed);
        //right track texture offset
        RightTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0, Time.deltaTime * -tracksSpeed);
        //Rotate Tank
        transform.Rotate(new Vector3(0f, deg, 0f));
    }
    void Backward()
    {
        //Left wheels rotate
        foreach (GameObject wheelL in LeftWheels)
        {
            wheelL.transform.Rotate(new Vector3(-wheelsSpeed, 0f, 0f));
        }
        //Right wheels rotate
        foreach (GameObject wheelR in RightWheels)
        {
            wheelR.transform.Rotate(new Vector3(wheelsSpeed, 0f, 0f));
        }
        //left track texture offset
        LeftTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0f, Time.deltaTime * -tracksSpeed);
        //right track texture offset
        RightTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0f, Time.deltaTime * -tracksSpeed);
        //Move Tank
        transform.Translate(new Vector3(0f, 0f, -forwardSpeed));
    }
    void KeyBoardRules()
    {
        //Keyboard moves =======================================//
        //Forward Move
        if (Input.GetKey(KeyCode.W))
        {
            Forward();

        }
        //Back Move
        if (Input.GetKey(KeyCode.S))
        {
            Backward();
        }
        //On Left
        if (Input.GetKey(KeyCode.A))
        {
            TurnLeft();
        }
        //On Right
        if (Input.GetKey(KeyCode.D))
        {
            TurnRight();
        }
        //=======================================//
    }
    void Update () {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Vector3 lft = transform.TransformDirection(Vector3.left);
        Vector3 rght = transform.TransformDirection(Vector3.right);

        Forward();
 

       

        if (Physics.Raycast(transform.position, fwd, 4))
            print("There is something in front of the object!");



        if (Physics.Raycast(transform.position, lft, 4))
            print("There is something in left of the object!");


       

        if ((Physics.Raycast(transform.position, rght, 4))&&(Physics.Raycast(transform.position, fwd, 4)))
        {
            print("Right&Forward");
            TurnLeft(90);
        }
        else
         if ((Physics.Raycast(transform.position, lft, 4)) && (Physics.Raycast(transform.position, fwd, 4)))
        {
            print("Left&Forward");
            TurnRight(90);
        }


        KeyBoardRules();
    }
}
