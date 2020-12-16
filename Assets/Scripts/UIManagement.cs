using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour {

    [SerializeField] Text timerText;
    [SerializeField] Text goldText;
    [SerializeField] Text researchText;
    [SerializeField] Text mineTimeLeftText;
    [SerializeField] Text researchTimeLeftText;
    [SerializeField] Text reactorTimeLeftText;
    [SerializeField] Text towerTimeLeftText;

    [SerializeField] GameObject mineTimeLeftObj;
    [SerializeField] GameObject researchTimeLeftObj;
    [SerializeField] GameObject reactorTimeLeftObj;
    [SerializeField] GameObject towerTimeLeftObj;

    bool mineBuildComplete;
    bool researchBuildComplete;
    bool reactorBuildComplete;
    bool towerBuildComplete;

    string minutes;
    string seconds;

    // Use this for initialization
    void Start()
    {
        mineBuildComplete = false;
        researchBuildComplete = false;
        reactorBuildComplete = false;
        towerBuildComplete = false;

        EventManager.AddMineListener(MineCompleteSet);
        EventManager.AddResearchListener(ReserachCompleteSet);
        EventManager.AddReactorListener(ReactorCompleteSet);
        EventManager.AddTowerListener(TowerCompleteSet);
    }

    // Update is called once per frame
    void Update () {

        #region Show text resources and main timer
        goldText.text = "Gold : " + Gold_Summary.GoldPoint.ToString();
        researchText.text = "Research : " + Research_Summary.researchPoint.ToString();
        minutes = ((int)TimerCountdown.mainTime / 60).ToString();
        seconds = (TimerCountdown.mainTime % 60).ToString("00");
        timerText.text = minutes + " : " + seconds;
        #endregion

        #region Show Text Building Time
        ///Mine Text
        if (mineBuildComplete && TimerCountdown.hasMineClickBuildYet)
        {
            mineTimeLeftObj.SetActive(true);
            mineTimeLeftText.text = "Ready";
        }
        else if (/*!TimerCountdown.MineBuildComplete &&*/ TimerCountdown.hasMineClickBuildYet){
            mineTimeLeftObj.SetActive(true);
            mineTimeLeftText.text = (TimerCountdown.MineCountTimer % 60).ToString("00") + " S";
            
        }
        else{
            
            mineBuildComplete = false;
            mineTimeLeftObj.SetActive(false);
        }

        /// Research Text
        if (researchBuildComplete && TimerCountdown.hasResearchClickBuildYet)
        {
            researchTimeLeftObj.SetActive(true);
            researchTimeLeftText.text = "Ready";
        }
        else if ( TimerCountdown.hasResearchClickBuildYet)
        {
            researchTimeLeftObj.SetActive(true);
            researchTimeLeftText.text = (TimerCountdown.ResearchCountTimer % 60).ToString("00") + " S";
        }
        else
        {
            researchBuildComplete = false;
            researchTimeLeftObj.SetActive(false);
        }

        /// Reactor Text
        if (reactorBuildComplete && TimerCountdown.hasReactorClickBuildYet)
        {
            reactorTimeLeftObj.SetActive(true);
            reactorTimeLeftText.text = "Ready";
        }
        else if ( TimerCountdown.hasReactorClickBuildYet)
        {
            reactorTimeLeftObj.SetActive(true);
            reactorTimeLeftText.text = (TimerCountdown.ReactorCountTimer % 60).ToString("00") + " S";
        }
        else
        {
            reactorBuildComplete = false;
            reactorTimeLeftObj.SetActive(false);
        }
        
        /// Tower Text
        if (towerBuildComplete && TimerCountdown.hasTowerClickBuildYet)
        {
            towerTimeLeftObj.SetActive(true);
            towerTimeLeftText.text = "Ready";
        }
        else if ( TimerCountdown.hasTowerClickBuildYet)
        {
            towerTimeLeftObj.SetActive(true);
            towerTimeLeftText.text = (TimerCountdown.TowerCountTimer % 60).ToString("00") + " S";
        }
        else
        {
            towerBuildComplete = false;
            towerTimeLeftObj.SetActive(false);
        }
        #endregion
    }

    public void MineCompleteSet(bool buildingStatus)
    {
        mineBuildComplete = buildingStatus;
    }

    public void ReserachCompleteSet(bool buildingStatus)
    {
        researchBuildComplete = buildingStatus;
    }

    public void ReactorCompleteSet(bool buildingStatus)
    {
        reactorBuildComplete = buildingStatus;
    }

    public void TowerCompleteSet(bool buildingStatus)
    {
        towerBuildComplete = buildingStatus;
    }
}
