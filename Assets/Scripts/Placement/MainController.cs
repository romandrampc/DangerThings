using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Rom
{
    public class MainController : MonoBehaviour
    {

        /// <summary>
        /// Declare Variable To use 
        /// </summary>
        #region Declare Variable
        public static MainController instance;
        public Text _errorText;
        public bool isOverlap = false;

        private bool isSpawned = false;
        private bool isPlaced = false;
        private bool isReplaced = false;
        private bool isWrongplace = false;

        private int Width = 100;
        private int Height = 100;
        private GameObject movingGO;
        private GameObject building;
        private float timerText = 0;

        private Vector3 oldPos;
        private Vector3 newPos;

        public Plane grass;

        [SerializeField] AudioSource m_MyAudioSourceComplete;
        #endregion

        /// <summary>
        /// Getter Setter Variable TimerText
        /// </summary>
        public float TimerText
        {
            get{return timerText;}

            set{timerText = value;}
        }

        /// <summary>
        /// Awake to set some setting
        /// </summary>
        void Awake()
        {
            instance = this;
            _errorText.text = string.Empty;
        }

        /// <summary>
        /// 1. Update Timer to Spawn Build UI 
        /// 2. Check Build Complete to play sound
        /// </summary>
        void Update()
        {
            /*if (TimerCountdown.MineBuildComplete | TimerCountdown.ResearcherBuildComplete | TimerCountdown.ReactorBuildComplete | TimerCountdown.TowerBuildComplete)
            {
                m_MyAudioSourceComplete.Play();
            }*/

            TimerText += Time.deltaTime;

            if (TimerText >= 1.5)
            {
                _errorText.text = string.Empty;
                TimerText = 0;
            }
            if (isSpawned)
            {
                MovementUpdate();
            }

            #region Start Build
            if (Input.GetMouseButtonDown(0) && !isPlaced)
            {
                RaycastHit hitInfo = new RaycastHit();
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
                {
                    if (hitInfo.transform.gameObject.tag == "Mine")
                    {
                        
                        isReplaced = true;
                        isSpawned = true;
                        oldPos = hitInfo.transform.gameObject.transform.position;
                        building = hitInfo.transform.gameObject;
                        building.AddComponent<CollisionCheck>();
                        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
                        building.transform.localPosition = new Vector3(pos.x, 0, pos.y);
                    }
                    else if (hitInfo.transform.gameObject.tag == "Research")
                    {
                        isReplaced = true;
                        isSpawned = true;
                        oldPos = hitInfo.transform.gameObject.transform.position;
                        building = hitInfo.transform.gameObject;
                        building.AddComponent<CollisionCheck>();
                        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
                        building.transform.localPosition = new Vector3(pos.x, 0, pos.y);
                    }
                    else if (hitInfo.transform.gameObject.tag == "Reactor")
                    {
                        isReplaced = true;
                        isSpawned = true;
                        oldPos = hitInfo.transform.gameObject.transform.position;
                        building = hitInfo.transform.gameObject;
                        building.AddComponent<CollisionCheck>();
                        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
                        building.transform.localPosition = new Vector3(pos.x, 0, pos.y);
                    }
                    else if (hitInfo.transform.gameObject.tag == "Tower")
                    {
                        isReplaced = true;
                        isSpawned = true;
                        oldPos = hitInfo.transform.gameObject.transform.position;
                        building = hitInfo.transform.gameObject;
                        building.AddComponent<CollisionCheck>();
                        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
                        building.transform.localPosition = new Vector3(pos.x, 0, pos.y);
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// Movement of building over the grass
        /// </summary>
        private void MovementUpdate()
        {
            if (building != null)
            {
                Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
                movingGO = building;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Plane plane = new Plane(Vector3.up, Vector3.zero);

                float rayDistance;
                if (plane.Raycast(ray, out rayDistance))
                {
                    Vector3 point = ray.GetPoint(rayDistance);
                    movingGO.transform.position = point;
                }
                /*
                float x = Input.GetAxis("Mouse X");
                float y = Input.GetAxis("Mouse Y");
                movingGO = building;

                if (x != 0 || y != 0)
                {
                    Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
                    movingGO.transform.localPosition = new Vector3(pos.x, movingGO.transform.localPosition.y, pos.z);
                }
    */
                if ((movingGO.transform.position.x + (building.transform.localScale.x / 2)) > (Width / 2) && movingGO.transform.position.x > 0)
                {
                    isWrongplace = true;
                    _errorText.text = "Warning! You cannot place building outside the grass";
                }
                else if ((movingGO.transform.position.x - (building.transform.localScale.x / 2)) < -(Width / 2) && movingGO.transform.position.x < 0)
                {
                    isWrongplace = true;
                    _errorText.text = "Warning! You cannot place building outside the grass";
                }
                else if ((movingGO.transform.position.z + (building.transform.localScale.z / 2)) > (Height / 2) && movingGO.transform.position.z > 0)
                {
                    isWrongplace = true;
                    _errorText.text = "Warning! You cannot place building outside the grass";
                }
                else if ((movingGO.transform.position.z - (building.transform.localScale.z / 2)) < -(Height / 2) && movingGO.transform.position.z < 0)
                {
                    isWrongplace = true;
                    _errorText.text = "Warning! You cannot place building outside the grass";
                }
                else
                {
                    if (isOverlap)
                        _errorText.text = "Warning! Overlapping with another Object.";
                    else
                        _errorText.text = string.Empty;
                    isWrongplace = false;
                }
                //Debug.Log("POS:" +  movingGO.transform.position);
                building.transform.position = movingGO.transform.position;
                if (Input.GetMouseButtonUp(0))
                {
                    isSpawned = false;
                    if (isWrongplace || isOverlap)
                    {
                        if (isReplaced)
                        {
                            isPlaced = true;
                            isReplaced = false;
                            building.transform.position = oldPos;
                           
                        }
                        else
                        UIController.instance.EnableBuildingUI();
                        _errorText.text = string.Empty;
                        isWrongplace = false;
                        

                    }
                    else
                    {
                        isPlaced = true;
                        isReplaced = false;
                        Destroy(building.GetComponent<CollisionCheck>());
                        building = null;
                        UIController.instance.EnableBuildingUI();
                        Gold_Calculation.numberMine = GameObject.FindGameObjectsWithTag("Mine").Length;
                        Research_Calculation.numberReserach = GameObject.FindGameObjectsWithTag("Research").Length;
                        ReactorCount.numberReactor = GameObject.FindGameObjectsWithTag("Reactor").Length;
                        TowerCount.numberTower = GameObject.FindGameObjectsWithTag("Tower").Length;
                    }
                    StartCoroutine("ObjectPlaced");
                }
            }
        }

        /// <summary>
        /// Check Object is place ?
        /// </summary>
        /// <returns></returns>
        private IEnumerator ObjectPlaced()
        {
            yield return new WaitForSeconds(0.1f);
            isPlaced = true;
        }

        /// <summary>
        /// Destroy Building in current Build
        /// </summary>
        public void DestroyCurrentBuilding()
        {
            if (building != null)
                Destroy(building);
        }

        /// <summary>
        /// Spawn Build (recive argument name of building form BtnDownPointer)
        /// </summary>
        /// <param name="_type"></param>
        public void SpawnBuilding(string _type)
        {
            if (_type == "Mine" )
            {
                GameObject GO = Resources.Load("Building/" + _type) as GameObject;
                building = Instantiate(GO) as GameObject;
                building.AddComponent<CollisionCheck>();
                Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
                building.transform.localPosition = new Vector3(pos.x, 0, pos.z);
                //building.transform.localEulerAngles = new Vector3(90, 0, 0);
                isSpawned = true;
            }
            else if (_type == "Research" )
            {
                GameObject GO = Resources.Load("Building/" + _type) as GameObject;
                building = Instantiate(GO) as GameObject;
                building.AddComponent<CollisionCheck>();
                Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 5.0f, -Camera.main.transform.position.z));
                building.transform.localPosition = new Vector3(pos.x, 5.0f, pos.z);
                //building.transform.localEulerAngles = new Vector3(90, 0, 0);
                isSpawned = true;
            }
            else if (_type == "Reactor" )
            {
                GameObject GO = Resources.Load("Building/" + _type) as GameObject;
                building = Instantiate(GO) as GameObject;
                building.AddComponent<CollisionCheck>();
                Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
                building.transform.localPosition = new Vector3(pos.x, 0, pos.z);
                //building.transform.localEulerAngles = new Vector3(90, 0, 0);
                isSpawned = true;
            }
            else if (_type == "Tower" )
            {
                GameObject GO = Resources.Load("Building/" + _type) as GameObject;
                building = Instantiate(GO) as GameObject;
                building.AddComponent<CollisionCheck>();
                Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
                building.transform.localPosition = new Vector3(pos.x, 0, pos.z);
                //building.transform.localEulerAngles = new Vector3(90, 0, 0);
                isSpawned = true;
            }
        }

        /// <summary>
        /// Spawn Build UI after some show text disable them
        /// </summary>
        /// <returns></returns>
        private IEnumerator buildUI()
        {
            yield return new WaitForSeconds(0.85f);
            UIController.instance.EnableBuildingUI();
        }
    }
}
