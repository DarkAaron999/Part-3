using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//Referencing the enum damage type Enemies, Easy, Medium, Hard
public enum DamageType { Enemies, Easy, Medium, Hard }
public class Arrow1 : MonoBehaviour
{
    //Referencing the rigidbody
    Rigidbody rb;
    //Vector2 of the enemy position
    Vector2 enemyPosition;
    //Vector2 of the bullet position
    Vector2 bulletPosition;
    //Referencing the Enemies script
    private Enemies enemies;
    //Reference for the easy damage type
    public DamageType easyDamageType;
    //Reference for the medium damage type
    public DamageType mediumDamageType;
    //Reference for the hard damage type
    public DamageType hardDamageType;
    //Start is called before the first frame update
    void Start()
    {
        //Getting the rigidbody component
        rb = GetComponent<Rigidbody>();
        //Enemies is equal gameobject with tag of Enemy get component Enemies
        enemies = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemies>();
    }
    //Function fixed update
    private void FixedUpdate()
    {
        //If statement for enemies script arrow is not equal to null
        if (enemies.arrow != null)
        {
            //Enemy position is equal to enemies transform position
            enemyPosition = enemies.transform.position;
            //Bullet position equal to transform position
            bulletPosition = transform.position;
            //Transform position equal vector3 Lerp the Bullet position Enemy position at 50f times Time.deltaTime
            transform.position = Vector3.Lerp(bulletPosition, enemyPosition, 2 * Time.deltaTime);
            //Terminates the execution
            return;
        }
        //If statement for enemies script arrow is equal to null
        if (enemies.arrow == null)
        {
            //Destroy gameobject
            Destroy(gameObject);
            //Terminates the execution
            return;
        }
    }
    //Function OnTriggerStay2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Find the distance between the Bullet position and collision transform position
        //float dist = Vector3.Distance (bulletPosition, collision.transform.position);
        //Write this in the console 
        //Debug.Log(" dist: " + dist);
        //If statement collision if gameobject has tag Enemy
        //If statement collision if gameobject has tag Enemy

        if (collision.TryGetComponent<Enemies>(out Enemies enemies))
        {
            //If statement enemies damage is equal to easy damage type or easy damage type is equal damage type enemies 
            if (enemies.damage() == easyDamageType || easyDamageType == DamageType.Enemies)
            {
                //Collision send message to easy take damage 50
                collision.SendMessage("EasyTakeDamge", 50, SendMessageOptions.DontRequireReceiver);
            }
            //If statement enemies damage is equal to medium damage type or medium damage type is equal damage type enemies
            if (enemies.damage() == mediumDamageType || mediumDamageType == DamageType.Enemies)
            {
                //Collision send message to easy take damage 75
                collision.SendMessage("MediumTakeDamge", 75, SendMessageOptions.DontRequireReceiver);
            }
            //If statement enemies damage is equal to hard damage type or hard damage type is equal damage type enemies
            if (enemies.damage() == hardDamageType || hardDamageType == DamageType.Enemies)
            {
                //Collision send message to easy take damage 25
                collision.SendMessage("HardTakeDamge", 25, SendMessageOptions.DontRequireReceiver);
            }
            //Destory gameobject
            Destroy(gameObject);
        }
    }
}
