using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Rom
{
    public class UIController : MonoBehaviour
    {
        /// <summary>
        /// Declare variable To receive GameObject UI
        /// </summary>
        #region Declare Variable
        public static UIController instance;
        [SerializeField] GameObject BuildingUI;
        [SerializeField] GameObject costUI;
        [SerializeField] GameObject countdownBuildUI;


        //[SerializeField] GameObject CancelBtn;
        //public GameObject TutorialBlock;
        //public GameObject Blocker;
        //public GameObject Blocker1;
        //public Text tutorialText;
        //public GameObject Up, Down;
        #endregion

        /// <summary>
        /// Awake to Setting
        /// </summary>
        void Awake()
        {
            //PlayerPrefs.DeleteAll();      //Tutorial for every Launch
            //if(!PlayerPrefs.HasKey ("FirstTime"))
            //{
            //    PlayerPrefs.SetInt("FirstTime", 1);
            //    Blocker.SetActive(true);
            //    Down.SetActive(true);
            //    tutorialText.text = "Click the type of building you want to generate \n and move the mouse to position the object.";
            //}
            instance = this;
        }
        /*
        public void Clicked_Mine () 
        {
        }
        
        public void Clicked_Research() 
        {
            MainController.instance.SpawnBuilding("Research");
            DisableBuildingUI();
        }



        public void Clicked_Reactor()
        {
            MainController.instance.SpawnBuilding("Reactor");
            DisableBuildingUI();
        }

        public void Clicked_Tower()
        {
            MainController.instance.SpawnBuilding("Tower");
            DisableBuildingUI();
        }*/

        /// <summary>
        /// Set active Building UI
        /// </summary>
        public void EnableBuildingUI()
        {
            //MainController.instance.DestroyCurrentBuilding();
            BuildingUI.SetActive(true);
            costUI.SetActive(true);
            countdownBuildUI.SetActive(true);
            //CancelBtn.SetActive(false);
        }

        /// <summary>
        /// Set disactive Building UI
        /// </summary>
        public void DisableBuildingUI()
        {
            BuildingUI.SetActive(false);
            costUI.SetActive(false);
            countdownBuildUI.SetActive(false);
            /*if (PlayerPrefs.GetInt("FirstTime") == 1)
            {
                Blocker.SetActive(false);
                Blocker1.SetActive(true);
                Down.SetActive(false);
                Up.SetActive(true);
                tutorialText.text = "Press left mouse button to place the building \ninside the grass.";
                StartCoroutine("TurnOffTutorial");
            }*/

            //CancelBtn.SetActive(true);
        }

        /*private IEnumerator TurnOffTutorial()
        {
            yield return new WaitForSeconds(3);
            Up.SetActive(false);
            tutorialText.text = string.Empty;
            Blocker1.SetActive(false);
            TutorialBlock.SetActive(false);
        }*/
    }
}