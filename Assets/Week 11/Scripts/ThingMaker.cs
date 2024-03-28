using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingMaker : MonoBehaviour
{
    public GameObject ThingPrefab;
    List<Thing> thingList = new List<Thing>();
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go = Instantiate(ThingPrefab);
            thingList.Add(go.GetComponent<Thing>());
        }

        foreach(Thing thing in thingList)
        {
            Debug.Log(thing.ToString() + " " + Thing.staticNumber);
        }
    }
}
