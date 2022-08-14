using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropesetter : MonoBehaviour
{
    // Start is called before the first frame update
    public throwRope th_Ro;
    public Transform end_rope;
    public bool check_throwline=false;
    void Start()
    {
        
    }

    // Update is called once per frame
  public  void throwRope()
    {

        
           
            th_Ro.setstart(new Vector2(end_rope.position.x , end_rope.position.y ));
         

        
        

       
       
        
    }
}
