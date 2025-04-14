using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] GameObject player, healthBar;
    public float speed = 40f;
    [SerializeField] GameObject l9rtas;
    Vector3 offeset = new Vector3(0, -1f, -5);
    public float rotation = 30f;
    ui uiScript;
    [SerializeField] Slider health;
    public int maxHealth;
    void Start()
    {
        uiScript = GameObject.Find("Canvas").GetComponent<ui>();
        rb = GetComponent<Rigidbody>();
        health.maxValue = maxHealth;
        StartCoroutine("shoot");
    }
    private void Update()
    {
        healthBar.transform.rotation = Quaternion.LookRotation(healthBar.transform.position - player.transform.position);
    }
    private void FixedUpdate()
    {
        if (uiScript.IsAlive)
        {
            float directionx = (player.transform.position.x - transform.position.x);
            rb.AddForce(directionx * speed, 0, -speed);
            rb.AddTorque(0, 50, 0, ForceMode.Impulse);
            if (transform.position.z < 0)
            {
                Destroy(gameObject);
            }
            if(health.value == 0)
            {
                Destroy(gameObject);
                uiScript.alainCount();
            }
        }
    }
    public void damageEnemy(float amount)
    {
        health.value-= amount;
    }
    IEnumerator shoot()
    {
        while (uiScript.IsAlive)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(l9rtas, transform.position + offeset, l9rtas.transform.rotation);
        }
        
    }
}
