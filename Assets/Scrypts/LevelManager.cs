using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Transform[] spaningPoints;

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
        //SpawnCandy();
        StarSpawning();
    }

    // Update is called once per frame
    void Update()
    {
        //SpanCandy();
    }

    private void SpawnCandy(GameObject[] candySet)
    {
        randomCandy = HandyTools.RandomElement<GameObject>(candySet);
        randomPoint = HandyTools.RandomElement<Transform>(spaningPoints);
        Instantiate(candySet[randomCandy], spaningPoints[randomPoint]);
    }

    IEnumerator SpawnCandies()
    {
        yield return new WaitForSeconds(2f);

        while (true) 
        {
            SpawnCandy(candySet1);
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
