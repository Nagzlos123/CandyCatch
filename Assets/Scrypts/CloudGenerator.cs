using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] clouds;
    [SerializeField] float spawnInterval;
    [SerializeField] Vector3 startPosition;
    [SerializeField] GameObject endPosition;
    [SerializeField] Transform someParent;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        CloudsStartSetUp();
        Invoke("AttempToSpawn", spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void SpawnCloud(Vector3 startPosition)
    {
        var randomCloud = HandyTools.RandomElement<GameObject>(clouds);
        GameObject cloud = Instantiate(clouds[randomCloud], someParent);
        cloud.GetComponent<Cloud>().SetCloudTransparency();
        float startPosY = Random.Range(startPosition.y - 3f, startPosition.y + 2f);
        cloud.transform.position = new Vector3(startPosition.x, startPosY, startPosition.z);

        float speed = Random.Range(0.5f, 1.5f);

        float scale = Random.Range(1.8f, 2.2f);

        cloud.transform.localScale = new Vector2(scale, scale);
        cloud.GetComponent<Cloud>().StartFloting(speed, endPosition.transform.position.x);

    }

    void AttempToSpawn()
    {
        SpawnCloud(startPosition);
        Invoke("AttempToSpawn", spawnInterval);
    }

    void CloudsStartSetUp()
    {
        for (int i = 0; i < 20; i++)
        {
            Vector3 spawnPos = startPosition + Vector3.right * (i * 4);

            SpawnCloud(spawnPos);
        }
    }
}
