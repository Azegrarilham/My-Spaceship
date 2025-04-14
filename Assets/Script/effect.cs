using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class effect : MonoBehaviour
{
    Rigidbody rb;
    public int Speed = 100;
    public float rotationSpeed = 50;
    Transform tr;
    ui UIScript;
    void Start()
    {
        UIScript = GameObject.Find("Canvas").GetComponent<ui>();
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
    }

    private void Update()
    {
        if (transform.position.z > 100)
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        rb.AddForce(Vector3.forward * Speed, ForceMode.Impulse);
        rb.AddTorque(0, 0, rotationSpeed, ForceMode.Impulse);
        transform.localScale += new Vector3(1, 0, 1);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        enemy en = collision.gameObject.GetComponent<enemy>();
        if (!collision.gameObject.CompareTag("Player"))
        {
            if (en != null)
            {
                en.damageEnemy(5);
                Destroy(gameObject);
            }
            else
            {
                Destroy(collision.gameObject);
                UIScript.rookCount();
            }
            //Instantiate(destroy, collision.transform.position, destroy.transform.rotation);
        }
    }
}
