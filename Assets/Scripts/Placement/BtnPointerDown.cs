using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Rom
{
    public class BtnPointerDown : MonoBehaviour, IPointerDownHandler
    {

        [SerializeField] AudioSource m_MyAudioSourceStart;
        [SerializeField] AudioSource m_MyAudioSourceUnderCon;
        [SerializeField] AudioSource m_MyAudioSourceInsuffiFund;

        bool mineBuildComplete;
        bool researchBuildComplete;
        bool reactorBuildComplete;
        bool towerBuildComplete;

        void Update()
        {
            EventManager.AddMineListener(MineCompleteSet);
            EventManager.AddResearchListener(ReserachCompleteSet);
            EventManager.AddReactorListener(ReactorCompleteSet);
            EventManager.AddTowerListener(TowerCompleteSet);
        }

        private IEnumerator buildUI()
        {
            yield return new WaitForSeconds(0.85f);
            UIController.instance.EnableBuildingUI();
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            // BuildMine
            #region Mine Build

            if (this.gameObject.name == "Mine")
            {
                // Checking Condition
                // 1. Resource
                // 2. BuildTime
                // 3. Has Cilck yet ?
                
                if (Gold_Summary.GoldPoint >= BuildingManager.MineGoldCost && TimerCountdown.hasMineClickBuildYet == false)
                {
                    m_MyAudioSourceStart.Play();
                    Debug.Log("Start Timer Mine");
                    TimerCountdown.hasMineClickBuildYet = true;
                    Gold_Summary.GoldPoint -= BuildingManager.MineGoldCost;
                    TimerCountdown.instance.setMineCountdownTimer(BuildingManager.MineTimeCost);
                }
                else if (mineBuildComplete && TimerCountdown.hasMineClickBuildYet == true)
                {
                    Debug.Log("Build Mine");
                    MainController.instance.SpawnBuilding(this.gameObject.name);
                    UIController.instance.DisableBuildingUI();
                    TimerCountdown.hasMineClickBuildYet = false;
                    mineBuildComplete = false;
                    //mineBuildComplete = false;
                }
                else if (!mineBuildComplete && TimerCountdown.hasMineClickBuildYet == true)
                {
                    m_MyAudioSourceUnderCon.Play();
                    MainController.instance.TimerText = 0;
                    MainController.instance._errorText.text = "In Time Building";
                    StartCoroutine(buildUI());
                }
                else
                {
                    m_MyAudioSourceInsuffiFund.Play();
                    MainController.instance.TimerText = 0;
                    MainController.instance._errorText.text = "Insufficient Funds";
                    StartCoroutine(buildUI());
                }
            }
            #endregion

            // Build Research
            #region Research Build
            if (this.gameObject.name == "Research")
            {
                // Checking Condition
                // 1. Resource
                // 2. BuildTime
                // 3. Has Cilck yet ?
                if (Gold_Summary.GoldPoint >= BuildingManager.ResearchGoldCost && TimerCountdown.hasResearchClickBuildYet == false)
                {
                    m_MyAudioSourceStart.Play();
                    Gold_Summary.GoldPoint -= BuildingManager.ResearchGoldCost;
                    Debug.Log("Start Timer Research");
                    TimerCountdown.hasResearchClickBuildYet = true;
                    researchBuildComplete = false;
                    TimerCountdown.instance.setResearchCountdownTimer(BuildingManager.ResearchTimeCost);
                }
                else if (researchBuildComplete && TimerCountdown.hasResearchClickBuildYet == true)
                {
                    Debug.Log("Build Reserach");
                    MainController.instance.SpawnBuilding(this.gameObject.name);
                    UIController.instance.DisableBuildingUI();
                    TimerCountdown.hasResearchClickBuildYet = false;
                    researchBuildComplete = false;
                }
                else if (!researchBuildComplete && TimerCountdown.hasResearchClickBuildYet == true)
                {
                    m_MyAudioSourceUnderCon.Play();
                    MainController.instance.TimerText = 0;
                    MainController.instance._errorText.text = "In Time Building";
                    StartCoroutine(buildUI());
                }
                else
                {
                    m_MyAudioSourceInsuffiFund.Play();
                    MainController.instance.TimerText = 0;
                    MainController.instance._errorText.text = "Insufficient Funds";
                    StartCoroutine(buildUI());
                }
            }
            #endregion

            // Build Reactor
            #region Reactor Build
            if (this.gameObject.name == "Reactor")
            {
                // Checking Condition
                // 1. Resource
                // 2. BuildTime
                // 3. Has Cilck yet ?
                if (Gold_Summary.GoldPoint >= BuildingManager.ReactorGoldCost && Research_Summary.researchPoint >= BuildingManager.ReactorResearchCost && TimerCountdown.hasReactorClickBuildYet == false)
                {
                    m_MyAudioSourceStart.Play();
                    Gold_Summary.GoldPoint -= BuildingManager.ReactorGoldCost;
                    Research_Summary.researchPoint -= BuildingManager.ReactorResearchCost;
                    Debug.Log("Start Timer Reactor");
                    TimerCountdown.hasReactorClickBuildYet = true;
                    TimerCountdown.instance.setReactorCountdownTimer(BuildingManager.ReactorTimeCost);
                }
                else if (reactorBuildComplete && TimerCountdown.hasReactorClickBuildYet == true)
                {
                    Debug.Log("Build Reactor");
                    MainController.instance.SpawnBuilding(this.gameObject.name);
                    UIController.instance.DisableBuildingUI();
                    TimerCountdown.hasReactorClickBuildYet = false;
                    reactorBuildComplete = false;
                }
                else if (!reactorBuildComplete && TimerCountdown.hasReactorClickBuildYet == true)
                {
                    m_MyAudioSourceUnderCon.Play();
                    MainController.instance.TimerText = 0;
                    MainController.instance._errorText.text = "In Time Building";
                    StartCoroutine(buildUI());
                }
                else
                {
                    m_MyAudioSourceInsuffiFund.Play();
                    MainController.instance.TimerText = 0;
                    MainController.instance._errorText.text = "Insufficient Funds";
                    StartCoroutine(buildUI());
                }
            }
            #endregion

            // Build Tower
            #region Tower Build
            if (this.gameObject.name == "Tower")
            {
                // Checking Condition
                // 1. Resource
                // 2. BuildTime
                // 3. Has Cilck yet ?
                if (Gold_Summary.GoldPoint >= BuildingManager.TowerGoldCost && Research_Summary.researchPoint >= BuildingManager.TowerResearchCost && TimerCountdown.hasTowerClickBuildYet == false)
                {
                    m_MyAudioSourceStart.Play();
                    Gold_Summary.GoldPoint -= BuildingManager.TowerGoldCost;
                    Research_Summary.researchPoint -= BuildingManager.TowerResearchCost;
                    Debug.Log("Start Timer Tower");
                    TimerCountdown.hasTowerClickBuildYet = true;
                    TimerCountdown.instance.setTowerCountdownTimer(BuildingManager.TowerTimeCost);
                }
                else if (towerBuildComplete && TimerCountdown.hasTowerClickBuildYet == true)
                {
                    Debug.Log("Build Tower");
                    MainController.instance.SpawnBuilding(this.gameObject.name);
                    UIController.instance.DisableBuildingUI();
                    TimerCountdown.hasTowerClickBuildYet = false;
                    towerBuildComplete = false;
                }
                else if (!towerBuildComplete && TimerCountdown.hasTowerClickBuildYet == true)
                {
                    m_MyAudioSourceUnderCon.Play();
                    MainController.instance.TimerText = 0;
                    MainController.instance._errorText.text = "In Time Building";
                    StartCoroutine(buildUI());
                }
                else
                {
                    m_MyAudioSourceInsuffiFund.Play();
                    MainController.instance.TimerText = 0;
                    MainController.instance._errorText.text = "Insufficient Funds";
                    StartCoroutine(buildUI());
                }
            }
            #endregion
            //MainController.instance.SpawnBuilding(this.gameObject.name);
            //UIController.instance.DisableBuildingUI();
        }

        public void MineCompleteSet (bool buildingStatus)
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
}
