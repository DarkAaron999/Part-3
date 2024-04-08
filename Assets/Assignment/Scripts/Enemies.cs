using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    //Referencing the rigidbody
    Rigidbody2D rb;
    //Referencing the list of gameobjects/Waypoints
    public GameObject[] waypoints;
    //A float for speed
    public float maxSpeed;
    //A float for speed
    public float minSpeed;
    //A float for speed
    public float speed;
    //A float for maxHealth for the enemies
    public float maxHealth;
    //A float for minHealth for the enemies
    public float minHealth;
    //A float for health for the enemies
    public float health;
    //A int for the target to waypoint equal 0
    public int targetToWaypoint = 0;
    public Arrow1 arrow;
    //Start is called before the first frame update
    void Start()
    {
        //Getting the rigidbody component 
        rb = GetComponent<Rigidbody2D>();
        //The tranform position is equal to the waypoint target to waypoint tranform position
        transform.position = waypoints[targetToWaypoint].transform.position;
    }
    //Fixed update function
    private void FixedUpdate()
    {
        //Transform position of the enemies is equal to vector 3 move toward transform position of the enemies then the waypoints target to waypoint transform position then speed times Time.deltaTime
        transform.position = Vector3.MoveTowards(transform.position, waypoints[targetToWaypoint].transform.position, speed * Time.deltaTime);
        //If statement for the transform position is equal to the waypoints target to waypoint transform position 
        if (transform.position == waypoints[targetToWaypoint].transform.position)
        {
            //Increase the target to waypoint 
            targetToWaypoint++;
            //If statement for the target to waypoint is equal to 6
            if (targetToWaypoint == 6)
            {
                //Destory the gameobject
                Destroy(gameObject);
                //Arrow set to null
                arrow = null;
            }
        }
    }
    //Override function for damage type
    public virtual DamageType damage()
    {
        //Return damage tyoe enemies
        return DamageType.Enemies;
    }
}
