using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveleftright : MonoBehaviour
{
    public float speed;
    public float Offset,speedmodifier;
    public bool istouchingleft, istouchingright;
    private Touch touch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            
            
                if (touch.phase == TouchPhase.Moved)
                {
                    if (transform.localPosition.x < -Offset )
                  {
                    transform.localPosition = new Vector3(-Offset,transform.localPosition.y,transform.localPosition.z);
                  }
                else if( transform.localPosition.x > Offset)
                     {
                    transform.localPosition = new Vector3(Offset, transform.localPosition.y, transform.localPosition.z);
                      }
                else 

                    transform.localPosition = new Vector3(
                    transform.localPosition.x + touch.deltaPosition.x * speedmodifier * Time.deltaTime,
                    transform.localPosition.y,
                    transform.localPosition.z);

                }
            
            Debug.Log(touch.position.x+""+""+touch.position.y);
        }
        
        //Debug.Log(transform.localPosition);
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                if (transform.localPosition.x<=-Offset)
                {

                }
                else
                    transform.Translate(Vector3.left * speed * Time.deltaTime, Space.Self);
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                if (transform.localPosition.x >= Offset)
                {

                }
                else
                    transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);
            }
        }
        else
        {

        }

    }


    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag=="leftstop")
        {
            istouchingleft = true;
        }
        else if(other.tag=="rightstop")
        {
            istouchingright = true;


        }
        if (other.tag == "books")
        {
            Destroy(other.gameObject);
            Debug.Log(other.name);
            GameObject.FindObjectOfType<gamemanager>().incrementbook();
        }
        else if (other.tag == "videogame")
        {
            Destroy(other.gameObject);
            Debug.Log(other.name);
            GameObject.FindObjectOfType<gamemanager>().incrementgames();
        }
        else
        {
            istouchingleft = false;
            istouchingright = false;
        }


        



    }
    private void OnTriggerExit(Collider other)
    {
        istouchingleft = false;
        istouchingright = false;
    }
}
