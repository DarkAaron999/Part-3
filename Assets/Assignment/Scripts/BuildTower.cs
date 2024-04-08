using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTower : MonoBehaviour
{
    //Referencing the list of gameobjects
    public List<GameObject> tower;
    //Referencing the BuildTower script
    public static BuildTower Instance;
    //Referencing the PlayerMoney
    public PlayerMoney playerMoney;
    //Start is called before the first frame update
    void Start()
    {
        //Instance euqal this
        Instance = this;
    }

    //Update is called once per frame
    void Update()
    {
        //Get the mouse position to camera
        Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (playerMoney.money < 100)
        {
            //Set selected towers to null
            SelectedTowers = null;
        }
    }
    //Function for OnMouseOver
    public void OnMouseOver()
    {
        //If statement SelectedTowers is equal null
        if (SelectedTowers == null)
            //Terminates the execution
            return;
        //If left mouse press run this
        if (Input.GetMouseButton(0))
        {
            //Spawns in the selected tower gameobject to the transform position and rotation
            Instantiate(SelectedTowers.gameObject, transform.position, transform.rotation);
            //Minus 100 money from PlayerMoney script
            playerMoney.money -= 100;
            //Selected set to null
            SelectedTowers = null;
        }
    }
    //Static variable for towers SelectedTowers get, and private set
    public static Towers SelectedTowers { get; private set; }
    //Static function for tower set selected towers
    public static void SetSelectedTowers(Towers towers)
    {
        //If statement if Selected is not euqal null run this
        if (SelectedTowers != null)
        {
            //The SelectedTowers Selected to false
            SelectedTowers.Selected(false);
        }
        //SelectedTowers set to towers
        SelectedTowers = towers;
        //SelectedTowers Selected to true
        SelectedTowers.Selected(true);
    }
}
