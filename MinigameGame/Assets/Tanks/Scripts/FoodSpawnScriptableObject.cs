using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/FoodSpawnScriptableObject", order = 1)]
public class FoodSpawnScriptableObject : ScriptableObject
{
    public GameObject FoodPrefab => foodPrefab;
    public float SpawnLimitMin => spawnLimitMin;
    public float SpawnLimitMax => spawnLimitMax;
    public float SpawnInterval => spawnInterval;

    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private float spawnLimitMin;
    [SerializeField] private float spawnLimitMax;
    [SerializeField] private float spawnInterval;
}
