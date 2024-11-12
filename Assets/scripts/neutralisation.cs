using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class neutralisation : MonoBehaviour
{
    public Transform player;
    public Transform bacteria;
    public GameObject bacteria_obj;
    public GameObject player_obj;
    public TextMeshProUGUI prompt;
    public GameManager gameManager;
    public TextMeshProUGUI virusNumber;
    public int noviruses = 7;
    bool won = false;
    // Start is called before the first frame update

    private void Start()
    {
        virusNumber.text = noviruses.ToString();
        
    }

    void Update()
    {
        if(noviruses == 0 && won == false)
        {
            won = true;
            gameManager.winGame();
        }
        
    }


    void endGame()
    {
        Debug.Log("Game over");
        player_obj.GetComponent<CubeMovement>().enabled = false;
    }

    private void settext()
    {
        prompt.text = "";
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "bacteria")
        {
            prompt.text = "You have succesfully neutralised a virus";

            noviruses -= 1;

            virusNumber.text = noviruses.ToString();

            Destroy(collision.gameObject);

            Invoke("settext", 4);
            
        }


    }


}
