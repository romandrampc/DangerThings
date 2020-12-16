using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour {

    [SerializeField] GameObject winText;
    [SerializeField] AudioClip winClipSound;
    AudioSource m_MyAudioSourceWin;

    private void Awake()
    {
        ReactorCount.numberReactor = 0;
        TowerCount.numberTower = 4;
    }

    // Use this for initialization
    void Start () {
        winText.SetActive(false);
        m_MyAudioSourceWin = GetComponent<AudioSource>();

	}
	
	// Check Condition Win per frame
	void Update () {
		if (ReactorCount.numberReactor >= 1 && TowerCount.numberTower >=4)
        {
            m_MyAudioSourceWin.PlayOneShot(winClipSound, 0.3f);
            winText.SetActive(true);
            
        }
        Debug.Log("reactor : "+ReactorCount.numberReactor);
        Debug.Log("Tower : " + TowerCount.numberTower);
    }
    
}
