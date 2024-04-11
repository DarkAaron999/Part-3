using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMoney : MonoBehaviour
{
    //A float for the money
    public float money;
    //A static float for the money
    public static float staticMoney;
    //Referencing the money text
    public TextMeshProUGUI moneyText;
    //Start is called before the first frame update
    void Start()
    {
        //Money is set at 500 at start
        money = 600;
        //Static money is set at money value at start
        staticMoney = money;
        //money text is equal to money
        moneyText.text = money.ToString();
        //Write both float value in the console
        Debug.Log(this.ToString() + " static: " + staticMoney + " non-static: " + money);
    }

    //Update is called once per frame
    void Update()
    {
        //Updates the static money to money
        staticMoney = money;
        //money text is equal to money
        moneyText.text = money.ToString();
        //If statement for space bar down
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Write both float value in the console
            Debug.Log(this.ToString() + " static: " + staticMoney + " non-static: " + money);
        }
    }
}
