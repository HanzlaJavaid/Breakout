using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    float colliderRadius;
    Timer SpawnTimer;
    public void SpawnBall()
    {
        Vector3 posToSpawn = new Vector3(0, 0, 0);
        Collider2D[] j = Physics2D.OverlapCircleAll(posToSpawn, colliderRadius);
        if (j.Length == 0)
        {
            GameObject x = Instantiate(ballPrefab);
            x.transform.position = posToSpawn;
        }
    }
    private void Start()
    {
        SpawnTimer = gameObject.AddComponent<Timer>();
        SpawnTimer.Duration = Random.Range(ConfigurationUtils.minTimer, ConfigurationUtils.maxTimer);
        SpawnTimer.Run();
        colliderRadius = ballPrefab.GetComponent<CircleCollider2D>().radius;
        SpawnBall();
    }
    private void Update()
    {
        if (SpawnTimer.Finished)
        {
            SpawnBall();
            SpawnTimer.Duration = Random.Range(ConfigurationUtils.minTimer, ConfigurationUtils.maxTimer);
            SpawnTimer.Run();
        }
    }
}