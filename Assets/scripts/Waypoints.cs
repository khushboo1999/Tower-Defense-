using UnityEngine;

public class Waypoints : MonoBehaviour {

    public static Transform[] points;

    void Awake()
    {
        points = new Transform[transform.childCount];//here we are declaring the size pf array points 
        /* new is added Before transform to create a copy of value at transform i.e location of different waypoints
         so that whatever changes we make in points variable does not affect the original value of transform */
        for(int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i); //setting each child i.e waypoint as an element of array of points
        }
    }
    
}
