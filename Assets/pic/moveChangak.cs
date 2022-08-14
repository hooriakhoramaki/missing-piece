using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveChangak : MonoBehaviour
{
    public Rigidbody2D rope;
    public float movespeed ;
    public float leftAngle;
    public float RightAngle;
   // private float angle;
 //   public float target;
  // public static bool ropemo;
   // public Rigidbody2D throwRope;

    private bool movingClockWise;
    public throwRope scriptthroerope;

    void Start()
    {
       
        rope = GetComponent<Rigidbody2D>();
        movingClockWise = true;


    }

    // Update is called once per frame
     void Update()
     {
       
             move();
      
        

     }

     public void changemovedir()
     {
         if (transform.rotation.z>RightAngle)
         {
             movingClockWise = false;
         }
         if (transform.rotation.z<leftAngle)
         {
             movingClockWise = true;
         }
     }

     public void move()
     {
         changemovedir();
         if (movingClockWise)
         {
             rope.angularVelocity = movespeed;

         }
         if (!movingClockWise)
         {
             rope.angularVelocity = -1*movespeed;

         }
     }

     void FixedUpdate()
    {
      /*  if (ropemo)
        {


            if (Input.GetKeyDown("a"))
            {
                rope.MoveRotation(rope.rotation - movespeed * Time.fixedDeltaTime);
            }





             if (Input.GetKeyDown("d"))
            {
                rope.MoveRotation(rope.rotation + movespeed * Time.fixedDeltaTime);



            }
        }

       if (Input.GetKeyDown(KeyCode.Space))
        {

           GameObject.Find("changak").GetComponent<HingeJoint2D>().connectedBody =throwRope ;

        }
        else
        {
           // rope.MoveRotation(rope.rotation + 0 * Time.fixedDeltaTime);
        }

      /*   if (Input.GetKeyDown("s"))
         {


             rope.MovePosition(Vector2.down);

         
     }*/
           /* else
            {
                
                
            }*/
    }
}
