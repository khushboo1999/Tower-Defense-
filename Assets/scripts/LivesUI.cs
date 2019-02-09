using UnityEngine.UI;
using UnityEngine;

public class LivesUI : MonoBehaviour {

    public Text livesText;    
   

    void Update()
    {
        if (PlayerStats.lives < 0)
            return;

        if(PlayerStats.lives==1)
        livesText.text = PlayerStats.lives +" LIFE";

        else
          livesText.text = PlayerStats.lives + " LIVES";

    }
}
