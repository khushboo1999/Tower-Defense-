using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class CompletedLevel : MonoBehaviour {


    public Scenefader sceneFader;
    public string mainMenu = "MainMenu";
    public int levelToUnlock = 2;
    public string nextLevel = "Level02";
    public Text BonusMoney;
    public static bool nextLevelReached;
    
   

    void OnEnable()
    {

       
        if (levelToUnlock > PlayerPrefs.GetInt("LevelToReach", 1))
        {
            PlayerPrefs.SetInt("LevelToReach", levelToUnlock);
        }

        BonusMoney.text = "₹" + (int)PlayerStats.money / 10;      


    }
    public void Continue()
    {
        nextLevelReached = true;
        sceneFader.FadeOutofScreen(nextLevel);
    }
    public void Menu()
    {
        nextLevelReached = false;
        sceneFader.FadeOutofScreen(mainMenu);
    }
}
