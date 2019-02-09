using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    public string levelToLoad = "SelectLevel";
    public Scenefader sceneFader;
    public Button resetButton;

    private void Start()
    {
        resetButton.interactable = true;
        FindObjectOfType<AudioManager>().PlaySound("BackgroundMusic");
    }
    public void Play()
    {
        sceneFader.FadeOutofScreen(levelToLoad);
       
    }

    public void Quit()
    {
        Debug.Log("Exiting...!");
        Application.Quit();
    }

    public void Resett()
    {
        PlayerPrefs.SetInt("LevelToReach", 1);
        resetButton.interactable = false;

    }



}
