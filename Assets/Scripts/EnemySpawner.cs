using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;

    [SerializeField]
    float yOffset = 0f;

    [SerializeField]
    int amount = 10;

    [SerializeField]
    float Radius = 100f;

    void Start()
    {
        SpawnEnemiesRandomly();
    }

    private void SpawnEnemiesRandomly()
    {
        int i = amount;
        while (i > 0)
        {
            SpawnEnemyRandomly();
            --i;
        }
    }

    void SpawnEnemyRandomly()
    {
        float randX = Random.Range(-Radius, Radius);   
        float randZ = Random.Range(-Radius, Radius);
        float yValue = Terrain.activeTerrain.SampleHeight(new Vector3(randX, 0, randZ));
        
        yValue = yValue + yOffset;
        GameObject enemy = Instantiate(enemyPrefab, new Vector3(randX, yValue, randZ), Quaternion.identity);
        enemy.transform.parent = transform;
    }
}
