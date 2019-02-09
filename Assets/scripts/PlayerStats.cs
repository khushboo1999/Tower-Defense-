using UnityEngine;

public class PlayerStats : MonoBehaviour {

    
    public static int money ;
    public int startMoney = 500;
     
    public int startLives = 20;
    public static int lives ;
    public static int waves;

    void Start()//called everytime we load a scene
    {
        if (CompletedLevel.nextLevelReached)
        {
            money = startMoney + money / 10;
        }
        else money = startMoney;
      
        lives = startLives;
        waves = 0;
    }

}
