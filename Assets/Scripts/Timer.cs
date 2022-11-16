using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

   [SerializeField] float timeRemaining = 10;
   [SerializeField] GameObject gameManager;

    void Update()

    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            gameManager.GetComponent<gameManager>().setTime(timeRemaining);
        }
        else
        {
            print("tes mourru");
        }
    }
}

