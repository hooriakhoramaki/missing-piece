using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class afteranim : MonoBehaviour
{
    public Transform rope;
    public Transform tail;
    public Transform changak;
    public playanim p;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (p.endAnim)
        {   
            rope.position=new Vector3(-0.332f,1.144f,0.17438f);
            tail.position = new Vector3(0.2021f,-0.37313f,0.17438f);
            changak.position=new Vector3(-0.37552f,1.0864f,0f);
        }

    }

   
}
