using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawnManager : MonoBehaviour
{
    [SerializeField] private FoodSpawnScriptableObject[] foodSpawns;

    void Start()
    {
        foreach (FoodSpawnScriptableObject foodSpawnSO in foodSpawns)
        {
            StartCoroutine(SpawnFood(foodSpawnSO.FoodPrefab, foodSpawnSO.SpawnLimitMin, foodSpawnSO.SpawnLimitMax, foodSpawnSO.SpawnInterval)); 
        }
    }

    IEnumerator SpawnFood(GameObject foodPrefab, float spawnLimitMin, float spawnLimitMax, float spawnInterval)
    {
        while (true)
        {
            Vector3 spawnPos = new Vector3(Random.Range(spawnLimitMin, spawnLimitMax), 0.2f, Random.Range(spawnLimitMin, spawnLimitMax));

            Instantiate(foodPrefab, spawnPos, foodPrefab.transform.rotation);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
