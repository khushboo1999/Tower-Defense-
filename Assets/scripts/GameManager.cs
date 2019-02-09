using UnityEngine;


public class GameManager : MonoBehaviour {

    public static bool gameIsOver ;
    public GameObject gameOverUI;
    public GameObject completeLevelUI;
    public GameObject gameCompletedUI;
    public Scenefader sceneFader;
    public bool lastLevel = false;
   
    

    void Start()//called everytime we load a new scene
    {
        gameIsOver = false;
       
    }
    void Update()
    {
        if (gameIsOver)
        {
           return;

        }
           

        if(Input.GetKeyDown("e"))
            EndGame();

        if (PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
         gameIsOver = true;
        gameOverUI.SetActive(true);//show the game over UI on the screen
    }

    public void LevelWon()
    {

        if (!lastLevel)
        {
            gameIsOver = true;
           
            completeLevelUI.SetActive(true);
        }
        
          else 
          GameCompleted();
    }


    public void GameCompleted()
    {
        gameIsOver = true;
        gameCompletedUI.SetActive(true);

    }
}
