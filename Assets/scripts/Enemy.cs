using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {


    public float startSpeed = 30f;

    [HideInInspector]
    public float speed;

    public float startHealth= 100;
    private float Health;
    public int worth = 20;

    public GameObject enemyDeathEffect;
    private bool isDead = false;

    [Header("Unity Stuff")]
    public Image healthBar;


    public void Start()
    {
        speed = startSpeed;
        Health = startHealth;
    }


    public void TakeDamage(float amount)
    {
        Health -= amount;//decrease this much amount everyTime this is called
        healthBar.fillAmount = Health/startHealth;//since the healthbar can only show values between 0 and 1 so bringing health in fractions

        if (Health <= 0 && !isDead)
            Die();
    }


    void Die()
    {
       isDead = true;
        PlayerStats.money += worth;

       GameObject effect = (GameObject)Instantiate(enemyDeathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 3f);

        FindObjectOfType<AudioManager>().PlaySound("EnemyDestroy");
        Destroy(gameObject); 
        WaveSpawner.enemiesAlive--;
        return;
        
    }

    public void Slow(float pct)
    {

        speed *= 1f - pct;//decreasing the speed of enemy
    }
}





