using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimerCountdown : MonoBehaviour {

    /// <summary>
    /// Declare Variable to use for countdown
    /// </summary>
    #region Declare Variable
    public static TimerCountdown instance;
    public static float mainTime;
    private bool mineBuildComplete;
    private bool researcherBuildComplete;
    private bool reactorBuildComplete;
    private bool towerBuildComplete;

    private static float mineCountTimer;
    private static float researchCountTimer;
    private static float reactorCountTimer;
    private static float towerCountTimer;

    public static bool hasMineClickBuildYet;
    public static bool hasResearchClickBuildYet;
    public static bool hasReactorClickBuildYet;
    public static bool hasTowerClickBuildYet;

    [SerializeField] float setTimer;
    [SerializeField] GameObject gameoverUI;
    #endregion

    #region EventManager
    BuildCompleteEvent boolMine = new BuildCompleteEvent();
    BuildCompleteEvent boolResearch = new BuildCompleteEvent();
    BuildCompleteEvent boolReactor = new BuildCompleteEvent();
    BuildCompleteEvent boolTower = new BuildCompleteEvent();
    public void AddMineListener(UnityAction<bool> listener)
    {
        boolMine.AddListener(listener);
    }

    public void AddReserachListener(UnityAction<bool> listener)
    {
        boolResearch.AddListener(listener);
    }

    public void AddReactorListener(UnityAction<bool> listener)
    {
        boolReactor.AddListener(listener);
    }

    public void AddTowerListener(UnityAction<bool> listener)
    {
        boolTower.AddListener(listener);
    }
    #endregion

    /// <summary>
    /// Getter Setter for Building Complete and CountDown Timer
    /// </summary>
    #region Getter Setter Variable
    public bool MineBuildComplete{
        get{return mineBuildComplete;}
        set{ mineBuildComplete = value;}
    }

    public  bool ResearcherBuildComplete{
        get{return researcherBuildComplete; }
        set{ researcherBuildComplete = value;}
    }

    public  bool ReactorBuildComplete{
        get{return reactorBuildComplete; }
        set{ reactorBuildComplete = value;}
    }

    public  bool TowerBuildComplete
    {
        get{return towerBuildComplete; }
        set{ towerBuildComplete = value;}
    }

    public static float MineCountTimer
    {
        get{return mineCountTimer;}
        set{mineCountTimer = value;}
    }

    public static float ResearchCountTimer
    {
        get{return researchCountTimer;}
        set{researchCountTimer = value;}
    }

    public static float ReactorCountTimer
    {
        get{return reactorCountTimer;}
        set{reactorCountTimer = value;}
    }

    public static float TowerCountTimer
    {
        get{return towerCountTimer;}
        set{towerCountTimer = value;}
    }
    #endregion

    /// <summary>
    /// Awake for Config some setting before starting anything
    /// </summary>
    void Awake()
    {
        instance = this;
        hasMineClickBuildYet = false;
        hasResearchClickBuildYet = false;
        hasTowerClickBuildYet = false;
        hasReactorClickBuildYet = false;
        MineCountTimer = 0;
    }

    /// <summary>
    /// Start for Config some setting in starting game
    /// </summary>
    void Start () {
        gameoverUI.SetActive(false);
        mainTime = setTimer;
        MineBuildComplete = false;
        ResearcherBuildComplete = false;
        ReactorBuildComplete = false;
        TowerBuildComplete = false;

        EventManager.AddMineInvoker(this);
        EventManager.AddReactorInvoker(this);
        EventManager.AddResearchInvoker(this);
        EventManager.AddTowerInvoker(this);

        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {

		if (mainTime >=0.0f)
        {
            mainTime -= Time.deltaTime;
        }
        else if (mainTime<=0.0f)
        {
            gameoverUI.SetActive(true);
            Time.timeScale = 0;
        }

        /// <summary>
        /// Calculation for timer building for text show
        /// </summary>
        #region Building Countdown Timer Calculation
        // check for orderbuilding to countdown time
        if (!MineBuildComplete && hasMineClickBuildYet){
            MineCountTimer -= Time.deltaTime;}
        else if (MineBuildComplete && hasMineClickBuildYet){
            MineCountTimer = 0;}

        if (!ResearcherBuildComplete && hasResearchClickBuildYet){
            ResearchCountTimer -= Time.deltaTime;}
        else if (ResearcherBuildComplete && hasResearchClickBuildYet){
            ResearchCountTimer = 0;}

        if (!ReactorBuildComplete && hasReactorClickBuildYet){ 
            ReactorCountTimer -= Time.deltaTime;}
        else if (ReactorBuildComplete && hasReactorClickBuildYet){
            ReactorCountTimer = 0;}

        if (!TowerBuildComplete && hasTowerClickBuildYet){
            TowerCountTimer -= Time.deltaTime;}
        else if (TowerBuildComplete && hasTowerClickBuildYet){
            TowerCountTimer = 0;}
        #endregion
    }

    /// <summary>
    /// method for call to set timer
    /// </summary>
    /// <param name="buildTime"></param>
    #region Setting Countdown Timer
    public void setMineCountdownTimer(float buildTime)
    {
        MineBuildComplete = false;
        MineCountTimer = buildTime;
        StartCoroutine(mineCountTime(buildTime));
    }

    public void setResearchCountdownTimer(float buildTime)
    {
        ResearcherBuildComplete = false;
        ResearchCountTimer = buildTime;
        StartCoroutine(researchCountTime(buildTime));
    }

    public void setReactorCountdownTimer(float buildTime)
    {
        ReactorBuildComplete = false;
        ReactorCountTimer = buildTime;
        StartCoroutine(reactorCountTime(buildTime));
    }
    public void setTowerCountdownTimer(float buildTime)
    {
        TowerBuildComplete = false;
        TowerCountTimer = buildTime;
        StartCoroutine(towerCountTime(buildTime));
    }

    #endregion

    /// <summary>
    /// Timer by IEnum 
    /// </summary>
    /// <param name="buildTime"></param>
    /// <returns></returns>
    #region IEnumerator for wait build Time
    private IEnumerator mineCountTime(float buildTime)
    {
        yield return new WaitForSeconds(buildTime);
        MineBuildComplete = true;
        boolMine.Invoke(MineBuildComplete);
        Debug.Log("Can Build Mine");
    }

    private IEnumerator researchCountTime(float buildTime)
    {
        yield return new WaitForSeconds(buildTime);
        ResearcherBuildComplete = true;
        boolResearch.Invoke(ResearcherBuildComplete);
        Debug.Log("Can Build Reserach");
    }

    private IEnumerator reactorCountTime(float buildTime)
    {
        yield return new WaitForSeconds(buildTime);
        ReactorBuildComplete = true;
        boolReactor.Invoke(ReactorBuildComplete);
        Debug.Log("Can Build Reactor");
    }

    private IEnumerator towerCountTime(float buildTime)
    {
        yield return new WaitForSeconds(buildTime);
        TowerBuildComplete = true;
        boolTower.Invoke(TowerBuildComplete);
        Debug.Log("Can Build Tower");
    }
    #endregion

}
