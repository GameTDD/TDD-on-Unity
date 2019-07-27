using UnityEngine;
using System;

public class EnemySpawner : MonoBehaviour
{
    public float spawnTime;
    public float radius;
    public GameObject enemy;
    public GameObject player;
    float time;

    System.Random random;

    void Start()
    {
        random = new System.Random();
        time = 0;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= spawnTime)
        {
            Spawn();
            time = 0f;
        }
    }

    public Vector3 GetPosition(Vector3 playerPosition, float radius, float randomAngle)
    {
        float correctedRadius = radius > -1f && radius < 1f ? 1 : Mathf.Abs(radius);
        return playerPosition +
            (new Vector3(Mathf.Cos(randomAngle), 0, Mathf.Sin(randomAngle)) * correctedRadius);
    }

    public void Spawn()
    {
        var angle = Mathf.PI * random.Next(0, 8) / random.Next(1, 10);
        Vector3 spawnPosition = GetPosition(player.transform.position, radius, angle);
        Instantiate(enemy, spawnPosition, Quaternion.identity);
    }
}
