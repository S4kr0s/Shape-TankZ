using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerStatsController.PlayerStats;

public abstract class TurretBase : MonoBehaviour
{
    [SerializeField] protected Transform[] shootingPoints;
    [SerializeField] protected Bullet bullet;

    [SerializeField] protected BulletStatsController bulletStats;
    [SerializeField] protected PlayerStatsController playerStats;
    [SerializeField] protected TurretStatsController turretStats;
    [SerializeField] protected PlayerStatsManager playerStatsManager;

    protected float currentFireInterval = 0f;

    // Maybe Start() instead.
    private void Awake()
    {
        bulletStats = this.gameObject.GetComponent<BulletStatsController>();
        playerStats = this.gameObject.GetComponentInParent<PlayerStatsController>();
        turretStats = this.gameObject.GetComponent<TurretStatsController>();
        playerStatsManager = this.gameObject.GetComponentInParent<PlayerStatsManager>();
        // Todo: Set Color and stuff
    }

    private void Update()
    {
        currentFireInterval -= Time.deltaTime;
    }

    public void AttemptShoot()
    {
        if (!this.transform.parent.gameObject.activeSelf)
            return;

        if (currentFireInterval <= 0)
        {
            currentFireInterval = turretStats.FireRate * playerStatsManager.GetCurrentStats(TURRETFIRERATEMODIFIER);
            Shoot();
        }
    }

    protected abstract void Shoot();
}