using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class CollectCoin : MonoBehaviour
{

    public int score;
    public TextMeshProUGUI coinText;
    public PlayerController playerController;



    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Coin"))
        {
            AddCoin();
            //Debug.Log("Collect Coin");
            Destroy(other.gameObject);
        }

        else if 
        (other.CompareTag("End"))
        {
            playerController.runningSpeed=0;
            // Debug.Log("Congrats");

        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Collision"))
        {
            //Debug.Log("Obstacle");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddCoin()
    {
        score++;
        coinText.text= "Score: " + score.ToString();
    }

}
