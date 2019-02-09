using UnityEngine;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour {

    public Scenefader sceneFader;
    public Button[] levelButtons;
    

    void Start()
    {
        int LevelToReach = PlayerPrefs.GetInt("LevelToReach", 1);
        //by getInt we r taking values out of it and by setint we store and the variable inside "this" and after int need not be same
        //this is just unity's way of saying that store this 
        //data until we next open it,in some permanent storage and by default we make value 1

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > LevelToReach) 
            { //since i is starting with 0

                    levelButtons[i].interactable = false;
            }
            

        }
    }
  

    public void LoadLevel(string levelToLoad)
    {
        sceneFader.FadeOutofScreen(levelToLoad);
    }
}
