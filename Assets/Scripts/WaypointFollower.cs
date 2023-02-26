using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{

    //array of waypoints which are GameObjects that represeent position in the scene
    [SerializeField] private GameObject[] waypoints;

    //keeping track of which waypoint the object is currently moving towards.
    private int currentWaypointIndex = 0;

    //speed of object/increase-decrase
    [SerializeField] private float speed = 4f;

    //set position frame for frame
    // Update is called once per frame
    private void Update()
    {
        //checks the distance between object's position and position of the current waypoint
        //if distance less than 1.f, it increments the current waypoint so it moves towards other waypoint.
        if(Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if(currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        //Vector2.MoveTowards is a function that calculates a new position between two positions, based on specified speed.
        //function takes 3 arguments, current position, target position, speed.
        //It updates the position of the GameObject to move towards to current waypoint.
        //This line updates position of the GameObject each frame, moving it closer to the current waypoint.
        transform.position = Vector2.MoveTowards(transform.position,waypoints[currentWaypointIndex].transform.position, Time.deltaTime*speed);
    }
}
