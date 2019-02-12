using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public Vector3 spinSpeed = new Vector3(0, 0, 0);
    
    public Vector3 spinAxis = new Vector3(0, 1, 0);
    //defines the axis of rotation as the Y AXIS

    public float rotateSpeed = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        spinSpeed = new Vector3(Random.value - Random.value, Random.value - Random.value, Random.value - Random.value);
        //sets a random value for each vector between 1.0 and -1.0
        spinAxis = Vector3.up;
        spinAxis.x = (Random.value - Random.value) * .1f; // 0 - 1 = -1; //1 - 0 = +1
        //adds wobble on the xAxis
        // * .1f limits the range of (-1 to +1) to (-.1 to +.1)
    }

    public void SetSize(float size) //"size" is the name of the floating point number that we are going to set in the Start reference to this function
    {
        //this.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
        this.transform.localScale = new Vector3(size, size, size);
        //setting the scale to be 
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(spinSpeed);
        //the default rotation rotates around the centre of the object itself
        
        //this.transform.RotateAround(Vector3.zero, Vector3.up, 1.0f);
        this.transform.RotateAround(Vector3.zero, spinAxis, rotateSpeed); //RotateAround(vector3 point, vector3 axis, float angle)
        //    Vector.zero tells the object to rotate around the vector of (0, 0, 0), creating an origin of rotation
        //    Vector3.up defines the axis of rotation / tells the obj to rotate AROUND the UP AXIS 
    }
}

/*     TUTORIAL CODE 
// ---------------------------------------------------------------------------------
// COMMENTS ABOUT THE CODE!
// ---------------------------------------------------------------------------------
// HERE IS THE EXACT SAME CODE ABOVE, BUT WITH INLINE COMMENTS FOR ADDITIONAL HELP.
// FEEL FREE TO DROP ME AN EMAIL OR DM IF YOU HAVE MORE QUESTIONS - @rickbarraza
public class CubeCode : MonoBehaviour
{
    // THIS FIELD IS PUBLIC SO WHEN WE WRITE OUR MAIN SCRIPT IN LESSON 2,
    // WE CAN CONTROL THE ROTATIONAL ORBIT SPEED INDIVIDUALLY
    
    public float RotateSpeed = 1.0f;
    
    // THESE FILEDS ARE PRIVATE, BUT ARE AVAILABLE TO BOTH START() AND UPDATE()
    // "spinSpeed" CONTROLS HOW FAST THE CUBE WILL SPIN AROUND ITSELF.
    // IT TAKES THREE VALUES THAT DETERMINE THE X, Y, Z SPIN IN DEGREES. 
    
    Vector3 spinSpeed = new Vector3(0, 0, 0);
    
    // "spinAxis" IS UESD IN ROTATION TO DETERMINE WHAT THE "UP" IS
    // FOR THE ROTATIONAL ORBIT. AS DISCUSSED, TO ROTATE AND OBJECT
    // AROUND A POINT, THEY BOTH NEED TO AGREE ON WHAT "UP" IS.
    // BY DEFAULT, Vector3.up IS (0, 1, 0) WHICH POINTS STRAIGHT UP THE Y-AXIS
    
    Vector3 spinAxis = Vector3.up;
    
    void Start()
    {
        // "Random.value" WILL RETURN A DECIMAL BETWEEN [0.0 to +1.0].
        // SO HERE, WE ARE SETTING THE X, Y, AND Z ROTATIONS ALL TO THEIR 
        // OWN RANDOM VALUES BETWEEN 0 AND 1 DEGREE. THAT WAY, EACH CUBE
        // WILL SPIN IT'S OWN UNIQUE WAY.
        
        spinSpeed = new Vector3(Random.value, Random.value, Random.value);
        
        // BUT IF YOU WANT TO GET A RANDOM VALUE FROM [-1.0 to +1.0], HERE IS
        // ANOTHER COOL TRICK. JUST DO (Random.value - Random.value).
        // AT MOST, IT WILL BE (+1.0 - 0.0) or +1.0 
        // AT LEAST, IT WILL BE (0.0 - 1.0) or -1.0
        // BY MUTLIPLYING THIS (-1 to +1) RANDOM VALUE BY .1f, WE SHRINK IT
        // DOWN TO BEING IN THE POSSIBLE RANGE OF [-0.1 to +0.1] A MUCH SMALLER
        // VALUE. THIS WAY, spinAxis IS STILL "MOSTLY POINTING UP" BUT WITH A 
        // LITTLE BIT OF TILT ADDED TO THE X, SO IT DOESN'T LOOK SO PERFECT AND BORING
        
        spinAxis.x = .1f * (Random.value - Random.value);
    }
    
    // THIS FUNCTION IS PUBLIC, AND WILL BE CALLED BY ANOTHER CLASS IN LESSON 2.
    
    public void SetSize(float size)
    
    {
        // SINCE WE WANT TO KEEP THE BOX A PERFECT CUBE, WE ONLY  ASK FOR
        // ONE SIZE AND MAKE SURE THAT LENGTH, WIDTH, AND HEIGHT ARE ALL SET THE SAME
        
        this.transform.localScale = new Vector3(size, size, size);
    }
    
    // Update() IS OUR LOOPING FUNCTION THAT LETS US MAKE SMALL CHANGES EVERY "FRAME"
    // SINCE THERE ARE MANY FRAMES PER SECOND, THIS CREATES THE ILLUSION OF ANIMATION
    
    void Update()
    {
        // FIRST WE SPIN THE CUBE AROUND ITSELF USING OUR spinSpeed VALUES SET IN Start()
        
        this.transform.Rotate(spinSpeed);
        
        // THEN WE ROTATE THE CUBE AROUND THE ORIGIN (0,0,0), or Vector3.zero, 
        // AT WHATEVER VALUE HAS BEEN GIVEN TO RotateSpeed
        
        this.transform.RotateAround(Vector3.zero, spinAxis, RotateSpeed);
    }
}

*/