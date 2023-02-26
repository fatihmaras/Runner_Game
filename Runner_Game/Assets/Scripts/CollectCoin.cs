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
    public int maxScore;
    public Animator playerAnim;
    public GameObject player;
    public GameObject endPanel;

    
     void Start() 
    {
        playerAnim=player.GetComponentInChildren<Animator>();
    }
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
            transform.Rotate(transform.rotation.x, 180 ,transform.rotation.z, Space.Self);
            endPanel.SetActive(true);

            if(score>=maxScore)
            {
                //Debug.Log("You win");
                playerAnim.SetBool("win",true);
            }

            else
            {
                //Debug.Log("You Lose");
                playerAnim.SetBool("Lose",true);
            }

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


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
