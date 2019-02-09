using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class WavesSurvived : MonoBehaviour {

    public Text wavesScore;

    void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        
        int waves = 0;
        wavesScore.text = "0";
        yield return new WaitForSeconds(0.3f); //to complete all the animation part of the UI
        while (waves <= PlayerStats.waves)
        {
            wavesScore.text = waves.ToString();
            waves++;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
