using UnityEngine;
using static PlayerStatsController;
using static PlayerExperienceManager;

public class PlayerStatsManager : MonoBehaviour
{
    [SerializeField] private PlayerStatsController statsController;
    [SerializeField] private PlayerExperienceManager experienceManager;
    [SerializeField] private HealthSystem healthSystem;

    public float GetCurrentStats(PlayerStatsController.PlayerStats playerStat)
    {
        switch (playerStat)
        {
            case PlayerStatsController.PlayerStats.MAXHP:
                return statsController.BaseStats[PlayerStats.MAXHP] + (statsController.StatsPerLevel[PlayerStats.MAXHP] * experienceManager.Upgrades[Upgradable.MAXHP]);

            case PlayerStatsController.PlayerStats.HP:
                return healthSystem.Health;
            case PlayerStatsController.PlayerStats.HPREGEN:
                return statsController.BaseStats[PlayerStats.HPREGEN] + (statsController.StatsPerLevel[PlayerStats.HPREGEN] * experienceManager.Upgrades[Upgradable.HPREGEN]);

            case PlayerStatsController.PlayerStats.MAXSHIELD:
                return statsController.BaseStats[PlayerStats.MAXSHIELD] + (statsController.StatsPerLevel[PlayerStats.MAXSHIELD] * experienceManager.Upgrades[Upgradable.MAXSHIELD]);

            case PlayerStatsController.PlayerStats.SHIELD:
                // TODO: SHIELD
                return healthSystem.Health;

            case PlayerStatsController.PlayerStats.SHIELDREGEN:
                return statsController.BaseStats[PlayerStats.SHIELDREGEN] + (statsController.StatsPerLevel[PlayerStats.SHIELDREGEN] * experienceManager.Upgrades[Upgradable.SHIELDREGEN]);

            case PlayerStatsController.PlayerStats.SIZE:
                return statsController.BaseStats[PlayerStats.SIZE] + (statsController.StatsPerLevel[PlayerStats.SIZE] * experienceManager.Level);

            case PlayerStatsController.PlayerStats.MOVEMENTSPEED:
                return statsController.BaseStats[PlayerStats.MOVEMENTSPEED] + (statsController.StatsPerLevel[PlayerStats.MOVEMENTSPEED] * experienceManager.Upgrades[Upgradable.MOVEMENTSPEED]);

            case PlayerStatsController.PlayerStats.BODYDAMAGE:
                return statsController.BaseStats[PlayerStats.BODYDAMAGE] + (statsController.StatsPerLevel[PlayerStats.BODYDAMAGE] * experienceManager.Upgrades[Upgradable.BODYDAMAGE]);

            case PlayerStatsController.PlayerStats.FOV:
                return statsController.BaseStats[PlayerStats.FOV] + (statsController.StatsPerLevel[PlayerStats.FOV] * experienceManager.Level);

            case PlayerStatsController.PlayerStats.BULLETDAMAGEMODIFIER:
                return statsController.BaseStats[PlayerStats.BULLETDAMAGEMODIFIER] + (statsController.StatsPerLevel[PlayerStats.BULLETDAMAGEMODIFIER] * experienceManager.Upgrades[Upgradable.BULLETDAMAGE]);

            case PlayerStatsController.PlayerStats.TURRETFIRERATEMODIFIER:
                return statsController.BaseStats[PlayerStats.TURRETFIRERATEMODIFIER] + (statsController.StatsPerLevel[PlayerStats.TURRETFIRERATEMODIFIER] * experienceManager.Upgrades[Upgradable.TURRETFIRERATE]);

            case PlayerStatsController.PlayerStats.TURRETACCURACYMODIFIER:
                return statsController.BaseStats[PlayerStats.TURRETACCURACYMODIFIER] + (statsController.StatsPerLevel[PlayerStats.TURRETACCURACYMODIFIER] * experienceManager.Upgrades[Upgradable.TURRETACCURACY]);

            case PlayerStatsController.PlayerStats.BULLETPENETRATIONMODIFIER:
                return statsController.BaseStats[PlayerStats.BULLETPENETRATIONMODIFIER] + (statsController.StatsPerLevel[PlayerStats.BULLETPENETRATIONMODIFIER] * experienceManager.Upgrades[Upgradable.BULLETPENETRATION]);

            case PlayerStatsController.PlayerStats.BULLETSPEEDMODIFIER:
                return statsController.BaseStats[PlayerStats.BULLETSPEEDMODIFIER] + (statsController.StatsPerLevel[PlayerStats.BULLETSPEEDMODIFIER] * experienceManager.Upgrades[Upgradable.BULLETSPEED]);

            throw new System.NotImplementedException();
        }
        throw new System.NotImplementedException();
    }
}
