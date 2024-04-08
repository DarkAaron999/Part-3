using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //Referencing the slider
    public Slider slider;
    //A public float for maxHealth
    public float maxHealth;
    //A public float for minHealth
    public float minHealth;
    //A public float for health
    public float health;
    //Start is called before the first frame update
    void Start()
    {
        //maxHealth is set to 500 at start
        maxHealth = 500;
        //minHealth is set to 0 at start
        minHealth = 0;
        //health equals maxHealth
        health = maxHealth;
    }
    //Function for Player Take Damage
    public void PlayerTakeDamage(float damage)
    {
        //Minus the maxHealth to the float damage number
        maxHealth -= damage;
        //Minus the slider value to the float damage number
        slider.value -= damage;
        //The health equal to mathf then the health, minHealth, and maxHealth
        health = Mathf.Clamp(health, minHealth, maxHealth);
    }
}
