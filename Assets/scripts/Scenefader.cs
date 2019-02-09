using System.Collections;//for starting Coroutine
using UnityEngine.UI;//for using Image
using UnityEngine.SceneManagement;//for loading scenes
using UnityEngine;

public class Scenefader : MonoBehaviour
{

    public Image img;
    public AnimationCurve curve;
    public string SceneToLoad = "Level01";

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeOutofScreen(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }


    IEnumerator FadeIn()
    {
        float t = 1f;
      

        while (t > 0f)
        { 
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);//take x axis as t which can be time only
            img.color = new Color(0.1897795f, 0.06261124f, 0.1981132f, a);
            yield return 0;//wait for next frame and then pass control to next statement

        }
        

    }
    
    IEnumerator FadeOut(string scene)
    {
        float t = 0f;
     

        while (t < 1f)
        {
            
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0.1897795f, 0.06261124f, 0.1981132f, a);
            yield return 0;//wait for next frame and then pass control to next statement

        }
        SceneManager.LoadScene(scene);

    }

}
