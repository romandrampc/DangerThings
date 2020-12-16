using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold_Summary : MonoBehaviour {

    /// <summary>
    /// Declare Varible Total Gold in Game
    /// </summary>
    private static float goldPoint;

    /// <summary>
    /// Getter Setter For Total Gold 
    /// </summary>
    public static float GoldPoint{
        get{return goldPoint;}
        set{goldPoint = value;}
    }

    /// <summary>
    ///  Use this for Set Starting Gold point
    /// </summary>
    void Start () {
        GoldPoint = 200;
	}
}
