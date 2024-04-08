using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hard : Enemies
{
    //Referencing the slider
    public Slider slider;
    //Referencing the PlayerMoney script
    public PlayerMoney playerMoney;
    //Start is called before the first frame update
    void Start()
    {
        //Starting with 3 maxSpeed
        maxSpeed = 2;
        //Setting the minSpeed equal to 0
        minSpeed = 0;
        //Setting the speed as equal to the maxSpeed
        speed = maxSpeed;
        //Starting with 200 health which is the maxHealth
        maxHealth = 200;
        //Setting the minHealth equal to 0 
        minHealth = 0;
        //Setting the health as equal to the maxHealth
        health = maxHealth;
        playerMoney = GameObject.FindGameObjectWithTag("PlayerCastle").GetComponent<PlayerMoney>();
    }
    // Update is called once per frame
    void Update()
    {
        //If statement for left mouse button down for testing
        //if (Input.GetMouseButtonDown(0))
        //{
        //    //Hard enemy take 50 damage
        //    HardTakeDamge(50);
        //}
        //If statement for when the maxHealth equals to the minHealth
        if (maxHealth <= minHealth)
        {
            //Destory this gameobject
            Destroy(gameObject);
            //Add 150 money to the player money
            playerMoney.money += 150;
            //Arrow set to null
            arrow = null;
        }
    }
    //Function for the Easy enemy to take damage
    public void HardTakeDamge(float damage)
    {
        //Minus maxHealth when damage is taken
        maxHealth -= damage;
        //Minus the value of the slider when damage is taken
        slider.value -= damage;
        health = Mathf.Clamp(health, minHealth, maxHealth);
    }
    //Function for the enemy freeze
    public void EnemyFreeze(float frezee)
    {
        //Misus the maxSpeed when frezeing is happening
        maxSpeed -= frezee;
        //The speed equal to mathf then the speed, minSpeed, and maxSpeed
        speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
    }
    //Function for OnTruggerEnter2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If statement for on collision find gameobject with tag "PlayerCastle"
        if (collision.CompareTag("PlayerCastle"))
        {
            //On collision player takes 25 damage
            collision.SendMessage("PlayerTakeDamage", 25, SendMessageOptions.DontRequireReceiver);
        }
    }
    //Override function for damage type
    public override DamageType damage()
    {
        //Return damage type hard
        return DamageType.Hard;
    }
}
