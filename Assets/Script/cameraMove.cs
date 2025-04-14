using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    [SerializeField] GameObject player;
    Vector3 offset = new Vector3(0, 1, -0.78f);
    ui uiScript;
    AudioSource audioSource;
    void Start()
    {
        uiScript = GameObject.Find("Canvas").GetComponent<ui>();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.2f;
    }

    void Update()
    {
        
          
    }
    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
