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
    Vector3 minScale;
    public Vector3 maxScale;
    public float buildSpeed = 2f;
    public float time = 1;
    // Start is called before the first frame update
    void Start()
    {
        building = StartCoroutine(Build());
    }

    IEnumerator Build()
    {
        minScale = transform.localScale;

        transform.localScale = Vector3.Lerp(maxScale, minScale, time);
        Instantiate(buildingPrefab1, spawnPoint1.position, spawnPoint1.rotation);
        yield return new WaitForSeconds(5);
        Instantiate(buildingPrefab2, spawnPoint2.position, spawnPoint2.rotation);
        yield return new WaitForSeconds(5);
        Instantiate(buildingPrefab3, spawnPoint3.position, spawnPoint3.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        time += 1 * Time.deltaTime;
    }
}
