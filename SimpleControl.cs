using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using System.IO;
using System.Threading;
using System;

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
            wheelR.transform.Rotate(new Vector3(wheelsSpeed, 0f, 0f));
        }
        //left track texture offset
        LeftTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0f, Time.deltaTime * -tracksSpeed);
        //right track texture offset
        RightTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0f, Time.deltaTime * -tracksSpeed);
        //Move Tank
        transform.Translate(new Vector3(0f, 0f, -forwardSpeed));

    }
    void forward()
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
            wheelR.transform.Rotate(new Vector3(-wheelsSpeed, 0f, 0f));
        }
        //left track texture offset
        LeftTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0f, Time.deltaTime * tracksSpeed);
        //right track texture offset
        RightTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0f, Time.deltaTime * tracksSpeed);

        //Move Tank

        transform.Translate(new Vector3(0f, 0f, forwardSpeed));
        }

    }
   
    void TurnLeft()
    {
        //Left wheels rotate
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
        LeftTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0f, Time.deltaTime * tracksSpeed);
        //right track texture offset
        RightTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0f, Time.deltaTime * -tracksSpeed);
        //Rotate Tank
        transform.Rotate(new Vector3(0f, -rotateSpeed, 0f));
    }
    void TurnRight() {
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
        LeftTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0f, Time.deltaTime * -tracksSpeed);
        //right track texture offset
        RightTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0f, Time.deltaTime * tracksSpeed);
        //Rotate Tank
        transform.Rotate(new Vector3(0f, rotateSpeed, 0f));
    }
    int tmp = 0;
    void Update () {
        

        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        
        if ((Physics.Raycast(transform.position, fwd, 10))&&(tmp%20==1))
        {
            print("There is something in front of the object!");
        }


        Vector3 lft = transform.TransformDirection(Vector3.left);
        Vector3 rght = transform.TransformDirection(Vector3.right);

        if ((Physics.Raycast(transform.position, fwd, 10))) {
               
            if ((Physics.Raycast(transform.position, lft, 10))){
                print("napravo blya");
            
                    GoBack();
                TurnRight();
            }
            }
            else
             if ((Physics.Raycast(transform.position, fwd, 10)))
        {

            if ((Physics.Raycast(transform.position, rght, 10)))
            {
                print("LEEEEEEEEVO");
                GoBack();
                TurnLeft();



            }
        }
        forward();
      

        if ((Physics.Raycast(transform.position, lft, 10)))
        {

            if ((Physics.Raycast(transform.position, rght, 10)))
            {
                print("Ebashu pryamo");
                
            }
        }



      

       


        // ИИ ЕЗДОКА



       


        tmp++;

        //Keyboard moves =======================================//
        //Forward Move

        if (Input.GetKey(KeyCode.R)) {
            ToggleCharacterControl = true;

        }


            if (Input.GetKey(KeyCode.W))
        {
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
            LeftTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0f,Time.deltaTime*tracksSpeed);
            //right track texture offset
            RightTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0f, Time.deltaTime * tracksSpeed);

            //Move Tank

            transform.Translate(new Vector3(0f, 0f, forwardSpeed));

        }
        //Back Move
        if (Input.GetKey(KeyCode.S))
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
        //On Left
        if (Input.GetKey(KeyCode.A))
        {
            //Left wheels rotate
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
            LeftTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0f, Time.deltaTime * tracksSpeed);
            //right track texture offset
            RightTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0f, Time.deltaTime * -tracksSpeed);
            //Rotate Tank
            transform.Rotate(new Vector3(0f,-rotateSpeed,0f));
        }
        //On Right
        if (Input.GetKey(KeyCode.D))
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
            LeftTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0f, Time.deltaTime * -tracksSpeed);
            //right track texture offset
            RightTrack.transform.GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0f, Time.deltaTime * tracksSpeed);
            //Rotate Tank
            transform.Rotate(new Vector3(0f, rotateSpeed, 0f));
        }
		//=======================================//
                                                   



    }
}
