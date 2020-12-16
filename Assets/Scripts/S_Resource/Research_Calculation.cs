using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Research_Calculation : MonoBehaviour {
    /// <summary>
    /// Declare Variable number of research for counting
    /// </summary>
    public static int numberReserach;
    float timerCal = 0;

   
    /// <summary>
    /// Calculate Research Point Per Seconds
    /// </summary>
    private void FixedUpdate()
    {
        timerCal += Time.deltaTime;
        if (timerCal >= 1)
        {
            Research_Summary.researchPoint += (BuildingManager.GenerateResearch * numberReserach);
            timerCal = 0;
        }
    }
}
