using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Villager
{
    public GameObject arroePrefab;
    public Transform spawnPoint;
    protected override void Attack()
    {
        destination = transform.position;
        base.Attack();
        Instantiate(arroePrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
