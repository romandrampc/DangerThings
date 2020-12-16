using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold_Calculation : MonoBehaviour {

    /// <summary>
    /// Declare variable
    /// </summary>
    public static int numberMine;
    float timerCal = 0;

    /// <summary>
    /// Use this for set numberMine
    /// </summary>
    void Start() {
        numberMine = 0;
    }


    /// <summary>
    /// Calculate Gold Point Per Seconds
    /// </summary>
    private void FixedUpdate()
    {
        timerCal += Time.deltaTime;
        if (timerCal >= 1)
        {
            Gold_Summary.GoldPoint += (BuildingManager.GenerateGold * numberMine);
            timerCal=0;
        }
        
    }
}
    
