using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rookmove : MonoBehaviour
{
    public float speed = 100f;
    Rigidbody rb;
    public float rotation = 0.05f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(-Vector3.forward * speed * Time.deltaTime);
        rb.AddTorque(rotation, rotation, rotation, ForceMode.Impulse);
        if(transform.position.z < -5)
        {
            Destroy(gameObject);
        }
    }
   
}
