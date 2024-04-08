using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenTower : Towers
{
    //A float for the freezeDuration
    public float freezeDuration;
    //Bool for isFrozen equal false
    bool isFrozen = false;
    //Start is called before the first frame update
    void Start()
    {
        //Freeze Duration is set to 1 at start
        freezeDuration = 1f;
        radius.SetActive(false);
    }
    //Update is called once per frame
    void Update()
    {
        //If statement SelectedTowers is equal null
        if (enemy == null)
            //Terminates the execution
            return;
        //Shooting timer minus equal Time.deltaTime
        shootTimer -= Time.deltaTime;
    }
    //Function for coroutine for freezing
    IEnumerator Freezing(Collider2D collision)
    {
        //isFrozen set true
        isFrozen = true;
        //For testing write Freezing in the console
        Debug.Log("Freezing");
        //On collision send message "EnemyFreeze" take off 1
        collision.SendMessage("EnemyFreeze", 1, SendMessageOptions.DontRequireReceiver);
        //Completes the list then waits for seconds
        yield return new WaitForSeconds(freezeDuration * Time.deltaTime);
        //isFrozen set false
        isFrozen = false;
        //For testing write Stop Freezing in the console
        Debug.Log("Stop Freezing");
        //Completes the list then return null
        yield return null;
    }
    //Function OnTriggerEnter2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If statement shoottimer is less than or equal to 0f 
        if (shootTimer <= 0f && isFrozen == false)
        {
            //Start thr coroutine
            StartCoroutine(Freezing(collision));
            //Shooting timer equal to 1f haft shooting time
            shootTimer = 1f / shootingTime;
        }
    }
}
