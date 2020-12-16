using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour {

    [SerializeField] GameObject[] imageComponent;

    int count=0;
    
    public void NextButtonClick(string sceneName)
    {
        if (count < imageComponent.Length-1)
        {
            imageComponent[count].SetActive(false);
            count++;
            imageComponent[count].SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
