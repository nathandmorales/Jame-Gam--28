using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //Subtract from health not num of hearts
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public GameObject hitIndicater;

    private void Start()
    {
    }

    private void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        CheckDeath();
        DamageTest();
    }


    void CheckDeath()
    {
        if (health <= 0)
        {
            //gameManager.level = 0;
            //SceneManager.LoadScene("Lose");
        }
    }

    public void Hit(int dmg)
    {
        health -= dmg;
        hitIndicater.SetActive(true);
        //GetComponent<AudioSource>().playerHit.Play();
        //screenShake.Shake();
    }

    public void DamageTest()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Hit(1);
        }
    }
}
