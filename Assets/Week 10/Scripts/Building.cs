using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Building : MonoBehaviour
{
    Coroutine building;
    public GameObject buildingPrefab1;
    public GameObject buildingPrefab2;
    public GameObject buildingPrefab3;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    float buildingTimer;
    public float time;
    float interpolation;
    // Start is called before the first frame update
    void Start()
    {
        building = StartCoroutine(Build());
    }

    IEnumerator Build()
    {
        buildingTimer += Time.deltaTime * time;

        transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);
        Instantiate(buildingPrefab1, spawnPoint1.position, spawnPoint1.rotation);
        yield return new WaitForSeconds(5);
        Instantiate(buildingPrefab2, spawnPoint2.position, spawnPoint2.rotation);
        yield return new WaitForSeconds(5);
        Instantiate(buildingPrefab3, spawnPoint3.position, spawnPoint3.rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
