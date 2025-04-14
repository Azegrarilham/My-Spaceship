using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ui : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject strtText, gameOver, healtBar;
    [SerializeField] Slider health;
    bool isAlive;
    [SerializeField] AudioClip powerDown, click;
    AudioSource audioSource;
    [SerializeField] Text rook, alain;
    int rookDes, alainDes;
    public bool IsAlive{get { return isAlive; }}
    private void Start()
    {
        player = GameObject.Find("player");
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(health.value <= 0)
        {
            GameOver();
        }
    }
    public void Restart()
    {
        audioSource.PlayOneShot(click);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void goplay() 
    {
        audioSource.PlayOneShot(click);
        strtText.SetActive(false);
        player.GetComponent<player>().enabled = true;
        healtBar.SetActive(true);
        isAlive = true;
    }

    public void damage(float amount)
    {
        health.value -= amount;
    }
    public void powerupHealth()
    {
        health.value ++;
    }
    public void rookCount()
    {
        rookDes++;
        rook.text = rookDes.ToString();
    }
    public void alainCount()
    {
        alainDes++;
        alain.text = alainDes.ToString();
    }
    void GameOver()
    {
        audioSource.PlayOneShot(powerDown);
        gameOver.SetActive(true);
        player.GetComponent<player>().enabled = false;
        isAlive = false;
    }
}
