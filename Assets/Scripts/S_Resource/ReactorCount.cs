using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactorCount : MonoBehaviour {

    /// <summary>
    /// Declare Variable number of reactor
    /// </summary>
    public static int numberReactor;

    private void Awake()
    {
        numberReactor = 0;
       
    }

    /// <summary>
    /// Use this for set number of reactor
    /// </summary>
    void Start () {
        
	}
}
