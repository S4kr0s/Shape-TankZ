using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private HealthSystem healthSystem;
    [SerializeField] private EnemyStatsController enemyStats;
    void Start()
    {
        healthSystem = HealthSystem.CreateComponent(this.gameObject, HealthSystem.HealthType.Enemy, enemyStats.MaxHP, true, enemyStats.HPRegen);
    }
}
