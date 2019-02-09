using UnityEngine;
using System.Collections; // for IEnumerator
using UnityEngine.UI; //for text

public class WaveSpawner : MonoBehaviour {
    
    public static int enemiesAlive = 0;
   
    public Waves[] waves;

    public Transform spawnPoint;
    public Text waveCountdownText;
    
    public float timeBetweenWaves = 5f;
    private float countdown =20f;
    public GameManager gameManager;

    private int waveIndex = 0;


    // Update is called once per frame
    private void Start()
    {
       enemiesAlive = 0;
    }

    void Update ()
    {
       
        if (enemiesAlive > 0)
            return;


        if (waves.Length == waveIndex && enemiesAlive==0)
        {
            gameManager.LevelWon();
            this.enabled = false;
        }



        if (countdown <= 0f)
                 {
                       StartCoroutine(SpawnWave()); //it's the way of calling an IEnumerator type of function
                
                       countdown = timeBetweenWaves;
                        return;
            
                 }
        countdown -= Time.deltaTime;
        

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format( "{0:00.00}",countdown);


    }

    IEnumerator SpawnWave() /*used to wait for few seconds before going to next iteration of loop and to use this we must add file using
        system.collections*/
    {
        PlayerStats.waves = waveIndex+1;
        Waves wave = waves[waveIndex];
        enemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate); // this is to wait for few seconds before going to next line of code
            
        }
        
        waveIndex++;
       

        

    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);// creates an enemy everytime we call it
      
    }
}
