using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour
{
    [SerializeField] ParticleSystem destroy;
    ui UIScript;
    private void Start()
    {
        UIScript = GameObject.Find("Canvas").GetComponent<ui>();
    }
    void Update()
    {
        transform.Translate(0, 0, 1);

        if (transform.position.z > 100 || transform.position.z < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            UIScript.damage(1);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Instantiate(destroy, collision.transform.position, destroy.transform.rotation);
        }


    }
}
