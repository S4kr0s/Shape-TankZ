using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerExperienceManager;
using static PlayerStatsController;

public class HealthSystem : MonoBehaviour
{
    public float MaxHealth => maxHealth;
    public float Health => health;
    //public float MaxShield => maxShield;
    //public float Shield => shield;
    public HealthType GetHealthType => healthType;

    [SerializeField] private float maxHealth;
    [SerializeField] private float health;
    [SerializeField] private float healthRegen;
    //[SerializeField] private float maxShield;
    //[SerializeField] private float shield;
    [SerializeField] private HealthType healthType;

    [SerializeField] private float invulnerableMeleeTimer = 0.5f;
    private float currentInvulnerableMeleeTimer;
    [SerializeField] private float regenerationTimer = 0.5f;
    private float currentRegenerationTimer;

    private bool doesRegenerate = false;

    public string Identifier => identifier;
    [SerializeField] private string identifier;

    public event Action<GameObject, double> OnDeath;

    private void Update()
    {
        currentInvulnerableMeleeTimer -= Time.deltaTime;

        if (doesRegenerate)
        {
            currentRegenerationTimer -= Time.deltaTime;

            if (currentRegenerationTimer <= 0)
            {
                currentRegenerationTimer = regenerationTimer;
                health = Mathf.Clamp(health + healthRegen, 0, maxHealth);
            }
        }
    }

    public static HealthSystem CreateComponent(GameObject where, HealthType _healthType, float _maxHealth, bool _doesRegenerate)
    {
        return CreateComponent(where, _healthType, _maxHealth, _doesRegenerate, 0);
    }

    public static HealthSystem CreateComponent(GameObject where, HealthType _healthType, float _maxHealth, bool _doesRegenerate, float _healthRegen)
    {
        return CreateComponent(where, _healthType, _maxHealth, _doesRegenerate, _healthRegen, where.gameObject.name);
    }

    // Add Shield
    public static HealthSystem CreateComponent(GameObject where, HealthType _healthType, float _maxHealth, bool _doesRegenerate, float _healthRegen, string _identifier)
    {
        HealthSystem healthSystem = where.AddComponent<HealthSystem>();
        healthSystem.maxHealth = _maxHealth;
        healthSystem.health = _maxHealth;
        healthSystem.healthType = _healthType;
        healthSystem.doesRegenerate = _doesRegenerate;
        healthSystem.healthRegen = _healthRegen;
        healthSystem.identifier = _identifier;
        return healthSystem;
    }

    public void TakeDamage(GameObject from, float damage, bool isMelee)
    {
        if (from.GetComponent<HealthSystem>().identifier == identifier)
            return;

        if (currentInvulnerableMeleeTimer <= 0 && isMelee)
        {
            currentInvulnerableMeleeTimer = invulnerableMeleeTimer;
        }
        else if (isMelee)
        {
            return;
        }

        health -= damage;

        if (health <= 0)
            Die(from);
    }

    private void Die(GameObject killer)
    {
        Debug.Log("Deadge");
        // TODO: CHANGE HEALTH TO ACTUAL EXPERIENCE.
        OnDeath?.Invoke(killer, maxHealth);
        Destroy(this.gameObject);
    }

    // Only call when bound to a player
    // TODO: Implement Shield
    public void Upgrade(Upgradable upgradable)
    {
        PlayerStatsManager playerStatsManager = this.gameObject.GetComponent<PlayerStatsManager>();

        switch (upgradable)
        {
            case Upgradable.MAXHP:
                health += playerStatsManager.GetCurrentStats(PlayerStats.MAXHP) - maxHealth;
                maxHealth = playerStatsManager.GetCurrentStats(PlayerStats.MAXHP);
                break;
            case Upgradable.HPREGEN:
                healthRegen = playerStatsManager.GetCurrentStats(PlayerStats.HPREGEN);
                break;
            case Upgradable.MAXSHIELD:
                // playerStatsManager.GetCurrentStats(PlayerStats.MAXSHIELD);
                break;
            case Upgradable.SHIELDREGEN:
                // playerStatsManager.GetCurrentStats(PlayerStats.SHIELDREGEN);
                break;
            default:
                return;
        }
    }

    public enum HealthType
    {
        Player,
        Bullet,
        Enemy,
        Food
    }
}
