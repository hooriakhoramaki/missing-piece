using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class CharacterController2D : MonoBehaviour
{
    // Move player in 2D space
    public float maxSpeed = 3.4f;
    public float jumpHeight = 6.5f;
    public float gravityScale = 1.5f;
    public Camera mainCamera;

    bool facingRight = true;
    float moveDirection = 0;
    bool isGrounded = false;
    Vector3 cameraPos;
    Rigidbody2D r2d;
    CapsuleCollider2D mainCollider;
    Transform t;
    public  bool characterMovment=true;
     ropemovment ro;
     public playanim _Playanim;
     private bool hitlever;
     public GameObject changakButton;
     public bool inground=false;
     public GameObject exitanel;
    
      

    // Use this for initialization
    void Start()
    {
        hitlever = false;
      //  moveChangak.ropemo = false;
        t = transform;
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<CapsuleCollider2D>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
        facingRight = t.localScale.x > 0;

        if (mainCamera)
        {
            cameraPos = mainCamera.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (characterMovment)
        {


            // Movement controls
         /*  if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) &&
                (isGrounded || Mathf.Abs(r2d.velocity.x) > 0.01f))
            {
                moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;
                
                
            }
            else
            {
                if (isGrounded || r2d.velocity.magnitude < 0.01f)
                {
                    moveDirection = 0;
                }
            }

            // Change facing direction
            if (moveDirection != 0)
            {
                if (moveDirection > 0 && !facingRight)
                {
                    facingRight = true;
                    t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
                }

                if (moveDirection < 0 && facingRight)
                {
                    facingRight = false;
                    t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
                }
            }

            // Jumping
            if (Input.GetKeyDown(KeyCode.W) && isGrounded)
            {
                r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
            }*/
         moveDirection = CrossPlatformInputManager.GetAxis("Horizontal") * maxSpeed;
         if (moveDirection<0)
         {
             r2d.GetComponent<SpriteRenderer>().flipX = true;
         }
         if (moveDirection>0)
         {
             r2d.GetComponent<SpriteRenderer>().flipX = false;
         }
         r2d.AddForce(new Vector2(moveDirection*Time.deltaTime,0f));
        

       

            // Camera follow
            if (mainCamera)
            {



                mainCamera.transform.position = new Vector3(cameraPos.x, t.position.y, cameraPos.z);
                {
                    if (t.position.y > 0.08f)
                    {
                        mainCamera.transform.position = new Vector3(cameraPos.x, 0.08f, cameraPos.z);
                    }

                    if (t.position.y < -7f)
                    {
                        mainCamera.transform.position = new Vector3(cameraPos.x, -7f, cameraPos.z);
                    }
                }
                //mainCamera.transform.position = new Vector3(t.position.x, cameraPos.y, cameraPos.z);
                // mainCamera.transform.position = new Vector3(cameraPos.x, t.position.y, cameraPos.z);
            }
        }
    }


    public void Jump()
    {
       if ( /*r2d.velocity.y>=0 &&*/ inground)
        {
            r2d.AddForce(Vector2.up*200f);
          //  r2d.velocity = Vector2.up * 10f;
          inground = false;
        }
    }

    void FixedUpdate()
    {
        Bounds colliderBounds = mainCollider.bounds;
        float colliderRadius = mainCollider.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
        // Check if player is grounded
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);
        //Check if any of the overlapping colliders are not player collider, if so, set isGrounded to true
        isGrounded = false;
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != mainCollider)
                {
                    isGrounded = true;
                    break;
                }
            }
        }

        // Apply movement velocity
        r2d.velocity = new Vector2((moveDirection) * maxSpeed, r2d.velocity.y);

        // Simple debug
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(0, colliderRadius, 0), isGrounded ? Color.green : Color.red);
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(colliderRadius, 0, 0), isGrounded ? Color.green : Color.red);
    }

   



    //*******************************************************     COLLISION        ******************************************
    
    
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag=="home2")
        {Debug.Log("crash!!!!!!!!!");
            characterMovment = false;
          //  moveChangak.ropemo = true;


        }

        if (other.gameObject.tag=="home1" )
        {
            r2d.transform.position=new Vector3(2.264f,-2.846f,0);
            
        }
        if (other.gameObject.tag=="home1-2")
        {
            r2d.transform.position=new Vector3(1.97f,-4.57f,0);
            
        }
        if (other.gameObject.tag=="ground")
        {
            inground = true;
            Debug.Log("ground");

        }



        if (other.gameObject.tag=="lever" )
        {
            switch (hitlever)
            {
                 case false:

                    _Playanim.playLeverAnimatin();
                    _Playanim.playOpenStair();
                    changakButton.GetComponent<Button>().interactable = true;
                    GameObject.FindWithTag("door").GetComponent<BoxCollider2D>().isTrigger = true;
                    hitlever = true;

                   break;

                 case true:
                    Debug.Log("clseGate");
                    _Playanim.playCloselever();
                    _Playanim.playCloseStair();
                    changakButton.GetComponent<Button>().interactable = false;
                    GameObject.FindWithTag("door").GetComponent<BoxCollider2D>().isTrigger = true;
                    hitlever = false;
                    
                     break;
                 default:
                     break;
            }


        }

        if (other.gameObject.tag=="sea")
        {
            Debug.Log("die!!!!!!!!!!!");
            SceneManager.LoadScene("gamePlay");
        }
        if (other.gameObject.tag=="tail")
        {  GameObject.FindWithTag("tail").SetActive(false); 
            GameObject.FindWithTag("chatacter").SetActive(false);
            _Playanim.playfish();
            wait();
        }
       
    }
    IEnumerator wait()
    {
     
        yield return new WaitForSeconds(2);
        exitanel.transform.GetChild(0).gameObject.SetActive(true);
        



    }
    public void exit()
    {Application.Quit();
    }

    public void replay()
    {
        SceneManager.LoadScene("menu");
    }
    
}