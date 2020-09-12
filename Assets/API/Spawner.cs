using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>();
    public static float spawnTime=1.2f;
    private float BallTime;
    private float countTime;
    private Vector3 spawnPosition;
    public GameObject Ball;
    public float BallCreate;

    void Start()
    {
        BallCreate = Random.Range(10, 30);
    }

    public void SpawnPlatform()
    {
        countTime += Time.deltaTime;
        BallTime += Time.deltaTime;
        spawnPosition = transform.position;
        spawnPosition.x = Random.Range(-3.1f, 3.1f);
        

        if(countTime>=spawnTime)
        {
            CreatePlatform();
            countTime = 0;
        }
        if (BallTime >= BallCreate)
        {
            Instantiate(Ball, spawnPosition, Quaternion.identity);
            BallCreate = Random.Range(10, 30);
            BallTime = 0;
        }
    }

    public void CreatePlatform()
    {
        int index = Random.Range(0, platforms.Count);
        GameObject newPlatform = Instantiate(platforms[index], spawnPosition, Quaternion.identity);
        newPlatform.transform.SetParent(this.gameObject.transform);
    }
    void Update()
    {
        SpawnPlatform();
    }
}
