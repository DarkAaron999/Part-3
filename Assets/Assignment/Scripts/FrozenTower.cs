using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenTower : Towers
{
    //A float for the freezeDuration
    public float freezeDuration;
    //Bool for isFrozen equal false
    bool isFrozen = false;
    //Function for coroutine for freezing
    IEnumerator Freezing()
    {
        //isFrozen set true
        isFrozen = true;
        //For testing write Freezing in the console
        Debug.Log("Freezing");
        //Completes the list then waits for seconds
        yield return new WaitForSeconds(freezeDuration);
        //isFrozen set false
        isFrozen = false;
        //Completes the list then return null
        yield return null;
    }
    //Function OnTriggerEnter2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Starts the coroutine freezing
        StartCoroutine(Freezing());
        //If statement for isFrozen is equal to true
        if (isFrozen == true)
        {
            //On collision send message "EnemyFreeze" take off 1
            collision.SendMessage("EnemyFreeze", 1f, SendMessageOptions.DontRequireReceiver);
        }
    }
}
