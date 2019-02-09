using UnityEngine;


[RequireComponent(typeof(Enemy))]
  public class EnemyMovement : MonoBehaviour {


    private Transform target;
    private int wayPointIndex = 0;
    private Enemy enemy;



    // Use this for initialization
    void Start()
    {
        target = Waypoints.points[0]; //making first waypoint as target
        enemy = GetComponent<Enemy>();
     
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position; //defining the direction in which transform i.e enemy here needs to move to reach it's waypoint
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        /*translating or moving the enemy in that particular direction which is normalized i.e magnitude is 1 ,speed 
          is what we have set and multiplying with Time.deltaTime to remove dependence on frames per sec and ,moving acc
          to time and second factor space world is to tell relative to space we need to move i.e general motion */
        //basically Translate(dir,relative motion)

        if (Vector3.Distance(transform.position, target.position) <= 1f)
        /*due to some mathematical errors sometimes even enemy is at the waypoint computer doesn't count
         it hence giving a range to have smooth coding*/
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;//since all the updates are not called at once,so first update of say this script is called
        //speed will be normal then turret's update will be called ,speed will decrease if using laser then this update will be called and speed will be normal again
    }



    void GetNextWaypoint()
    {
        if (wayPointIndex >= Waypoints.points.Length - 1) //if waypoints are exhausted
        {
            PathEnded();
            return;
            /*this return is added since code destroy takes time and in that time control moves to 
              waypointindex increment which will give an error since we have reached the limit thus to
              move control out of this void we have added return*/

        }
        wayPointIndex++;
        target = Waypoints.points[wayPointIndex]; // settin the target at next waypoint


    }


    void PathEnded()
    {
        PlayerStats.lives--;//deduct one life if enemy reaches the end point
        WaveSpawner.enemiesAlive--;
        Destroy(gameObject);
    }
}
