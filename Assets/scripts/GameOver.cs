using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

   
    public Scenefader sceneFader;
    public string menu = "MainMenu";


    

    public void Retry()
    {
        
        sceneFader.FadeOutofScreen(SceneManager.GetActiveScene().name);
        
    }

    public void Menu()
    {
        sceneFader.FadeOutofScreen(menu);
    }
}
