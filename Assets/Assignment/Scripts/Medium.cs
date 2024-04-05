using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medium : Enemies
{
    //Referencing the slider
    public Slider slider;
    //Start is called before the first frame update
    void Start()
    {
        //Starting with 5 speed
        speed = 2;
        //Starting with 100 health which is the maxHealth
        maxHealth = 100;
        //Setting the minHealth 
        minHealth = 0;
        //Setting the health as equal to the maxHealth
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //If statement for left mouse button down for testing
        //if (Input.GetMouseButtonDown(0))
        //{
        //    //Medium enemy take 50 damage
        //    MediumTakeDamge(50);
        //}
        //If statement for when the maxHealth equals to the minHealth
        if (maxHealth <= minHealth)
        {
            //Destory this gameobject
            Destroy(gameObject);
        }
    }
    //Function for the Easy enemy to take damage
    public void MediumTakeDamge(float damage)
    {
        //Minus maxHealth when damage is taken
        maxHealth -= damage;
        //Minus the value of the slider when damage is taken
        slider.value -= damage;
        health = Mathf.Clamp(health, minHealth, maxHealth);
    }
    //Override function for damage type
    public override DamageType damage()
    {
        //Return damage type medium 
        return DamageType.Medium;
    }
}
