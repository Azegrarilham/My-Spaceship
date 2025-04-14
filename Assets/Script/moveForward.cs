using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveForward : MonoBehaviour
{
    [SerializeField] ParticleSystem destroy;
    ui UIScript;
    [SerializeField] AudioClip crush;
    AudioSource audioSource;
    private void Start()
    {
        UIScript = GameObject.Find("Canvas").GetComponent<ui>();
        audioSource = GetComponent<AudioSource>();
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
        if (!collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("enemy"))
            {
                audioSource.PlayOneShot(crush);
                enemy en = collision.gameObject.GetComponent<enemy>();
                en.damageEnemy(1);
            }
            else
            {
                audioSource.PlayOneShot(crush);
                Destroy(collision.gameObject);
                UIScript.rookCount();
                Instantiate(destroy, collision.transform.position, destroy.transform.rotation);
            }
        }
    }
}
