using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class throwRope : MonoBehaviour
{
    private LineRenderer line;
    public Rigidbody2D origin;
    public float line_width = .01f;
    private Vector3 velocity;
    public float speed = 20f;
    public Transform end_rope;
    public Vector2 dir2;
    public Vector2 dir1;
    public playanim p;
    public bool foundTail;
    public CharacterController2D _characterScript;
    public GameObject changakButton;
   
    

    public Material mat;
    // Start is called before the first frame update
   public void setstart(Vector2 targetpos)
   {
        dir1 = targetpos - origin.position;
       dir1 = dir1.normalized;
       velocity = dir1 * speed;
      
        transform.position = origin.position+dir1;
    }
   public void setend(Vector2 targetpos)
   {
        dir2 =   origin.position-targetpos;
       dir2 = dir2.normalized;
       velocity =1* dir2 * speed;
      
       transform.position = origin.position+dir2;
   }

    void Start()
    {
        foundTail = false;
        line = GetComponent<LineRenderer>();
        if (!line)
        {
            line = gameObject.AddComponent<LineRenderer>();
        }

        line.startWidth = line_width;
        line.endWidth = line_width;
        line.material = mat;

    }

    // Update is called once per frame
    void Update()
    {
       


            transform.position += velocity * Time.deltaTime;


            line.SetPosition(0, transform.position);
            line.SetPosition(1, origin.position);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        velocity = Vector2.zero;
        if (other.transform.tag=="ground")
        {
            setend(origin.position);
        }
        if (other.transform.tag=="tail")
        {
            setend(origin.position);
            Debug.Log("tail");
            changakButton.GetComponent<Button>().interactable = false;
            GameObject.Find("hiddenOBJ").GetComponent<Animator>().enabled = true;
            p.play();
            StartCoroutine(wait());
           
           




        }
        
          
            
        
        
       

    }
    IEnumerator wait()
    {
     
        yield return new WaitForSeconds(2);
        p.endAnim = true;
        foundTail = true;
        _characterScript.characterMovment = true;




    }
}
