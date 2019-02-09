using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenuUi;
    public Scenefader sceneFader;
    public string menu = "MainMenu";
    
    
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
        
    }

    void Toggle()
    {
        pauseMenuUi.SetActive(!pauseMenuUi.activeSelf);

        if (pauseMenuUi.activeSelf)
        {
            Time.timeScale = 0f;//freeze time,nothing will move in the background
        }
        else
        {
            Time.timeScale = 1f;//bring time back to normal
        }



    }

    public void Continue()
    {
        Toggle();
    }

   

    public void Retry()
    {
        CompletedLevel.nextLevelReached = false;
        
        
        Toggle();
        Time.timeScale = 1f;
        sceneFader.FadeOutofScreen(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        CompletedLevel.nextLevelReached = false;
        sceneFader.FadeOutofScreen(menu);
        Toggle();
    }
}
