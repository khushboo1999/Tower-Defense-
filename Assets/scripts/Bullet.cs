using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;
    public float speed = 70f;
    public GameObject bulletImpactEffect;
    public float explosionRadius;
    public int damage = 50;
   
 
    
    public void Seek(Transform _target)
    {
        target = _target; // accessing the target stored in turret script and storing it in another variable
      
    }
	
	// Update is called once per frame
	void Update () {
        if (target == null) //if targets goes out of range till we reach this code,then destroy it
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position; //defining the direction in which bullet needs to move
         float distanceThisFrame = speed * Time.deltaTime; //it is the distance bullet can move in this frame
            if (dir.magnitude <= distanceThisFrame) // dir.magnitude is the actual distance between bullet and enemy
        {
            HitTarget(); //if the actual distance is less than the distance bullet can travel in this frame then hit the target
            return;
        }
        transform.Translate(dir .normalized * distanceThisFrame, Space.World);//else just cover the distance this bullet can travel in this frame
        transform.LookAt(target);//look at target and then move
	}
    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(bulletImpactEffect, transform.position, transform.rotation);//instantiate bulletimpact effect
        Destroy(effectIns, 2f); //destroy that effect after 2 sec

        if (explosionRadius > 0f)//checking if it is missile launcher or standard turret prefab as only in missile launcher rad is greater than 0
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject); //destroy bullet
        return;


    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);//save all the colliding gameobjects within or on the sphere in colliders array
        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Enemy")//if the collider is enemy
            {
                Damage(collider.transform);
            }
           
        }

    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();//saving the script Enemy of the enemy gameobject in e
        if (e != null)
        {
            e.TakeDamage(damage);//passing  value to take damage void of Enemy script
        }
        
         
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,explosionRadius);
    }
}
