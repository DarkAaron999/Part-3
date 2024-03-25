using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Drawing;

public class CharacterControl : MonoBehaviour
{
    public TMPro.TextMeshProUGUI currentSelection;
    public static CharacterControl Instance;
    public TMP_Dropdown dropdown;
    public List<GameObject> availableVillagers;

    public void Start()
    {
        Instance = this;

        // availableVillagers = new List<GameObject>();

        dropdown.ClearOptions();
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();

        for (int i = 0; i < availableVillagers.Count; i++)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData(availableVillagers[i].name);
            options.Add(option);
        }
        dropdown.AddOptions(options);
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

        SetSelectedVillager(availableVillagers[value].GetComponent<Villager>());
    }

    public void OnValueChange(float size)
    {
        if (SelectedVillager != null)
        {
            SelectedVillager.transform.localScale = new Vector3(size, size, size);
        }
    }

    private void Update()
    {
        if (SelectedVillager != null)
        {
            currentSelection.text = SelectedVillager.GetType().ToString();
        }
    }
}
