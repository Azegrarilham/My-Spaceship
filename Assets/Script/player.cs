using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody rb;
    [SerializeField] GameObject l9rtas, powerEf, effecton;
    bool poweron;
    ui UIScript;
    Vector3 offset = new Vector3(0, 0, 2);
    [SerializeField] AudioClip shoot, powerSound, bow;
    AudioSource audioSource;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        UIScript = GameObject.Find("Canvas").GetComponent<ui>();
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        //float movex = Input.GetAxis("Horizontal");
        //Vector3 position = new Vector3(movex * speed, 0, 0);
        //rb.MovePosition(rb.position + position * Time.deltaTime);

        Debug.Log(Input.mousePosition);
        Vector3 mousePostion = new Vector3(Input.mousePosition.x, 0, 0);
        rb.MovePosition(mousePostion * Time.deltaTime);
    }
    private void Update()
    {
        if (transform.position.x < 0)
        {
            transform.position = new Vector3(0, 0, 0);
        }
        if (transform.position.x > 40)
        {
            transform.position = new Vector3(40, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(l9rtas, transform.position, l9rtas.transform.rotation);
            audioSource.PlayOneShot(shoot);
        }
        if (Input.GetKeyDown(KeyCode.X) && poweron)
        {
            audioSource.PlayOneShot(bow);
            Instantiate(powerEf, transform.position + offset, powerEf.transform.rotation);
            poweron = false;
            effecton.SetActive(false);
            Debug.Log("ba7");
        }
        if (Input.GetMouseButtonDown(0))// left click
        {
            Instantiate(l9rtas, transform.position, l9rtas.transform.rotation);
            audioSource.PlayOneShot(shoot);
        }
        if (Input.GetMouseButtonDown(1) && poweron)// right  click
        {
            audioSource.PlayOneShot(bow);
            Instantiate(powerEf, transform.position + offset, powerEf.transform.rotation);
            poweron = false;
            effecton.SetActive(false);
            Debug.Log("ba7");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        audioSource.PlayOneShot(powerSound);
        Destroy(other.gameObject);
        poweron = true;
        UIScript.powerupHealth();
        effecton.SetActive(true);
        Debug.Log("katn");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag("playerShoot"))
        {
            UIScript.damage(0.2f);
            //collision.gameObject.GetComponent<MeshCollider>().enabled = false;
        }
        
    }
}
