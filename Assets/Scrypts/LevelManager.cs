using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    Dictionary<GameObject, GameObject[]> LevelSetUps = new Dictionary<GameObject, GameObject[]>();

    [SerializeField] private GameObject gameManager;

    [SerializeField] private Transform[] spaningPoints;
    [SerializeField] private GameObject[] gameLevels;

    [SerializeField] private GameObject[] rockSet1;
    [SerializeField] private GameObject[] rockSet2;

    [SerializeField] private GameObject[] candySet1;
    [SerializeField] private GameObject[] candySet2;
    [SerializeField] private GameObject[] candySet3;
    [SerializeField] private GameObject[] candySet4;
    [SerializeField] private GameObject[] candySet5;
    [SerializeField] private GameObject[] candySet6;
    public int randomPoint = 0;
    public int randomCandy = 0;
    [SerializeField] float spawnInterval;

    public static LevelManager Instance;

   

    public LevelSetUp currentSetUp;
    public enum LevelSetUp
    {
        Level1, Level2, Level3, Level4, Level5, Level6
    }

    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        AddingElemetsToDictionary();
        CheckDictionary();
        //SpawnCandy();
        //StarSpawning();
    }

    // Update is called once per frame
    void Update()
    {
        //SpanCandy();
        ManageLevelsChageLoop();
        ManageLevelsSetUp();
        
    }

    private void AddingElemetsToDictionary()
    {
        LevelSetUps.Add(gameLevels[0], candySet1);
        LevelSetUps.Add(gameLevels[1], candySet2);
        LevelSetUps.Add(gameLevels[2], candySet3);
        LevelSetUps.Add(gameLevels[3], candySet4);
        LevelSetUps.Add(gameLevels[4], candySet5);
        LevelSetUps.Add(gameLevels[5], candySet6);
    }

    private void ActivateSection(GameObject section)
    {
        for (int i = 0; i < gameLevels.Length; i++)
        {
            if(gameLevels[i] == section)
            {
                gameLevels[i].SetActive(true);
            }
            else
            {
                gameLevels[i].SetActive(false);
            }
        }
    }

    private void CheckDictionary()
    {
        foreach (var key in LevelSetUps.Keys)
        {
            //Console.WriteLine(key);
            Debug.Log($"Key:{key}");
        }
    }
    private void ChangeLevelSetUp(GameObject gamelevel)
    {
        //var candySet = LevelSetUps[gamelevel];

        ActivateSection(gamelevel);
        //gamelevel.SetActive(true);

        //SpawnCandy(candySet);

    }
    public void ManageLevelsSetUp()
    {
     
        switch (currentSetUp)
        { 
            case LevelSetUp.Level1:
                ChangeLevelSetUp(gameLevels[0]);
                break;
            case LevelSetUp.Level2:
                ChangeLevelSetUp(gameLevels[1]);
                break;
            case LevelSetUp.Level3:
                ChangeLevelSetUp(gameLevels[2]);
                break;
            case LevelSetUp.Level4:
                ChangeLevelSetUp(gameLevels[3]);
                break;
            case LevelSetUp.Level5:
                ChangeLevelSetUp(gameLevels[4]);
                break;
            case LevelSetUp.Level6:
                ChangeLevelSetUp(gameLevels[5]);
                break;
            default:
                break;
        }
    }
    public void ManageLevelsChageLoop()
    {
        if (gameManager.GetComponent<GameManager>().currentLevel == 1 )
        {
            SetLevelStage(LevelSetUp.Level1);
        }

        if (gameManager.GetComponent<GameManager>().currentLevel == 2)
        {
            SetLevelStage(LevelSetUp.Level2);
        }

        if (gameManager.GetComponent<GameManager>().currentLevel == 3)
        {
            SetLevelStage(LevelSetUp.Level3);
        }

        if (gameManager.GetComponent<GameManager>().currentLevel == 4)
        {
            SetLevelStage(LevelSetUp.Level4);
        }

        if (gameManager.GetComponent<GameManager>().currentLevel == 5)
        {
            SetLevelStage(LevelSetUp.Level5);
        }

        if (gameManager.GetComponent<GameManager>().currentLevel == 6)
        {
            SetLevelStage(LevelSetUp.Level6);
        }
    }
    public void SetLevelStage(LevelSetUp newSetUp)
    {
        currentSetUp = newSetUp;
    }

    private void SpawnCandy(GameObject[] candySet)
    {
        randomCandy = HandyTools.RandomElement<GameObject>(candySet);
        randomPoint = HandyTools.RandomElement<Transform>(spaningPoints);
        Instantiate(candySet[randomCandy], spaningPoints[randomPoint]);
    }

    IEnumerator SpawnCandies(GameObject[] candySet)
    {
        yield return new WaitForSeconds(2f);

        while (true) 
        {
            SpawnCandy(candySet);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void StarSpawning()
    {
        StartCoroutine("SpawnCandies");
    }

    public void StopSpawning()
    {
        StopCoroutine("SpawnCandies");
    }
}
