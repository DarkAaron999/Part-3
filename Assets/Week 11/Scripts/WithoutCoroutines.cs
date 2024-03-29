using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WithoutCoroutines : MonoBehaviour
{
    public GameObject missile;
    public float speed = 5;
    public float turningSpeedReduction = 0.75f;
    public float timer = 0;
    bool isTurning = false;
    bool isMoving = false;

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            isTurning = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            isMoving = true;
        }
    }

    public void MakeTurn(float turn)
    {
        if (isTurning == true)
        {
            Debug.Log("Turing");
            float interpolation = 0;
            Quaternion currentHeading = missile.transform.rotation;
            Quaternion newHeading = currentHeading * Quaternion.Euler(0, 0, turn);
            while (interpolation < 1)
            {
                interpolation += Time.deltaTime;
                missile.transform.rotation = Quaternion.Lerp(currentHeading, newHeading, interpolation);
                missile.transform.Translate(transform.right * (speed * turningSpeedReduction) * Time.deltaTime);
                isTurning = false;
            }
        }
    }

    public void MoveForwards(float legLength)
    {
        if (isMoving == true)
        {
            Debug.Log("Moving");
            float time = 0;
            while (time < legLength)
            {
                time += Time.deltaTime;
                missile.transform.Translate(transform.right * speed * Time.deltaTime);
                isMoving = false;
            }
        }
    }
}
