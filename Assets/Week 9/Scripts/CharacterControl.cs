using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterControl : MonoBehaviour
{
    public TextMeshProUGUI villagerTypeText;
    public static Villager SelectedVillager { get; private set; }
    public static void SetSelectedVillager(Villager villager)
    {
        if(SelectedVillager != null)
        {
            SelectedVillager.Selected(false);
        }
        SelectedVillager = villager;
        SelectedVillager.Selected(true);

        Debug.Log (villager.gameObject.name);
    }

    public void Update()
    {
        if (SelectedVillager == false)
        {
            villagerTypeText.text = "Unselected";
        }
        else
        {
            villagerTypeText.text = SelectedVillager.gameObject.name;
        }
    }
}
