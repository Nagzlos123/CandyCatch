using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Transform[] spaningPoints;
    [SerializeField] private GameObject[] candySet;
    public int randomPoint = 0;
    public int randomCandy = 0;
    [SerializeField] float spawnInterval;

    public static LevelManager instance;

    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
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

    private void SpawnCandy()
    {
        randomCandy = RandomElement<GameObject>(candySet);
        randomPoint = RandomElement<Transform>(spaningPoints);
        Instantiate(candySet[randomCandy], spaningPoints[randomPoint]);
    }
    private int RandomElement<T>(T[] elemets)
    {
         int randomNumber = Random.Range(0, elemets.Length);

        return randomNumber;
    }

    IEnumerator SpawnCandies()
    {
        yield return new WaitForSeconds(2f);

        while (true) 
        {
            SpawnCandy();
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
