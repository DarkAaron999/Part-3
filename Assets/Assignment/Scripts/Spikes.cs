using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    //Referening the rigidbody2D
    Rigidbody2D rb;
    //Reference for spiketower script
    public SpikeTower spikeTower;
    //A float for the speed
    public float speed;
    //Reference for the easy damage type
    public DamageType easyDamageType;
    //Reference for the medium damage type
    public DamageType mediumDamageType;
    //Reference for the hard damage type
    public DamageType hardDamageType;
    //Start is called before the first frame update
    void Start()
    {
        //Getting the component for rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }
    //Function for fixed update applys changes over time
    private void FixedUpdate()
    {
        //Moves the transform of the gameobjects rigidbody2D up in vector2 
        rb.MovePosition(rb.position + (Vector2)transform.up * speed * Time.deltaTime);
        //Destoys the gameobject in 5 frames
        Destroy(gameObject, 5f);
    }
    //Function for OnTriggerStay2D
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Find the distance between the Bullet position and collision transform position
        //float dist = Vector3.Distance (bulletPosition, collision.transform.position);
        //Write this in the console 
        //Debug.Log(" dist: " + dist);

        //If statement for collision try get component enemies out Enemies enemies
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
