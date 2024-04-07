using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTower : Towers
{
    //Referencing the transform barrels
    public Transform barrel1;
    public Transform barrel2;
    public Transform barrel3;
    public Transform barrel4;
    public Transform barrel5;
    public Transform barrel6;
    public Transform barrel7;
    public Transform barrel8;
    //Referencing the spike prefab gameobject
    public GameObject spikePrefab;
    //Update is called once per frame
    void Update()
    {
        //If statement for enemy is equal to null
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
        //Sapwn in bullet prefab at barrel position and rotation
        Instantiate(spikePrefab, barrel1.position, barrel1.rotation);
        Instantiate(spikePrefab, barrel2.position, barrel2.rotation);
        Instantiate(spikePrefab, barrel3.position, barrel3.rotation);
        Instantiate(spikePrefab, barrel4.position, barrel4.rotation);
        Instantiate(spikePrefab, barrel5.position, barrel5.rotation);
        Instantiate(spikePrefab, barrel6.position, barrel6.rotation);
        Instantiate(spikePrefab, barrel7.position, barrel7.rotation);
        Instantiate(spikePrefab, barrel8.position, barrel8.rotation);
    }
}
