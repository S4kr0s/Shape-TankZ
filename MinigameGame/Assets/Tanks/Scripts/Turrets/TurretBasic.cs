using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBasic : TurretBase
{
    protected override void Shoot()
    {
        foreach (Transform shootingPoint in shootingPoints)
        {
            float accuracy = Mathf.Clamp(turretStats.Spread * playerStatsManager.GetCurrentStats(PlayerStatsController.PlayerStats.TURRETACCURACYMODIFIER), 0, 360);
            float damageMod = playerStatsManager.GetCurrentStats(PlayerStatsController.PlayerStats.BULLETDAMAGEMODIFIER);
            float penMod = playerStatsManager.GetCurrentStats(PlayerStatsController.PlayerStats.BULLETPENETRATIONMODIFIER);
            float speedMod = playerStatsManager.GetCurrentStats(PlayerStatsController.PlayerStats.BULLETSPEEDMODIFIER);

            float spreadZ = Random.Range(-accuracy, accuracy);
            bullet.gameObject.SetActive(false);
            Bullet _bullet = Instantiate(bullet, shootingPoint.position, shootingPoint.rotation, null);
            _bullet.transform.Rotate(0, 0, spreadZ);
            _bullet.Identifier = this.gameObject.GetComponentInParent<HealthSystem>().Identifier;
            _bullet.SetParameters(bulletStats.Health * penMod, bulletStats.MovementSpeed * speedMod, bulletStats.Lifetime, bulletStats.Size, playerStats.Color, bulletStats.Damage * damageMod, true, GetComponentInParent<PlayerExperienceManager>());
            _bullet.gameObject.SetActive(true);
        }
    }
}
