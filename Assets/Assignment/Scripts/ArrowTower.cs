using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTower : Towers
{
    //Referencing the transform barrel
    public Transform barrel;
    //Referencing the bullet prefab gameobject
    public GameObject ArrowPrefab;
    //Update is called once per frame
    void Update()
    {
        //If statement SelectedTowers is equal null
        if (enemy == null)
            //Terminates the execution
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
    //Function for shooting
    public void Shooting()
    {
        //Write this in the console
        Debug.Log("Shooting");
        //Spawns the ArrowPrefab at the barrrl position and rotation 
        Instantiate(ArrowPrefab, barrel.position, barrel.rotation);
    }
}
