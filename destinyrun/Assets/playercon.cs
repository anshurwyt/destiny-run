using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercon : MonoBehaviour
{

    public float speed, forspeed;
    public float currrot;
    public int movedir;
    public Vector3 tr,vr;
   public Quaternion  conveted;
    public bool rotate,Rrot,Lrot;
    // Start is called before the first frame update
    void Start()
    {

        transform.Rotate(transform.up ,360);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        conveted = transform.rotation;


       
        tr = transform.eulerAngles;
        vr = transform.localEulerAngles;
        Debug.Log(tr.y);
        if(rotate)
        {
            if (Rrot)
            {
                if (tr.y < currrot )
                {
                    transform.Rotate(transform.up * Time.deltaTime * speed);
                }
                else
                {
                    rotate = false;

                    Rrot = false;
                }

                
                
                
            }
            if(Lrot)
            {
                if (tr.y >=currrot)
                {
                        transform.Rotate(-transform.up * Time.deltaTime * speed);
                }
                else {
                    rotate = false;
                    
                    Lrot = false;
                }
                    
                
               
            }
            
        }

        transform.Translate(Vector3.forward * forspeed * Time.deltaTime);

        
    }


       


    

   
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "moveleft")
        {
            rotate = true;
            currrot = tr.y-90+1;
            Lrot = true;


        }else if (other.tag == "moveright")
        {
            rotate = true;
            currrot = tr.y+90-1;
            Rrot = true;


        }
        if(other.tag=="ll")
        {
            
        }
        
    }
   
        

    
    public void right()
    {

           
            rotate = true;
            currrot = transform.eulerAngles.y;
       
            Rrot = true;
        

    }

}
