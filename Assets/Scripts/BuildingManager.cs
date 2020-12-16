using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class BuildingManager : MonoBehaviour {

    const string configDataFileName = "ConfigBuildingDangerThings.csv";

    [SerializeField] int levelNo = 1;

    private static float generateGold;
    private static float generateResearch;
    private static int mineGoldCost;
    private static float mineTimeCost;
    private static int researchGoldCost;
    private static float researchTimeCost;
    private static int reactorGoldCost;
    private static int reactorResearchCost;
    private static float reactorTimeCost;
    private static int towerGoldCost;
    private static int towerResearchCost;
    private static float towerTimeCost;

    #region getter_setter For variable of Building
    public static float GenerateGold{
        get{return generateGold;}
        set{generateGold = value;}
    }

    public static float GenerateResearch{
        get{return generateResearch;}
        set{generateResearch = value;}
    }

    public static int MineGoldCost{
        get{return mineGoldCost;}
        set{mineGoldCost = value;}
    }

    public static float MineTimeCost{
        get{return mineTimeCost;}
        set{mineTimeCost = value;}
    }

    public static int ResearchGoldCost{
        get{return researchGoldCost;}
        set{researchGoldCost = value;}
    }

    public static float ResearchTimeCost{
        get{return researchTimeCost;}
        set{researchTimeCost = value;}
    }

    public static int ReactorGoldCost{
        get{return reactorGoldCost;}
        set{reactorGoldCost = value;}
    }

    public static int ReactorResearchCost{
        get{return reactorResearchCost;}
        set{reactorResearchCost = value;}
    }

    public static float ReactorTimeCost{
        get{return reactorTimeCost;}
        set{reactorTimeCost = value;}
    }

    public static int TowerGoldCost{
        get{return towerGoldCost;}
        set{towerGoldCost = value;}
    }

    public static int TowerResearchCost{
        get{return towerResearchCost;}
        set {towerResearchCost = value;}
    }

    public static float TowerTimeCost{
        get{return towerTimeCost;}
        set{towerTimeCost = value;}
    }
    #endregion

    // Use this for initialization
    void Start () {
        ConfData();
    }

    void ConfData()
    {
        StreamReader input = null;
        try
        {
            input = File.OpenText(Path.Combine(Application.streamingAssetsPath, configDataFileName));
            string name = input.ReadLine();

            string value = input.ReadLine();

            while (value != null)
            {

                SetConfigDataFields(value);
                value = input.ReadLine();
            }

        }
        catch (Exception e) { Debug.Log(e.Message); }
        finally
        {
            if (input != null)
            {
                input.Close();
            }
        }
    }

    void SetConfigDataFields(string csvValues)
    {
        string[] values = csvValues.Split(',');
        Debug.Log(levelNo);
        if (levelNo == int.Parse(values[0]))
        {
            switch (int.Parse(values[1]))
            {
                case 1:
                    GenerateGold = float.Parse(values[2]);
                    MineGoldCost = int.Parse(values[4]);
                    MineTimeCost = float.Parse(values[6]);
                    break;

                case 2:
                    GenerateResearch = float.Parse(values[3]);
                    ResearchGoldCost = int.Parse(values[4]);
                    ResearchTimeCost = float.Parse(values[6]);
                    break;

                case 3:
                    ReactorGoldCost = int.Parse(values[4]);
                    ReactorResearchCost = int.Parse(values[5]);
                    ReactorTimeCost = float.Parse(values[6]);
                    break;

                case 4:
                    TowerGoldCost = int.Parse(values[4]);
                    TowerResearchCost = int.Parse(values[5]);
                    TowerTimeCost = float.Parse(values[6]);
                    break;
            }
           
            //ScoreManager.score = int.Parse(values[1]);
            //LiveManager.Live = int.Parse(values[2]);
        }

    }
}
