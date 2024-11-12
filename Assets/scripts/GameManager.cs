using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float gamerestartDelay = 3f;
    public GameObject player;
    public neutralisation neu;
    public TextMeshProUGUI wonloss;


    public void endGame()
    {
        if (gameHasEnded == false)
        {
            wonloss.text = "YOU LOST ! The game will automatically restart in 3 seconds";
            gameHasEnded = true;
            Debug.Log("Game Over");
            Invoke("Restart", gamerestartDelay);
            player.GetComponent<CubeMovement>().enabled = false;
        }


    }

    public void winGame()
    {
       Debug.Log("You won !");

        wonloss.text = "YOU WON!";

        Invoke("newgame", 3);

        
    }

    public void Restart()
    {

        wonloss.text = "";
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void newgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
