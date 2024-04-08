using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class SpawnEnemy : MonoBehaviour
{
    //Referencing a list of gameobjects
    public GameObject[] enemyPrefab;
    //Referencing the transform of the spawn point
    public Transform spawnPoint;
    //A int for the waves of enemies
    private int wavesOfEnemies = 0;
    //A float for the spawn Timer 
    public float spawnTimer;
    //A float set at 5 for the spawn timer target
    public float spawnTimerTarget = 5;
    //Seting the booloen for spawning at false
    bool spawning = false;
    //Getting the coroutine
    Coroutine coroutine;
    //Referencing the timer text
    public TextMeshProUGUI timerText;

    //Start is called before the first frame update
    void Start()
    {
        //At start set the spawn timer at 5
        spawnTimer = 5;
        //timer text is equal to spawn timer
        timerText.text = spawnTimer.ToString("N0");
    }
    // Update is called once per frame
    void Update()
    {
        //timer text is equal to spawn timer
        timerText.text = spawnTimer.ToString("N0");
        //If statement if spawning is equal to true
        if (spawning == true)
        {
            //Increase the spawn time by Time.deltatime
            spawnTimer -= Time.deltaTime;
        }
    }
    //SpawnIn coroutine function
    IEnumerator SpawnIn()
    {
        //Increase the waves of enemies
        wavesOfEnemies++;
        //For loop to go to the next waves of enemies
        for (int i = 0; i < wavesOfEnemies; i++)
        {
            //For loop to go to the next enemy prefab
            for (i = 0; i < enemyPrefab.Length; i++)
            {
                //Wait for 5f
                yield return new WaitForSeconds(spawnTimerTarget);
                //Spawn in the enemy prefab at the spawn point
                Instantiate(enemyPrefab[i], spawnPoint.position, spawnPoint.rotation);
                //Set the spawn timer to 5
                spawnTimer = 5;
            }
            //Set the spawning to false
            spawning = false;
            //Return
            yield return null;
        }
    }
    //Function for spawning
    public void Spawning()
    {
        //If statement for the coroutine is not equal to null
        if (coroutine != null)
        {
            //Stop the coroutine
            StopCoroutine(coroutine);
            //Set the spawn timer to 5
            spawnTimer = 5;
        }
        //Set the spawning to true
        spawning = true;
        //Start the coroutine
        StartCoroutine(SpawnIn());
        //Set the spawn timer to 0
        spawnTimer = 5;
        //Debug for testing
        Debug.Log("SpawnStarting");
    }
}
