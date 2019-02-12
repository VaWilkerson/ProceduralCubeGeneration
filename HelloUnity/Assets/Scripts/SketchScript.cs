using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class SketchScript : MonoBehaviour
{
    public GameObject myPrefab; //spinCube prefab
    
    // Start is called before the first frame update
    void Start()
    {
        //LINEAR DISTRIBUTION
        int totalCubes = 20;    //sets the number of cubes in the scene
        float totalDistance = 2.9f;    //sets the total distance from the center that the cubes may instantiate 
        //We chose 5 because that's the distance to the nearest wall
        
        //SIN() DISTRIBUTION of cube size and speed
        for (int i = 0; i < totalCubes; i++)
        {
            float perc = i / (float)totalCubes;
            
            float sin = Mathf.Sin(perc * Mathf.PI/2);
            //convert degrees to radians 
            
            float x = 1.8f + sin * totalDistance; //starting at pos x=2 
            float y = 5.0f; 
            float z = 0.0f; 

            var newCube = (GameObject) Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity); //Quaternions are confusing but have something to do with rotation
            //Quaternion.identity indicates the default rotation of the object   
            
            newCube.GetComponent<CubeScript>().SetSize(.45f * (1.0f - perc)); //creates a maximum value (of .45) but keeps the distribution of 1.0f the same
            //newCube.GetComponent<CubeScript>().SetSize(1.0f - sin); //makes the size scale down faster 
            //newCube.GetComponent<CubeScript>().rotateSpeed = perc; //the very first cube would always rotate at 0 speed
            
            newCube.GetComponent<CubeScript>().rotateSpeed = 0.3f + perc * 4.0f; //sets a minimum rotation speed for the first cube
            //you could multiply the perc * 3.0f to make them all 3X faster
            //perc * perc makes them exponentially faster the smaller they are
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
/*
//if the number of cubes in the scene is less than 0, add 1 cube until the number is </= the number
        //    of cubes set in the totalCubes var
        for (int i = 0; i < totalCubes; i++)
        {
            float perc = i / (float)totalCubes; //identifies the placement of the cube within the number of totalCubes 
            //perc is short for percentage
            //used (float)totalCubes because when we divide an int by an int we always get a fraction (or 0)
            //    so we need to cast one of these as a float so it doesn't just round the number into an integer 
            //    and we can have a percentage
            
            //float x = i;
            //sets the x location for each cube to be 0, 1, 2, etc. 
            //so first cube will be at x=0, second at x=1, third at x=2, then it stops whenever it reaches the 
            //    number of totalCubes
            float x = perc * totalDistance; //x = the percentage of the total distance remaining 
            //takes the cube and sets it corresponding to it's number within the totalCubes * the totalDistance
            //    so that all the cubes are positioned evenly across the totalDistance. 
            float y = 4.0f; //sets cubes to instantiate at 5 along the y axis
            float z = 0.0f; 

            //Instantiate calls the object prefab and places it in the scene. 
            var newCube = (GameObject) Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
            //when you over over Instantiate, Unity tells you what it wants to know.
            //GameObejct original asks, which object you want to instantiate?
            //Vector3 position asks, where / what coords do you want to instantiate it at?
            //    We set the values of x,y,z coords above as floating variables so we wouldn't hard-code these
            //    numbers in the function 
            //Quaternion rotation asks, what orientation do you want it to have?
            //Quaternion.identity indicates the default rotation of the object   
            //"var newCube" is a variable which isn't necessarily defined as a GAME OBJECT.
            //.GetComponent can only call gameObjects so we must cast INSTANTIATE explicitly as a GAME OBJ.  

            newCube.GetComponent<CubeScript>().SetSize(1.0f - perc);
            //"1.0f - perc" sets the size to decrease from 1 by the perc value 
            //if there are 6 cubes the first cube is size 1, the second is 1/6 smaller, the second is 2/6 smaller and so on
            //newCube.GetComponent<CubeScript>().SetSize(0.5f);
            //telling newCube to get the component "CubeScript" 
            //Parentheses () make it real so we can talk to the cubeScript directly and 
            //    access the public SetSize function and plug a number in it. 

            newCube.GetComponent<CubeScript>().rotateSpeed = perc;  //0; //Random.value;
            //the further away they are the smaller they get but the faster they get
            //talks to the CubeScript's rotateSpeed function and assigns that speed a random value
        }      
*/
