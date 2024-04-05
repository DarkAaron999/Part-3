using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Towers : MonoBehaviour
{
    //Referencing the enemy gameobject
    public GameObject enemy;
    //Referencing the transform barrel
    public Transform barrel;
    //Referencing the transform tower
    public Transform tower;
    //Referencing the bullet prefab gameobject
    public GameObject bulletPrefab;
    //A private float for shooting time
    private float shootingTime;
    //A public float for shoot timer
    public float shootTimer;
    //Referencing the radius gamobject
    public GameObject radius;
    // Start is called before the first frame update
    void Start()
    {
        //Turn off the radius at start
        radius.SetActive(false);
        //Set the shooting time to 1 at start
        shootingTime = 1;
        //Set the shoot timer to 0 at start
        shootTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Get the mouse position to camera
        Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //If statement is equal to null then return
        if (enemy == null)
            return;
        //If statement shoottimer is less than or equal to 0f 
        if (shootTimer <= 0f)
        {
            //Call the shooting function
            Shooting();
            //Shooting timer equal to 1f haft shooting time
            shootTimer = 1f / shootingTime;
        }
        //Shooting timer minus equal Time.deltaTime
        shootTimer -= Time.deltaTime;
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
    //Function for shooting
    public void Shooting()
    {
        //Write this in the console
        Debug.Log("Shooting");
        //Sapwn in bullet prefab at barrel position and rotation
        Instantiate(bulletPrefab, barrel.position, barrel.rotation);
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
