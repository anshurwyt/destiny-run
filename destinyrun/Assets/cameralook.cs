using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameralook : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;
    public float camspeed,smoothtime;
    public Vector3 vel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vel = Vector3.zero;
        
        transform.position = target.transform.position + offset;
    }
}
