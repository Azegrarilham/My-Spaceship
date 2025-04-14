using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] ele;
    [SerializeField] GameObject  power;
    [SerializeField] List<GameObject> enemy;
    int range = 40;
    ui uiScript;
    void Start()
    {
        uiScript = GameObject.Find("Canvas").GetComponent<ui>();
        InvokeRepeating("spawnele", 0.25f, 0.5f);
        InvokeRepeating("enemySpawn", 10, 20);
        InvokeRepeating("Power", 5, 10);
    }

    void spawnele()
    {
        if (uiScript.IsAlive)
        {
            float x = Random.Range(0, range);
            float z = Random.Range(4, 21);
            Vector3 position = new Vector3(x, 0, z);
            int index = Random.Range(0, ele.Length);
            Instantiate(ele[index], position, ele[index].transform.rotation);
        }  
    }
   
    void enemySpawn()
    {
        if (uiScript.IsAlive)
        {
            float x = Random.Range(0, range);

            Vector3 position = new Vector3(x, 1, 30);
            int index = Random.Range(0, enemy.Count);
            Instantiate(enemy[index], position, enemy[index].transform.rotation);
        }   
    }
    void Power()
    {
        if (uiScript.IsAlive)
        {
            float x = Random.Range(0, range);
            float z = Random.Range(4, 21);
            Vector3 position = new Vector3(x, 0, z);

            Instantiate(power, position, power.transform.rotation);
        }          
    }
}
