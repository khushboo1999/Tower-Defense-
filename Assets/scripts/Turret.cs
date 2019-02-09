 using UnityEngine;

public class Turret : MonoBehaviour {
    private Transform target;
    private Enemy targetEnemyScript;
    

    [Header("General")]
    public float range = 15f;

    private string enemyTag = "Enemy";

    [Header("Use bullet(default)")]
    public float fireRate = 5f;
    public float turnSpeed = 10f;
    private float fireCountdown = 0f;

    [Header("use Missile")]
    public bool useMissileUpgrade = false;
    public GameObject missileLaunchEffecct;
       

    [Header("Use Laser")]
    public bool useLaser = false;
    public float damageOverTime = 20f;
    public float speedDecreasePct = 0.3f;
    public LineRenderer lineRenderer;
    public ParticleSystem laserEffect;
    public Light impactLight;

    [Header("Unity Setup Fields")]    
    public Transform partToRotate;
    public GameObject bulletPrefab;
    public Transform firePoint;
    

	// Use this for initialization
	void Start () {
     
        InvokeRepeating("UpdateTarget", 0f, 0.2f);
        //repeat updateTarget function with a delay of 0 and repeat rate of 2 times per sec
	}

	
	void UpdateTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        /*creating an array of gameobject(in gameonject all components are included and not just transfrom) which contains all
         gameobjects with enemyTag*/
        GameObject nearestEnemy = null; 
        float shortestDistance = Mathf.Infinity ;
        
        foreach (GameObject enemy in enemies)//checking each enemy one by one
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy <= shortestDistance)
            {
                shortestDistance = distanceToEnemy;//finding the shortest distance to enemy
                nearestEnemy = enemy;//assigning that shortest distance enemy as nearest enemy
            }
            

            if (nearestEnemy!=null && shortestDistance <= range)
            {
                 target = nearestEnemy.transform;//if shortest distance is within range make it target
                targetEnemyScript = nearestEnemy.GetComponent<Enemy>();
        }
            else
            {
                target = null;
            }
        }
       
		
	}

    void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;//components are enabled
                    laserEffect.Stop();//particle systems are played or stopped
                    impactLight.enabled = false;
                }

            }

            return; //if there is no target then do not proceed in this code and return to next function
        }

        LockTargetOn();
        if (useLaser)
        {
            LaunchLaser();

        }
        else
        {

            if (fireCountdown <= 0f)
            {
                Shoot();
                if (useMissileUpgrade)
                {
                    GameObject missileEffect = (GameObject)Instantiate(missileLaunchEffecct, firePoint.position, firePoint.rotation);
                    Destroy(missileEffect, 1);
                }
                fireCountdown = 1f / fireRate;//the time between two fires
            }

            fireCountdown -= Time.deltaTime;
        }
    } 

    void LockTargetOn()
    {
        Vector3 dir = target.position - transform.position;//finding the direction in which we need to rotate
        Quaternion lookrotation = Quaternion.LookRotation(dir);
        //quaternion are used to represent rotations and here it is creating a way of turning the turret in the desired rotation 

        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookrotation, Time.deltaTime * turnSpeed).eulerAngles;
        //converting lookrotation into euler angles so that we can separately work on x,y,z axes and lerp is used to smoothen the rotation from a to b
        //saving all this in rotation variable 

        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        //we want roation only about the y axis

    }
    void Shoot()
    {
                  
        GameObject BulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);//saving the bullet prefab in a variable
        Bullet bullet = BulletGO.GetComponent<Bullet>(); //taking the Bullet script component and saving it in Bullet variable type

        if (bullet != null) //checking if there exists a script
        {
            
            bullet.Seek(target);//passing the variable target to Bullet script seek void
           
        }

    }
    

    void LaunchLaser()
    {

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            laserEffect.Play();
            impactLight.enabled = true;

            return;
        }

        targetEnemyScript.TakeDamage(damageOverTime * Time.deltaTime);//the damage causing to the enemy every sec
        targetEnemyScript.Slow(speedDecreasePct);

        lineRenderer.SetPosition(0, firePoint.position);//initial position
        lineRenderer.SetPosition(1, target.position);//second and here last position 

        //laser impact effect position and rotation
        Vector3 dir = firePoint.position - target.position;
        laserEffect.transform.position = target.position + dir.normalized * 1.3f;
        laserEffect.transform.rotation = Quaternion.LookRotation(dir);


    }
    private void OnDrawGizmosSelected() //pre-defined function 
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }//a wired sphere around the turret and transform.position tells the centre and range gives the radius
}
