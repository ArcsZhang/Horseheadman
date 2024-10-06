using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speed = 6.0f;
    // Update is called once per frame
    void Update()
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        if(moveDirection.magnitude >= 0.1f)
        {
            Vector3 move = moveDirection * speed * Time.deltaTime;
            transform.position += move;
        }
        
        //transform.Translate(moveDirection, Space.World);


    }
}
