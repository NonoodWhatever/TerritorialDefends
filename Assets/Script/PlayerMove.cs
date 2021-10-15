using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float movespeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        { gameObject.transform.position += new Vector3(0, 0, movespeed); }
        if (Input.GetKey(KeyCode.A))
        { gameObject.transform.position += new Vector3(-movespeed, 0, 0); }
        if (Input.GetKey(KeyCode.D))
        { gameObject.transform.position += new Vector3(movespeed, 0, 0); }
        if (Input.GetKey(KeyCode.S))
        { gameObject.transform.position += new Vector3(0, 0, -movespeed); }


    }
}
