using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class CharacterControl : MonoBehaviour
{
    public TMPro.TextMeshProUGUI currentSelection;
    public static CharacterControl Instance;
    public TMP_Dropdown dropdown;
    public List<GameObject> availableVillagers;

    public void Start()
    {
        Instance = this;

        availableVillagers = new List<GameObject>();
    }
    public static Villager SelectedVillager { get; private set; }
    public static void SetSelectedVillager(Villager villager)
    {
        if(SelectedVillager != null)
        {
            SelectedVillager.Selected(false);
        }
        SelectedVillager = villager;
        SelectedVillager.Selected(true);
        Instance.currentSelection.text = villager.ToString();
    }

    public void DropdownHasChangedValuse(int value)
    {
        Debug.Log(value + "character been selected");
        //SelectedVillager = availableVillagers[value];
    }

    //private void Update()
    //{
    //if(SelectedVillager != null)
    //{
    //currentSelection.text = SelectedVillager.GetType().ToString();
    //}
    //}
}
