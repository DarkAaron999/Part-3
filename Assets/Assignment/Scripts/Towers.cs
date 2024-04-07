using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using System;

public class Towers : MonoBehaviour
{
    //Referencing the enemy gameobject
    public GameObject enemy;
    //Referencing the transform tower
    public Transform tower;
    //A private float for shooting time
    public float shootingTime;
    //A public float for shoot timer
    public float shootTimer;
    //Referencing the radius gamobject
    public GameObject radius;
    bool isSelected;
    //Start is called before the first frame update
    void Start()
    {
        //Turn off the radius at start
        radius.SetActive(false);
        //Set the shoot timer to 0 at start
        shootTimer = 0;
    }
    //Function for selected bool value
    public void Selected(bool value)
    {
        //IsSelected euqal value
        isSelected = value;
    }

    //Update is called once per frame
    void Update()
    {
        //Get the mouse position to camera
        Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    //Function for OnTriggerStay2D when a gameobject stays in collision
    private void OnTriggerStay2D(Collider2D collision)
    {
        //If statement collision if gameobject has tag Enemy
        if (collision.CompareTag("Enemy"))
        {
            //Enemy equal collision gameobject
            enemy = collision.gameObject;
        }
        //If statement enemy is not equal to null
        if (enemy != null)
        {
            //Enemy equal enemy gameobject
            enemy = enemy.gameObject;
        }
    }
    //Function OnTriggerExit2D when a gameobject exits a collision
    private void OnTriggerExit2D(Collider2D collision)
    {
        //If statement enemy equal null
        if (enemy = null)
        {
            //Enemy equal enemy gameobject
            enemy = enemy.gameObject;
        }
    }
    //Function OnMouseOver
    private void OnMouseOver()
    {
        //If statement when left mouse button down 
        if (Input.GetMouseButtonDown(0))
        {
            //Radius turn on gameobject
            radius.SetActive(true);
        }
        //If statement when right mouse button down
        if (Input.GetMouseButtonDown(1))
        {
            //Radius turn off gameobject
            radius.SetActive(false);
        }
    }
}
