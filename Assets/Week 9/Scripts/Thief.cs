using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Thief : Villager
{
    public GameObject daggerPrefab;
    public Transform spawnPoint1;
    public Transform spawnPoint2;

    private Vector2 mousePosition;

    protected override void Attack()
    {
        mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        transform.position = mousePosition;
        destination = transform.position;
        base.Attack();
        Instantiate(daggerPrefab, spawnPoint1.position, spawnPoint1.rotation);
        Instantiate(daggerPrefab, spawnPoint2.position, spawnPoint2.rotation);     
    }
    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }
}
