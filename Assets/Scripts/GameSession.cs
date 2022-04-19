using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    void Awake()
    {
       int numGameSessions = FindObjectsOfType<GameSession>().Length;
       if (numGameSessions > 1)
       {
           Destroy(gameObject);
       } 
       else
       {
           DontDestroyOnLoad(gameObject);
       }
    }

   void Start() 
   {

       livesText.text = playerLives.ToString();
   }
    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        } 
    }
    void TakeLife()
    {
        playerLives = playerLives - 1;
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex);
    }
    
    void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
