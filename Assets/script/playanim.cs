using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playanim : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    public bool endAnim;
    public Animator leveranimator;
    public Animator openStair;
    public Animator closelever;
    public Animator closeStair;
    public Animator fish;
    void Start()
    {
        anim = GetComponent<Animator>();
       
        endAnim = false;
        
    }

    // Update is called once per frame
    public void play()
    {anim.SetBool("tailFound",true);
    }

    public void playLeverAnimatin()
    {leveranimator.SetBool("opengate",true);
        closelever.SetBool("closeGate",false);
    }
    public void playCloselever()
    {closelever.SetBool("closeGate",true);
        leveranimator.SetBool("opengate",false);
       
    }
    public void playOpenStair()
    {openStair.SetBool("openStair",true);
        closeStair.SetBool("closeStair",false);

    }

   

    public void playCloseStair()
    {openStair.SetBool("openStair",false);
        closeStair.SetBool("closeStair",true);
    }

    public void playfish()
    {
      
        fish.SetBool("beeFish",true);
    }
}
