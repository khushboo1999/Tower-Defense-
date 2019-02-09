using UnityEngine;

public class GameCompleted : MonoBehaviour {

    
    public Scenefader sceneFader;
    public string menu = "MainMenu";

    public void Play ()
    {
        sceneFader.FadeOutofScreen(menu);
    }

    public void Quit()
    {
        Debug.Log("Game Over");
        Application.Quit();
    }
}
