using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerhealth : MonoBehaviour
{
    public int health = 100;
    public int damage = 10;
    public int increase_hlth = 10;
    public int time_dmg = 1; 
    public bool check = false;
    public Slider slider;
    public bool isDead = false;
    public GameManager gameManager;
    public TextMeshProUGUI prompt;

    void Update()
    {
        while(Time.deltaTime >= 1)
        {
            Debug.Log("Hello world !");
        }

        if (health <= 0 && check == false)
        {
            gameManager.endGame();
            check = true;
            Debug.Log("You died");
            isDead = true;
        }


        if(health > 100)
        {
            health = 100;
        }

        

       
    }

    private void settext()
    {
        prompt.text = "";
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "medicine")
        {
            if(health < 100)
            {
                prompt.text = "+10 health points";
                Destroy(other.gameObject);

                health += increase_hlth;
                slider.value = health;

                Invoke("settext", 2);
            }
            
        } 

        if(other.tag == "bad_medecine")
        {
            if (health > 50)
            {
                prompt.text = "You lost half your health because you picked up an harmful medecine !";
                Destroy(other.gameObject);
            }
            else if (health <= 50)
            {
                prompt.text = "You died !";
                Destroy(other.gameObject);
            }
            

            health -= 50;
            slider.value = health;
            Invoke("settext", 3);
        }
    }

    void Start()
    {
        StartCoroutine("reducehealth");
    }
    IEnumerator reducehealth()
    {
        yield return new WaitForSeconds(1F);
        health -= 1;
        slider.value = health;
        StartCoroutine("reducehealth");
    }
}
