using UnityEngine;
using static PlayerStatsController;
using static PlayerExperienceManager;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerStatsController playerStatsController;
    [SerializeField] private PlayerStatsManager playerStatsManager;
    [SerializeField] private PlayerExperienceManager playerExperienceManager;
    [SerializeField] private PlayerMovementController playerMovementController;
    [SerializeField] private HealthSystem healthSystem;

    private void Awake()
    {
        playerStatsController = GetComponent<PlayerStatsController>();
        playerStatsManager = GetComponent<PlayerStatsManager>();
        playerExperienceManager = GetComponent<PlayerExperienceManager>();
        playerMovementController = GetComponent<PlayerMovementController>();
        healthSystem = HealthSystem.CreateComponent(this.gameObject, HealthSystem.HealthType.Player, playerStatsController.BaseStats[PlayerStats.MAXHP], true, playerStatsController.BaseStats[PlayerStats.HPREGEN], playerStatsController.Name);

        playerExperienceManager.OnUpgrade += HandleOnUpgrade;
        playerExperienceManager.OnLevelUp += HandleOnLevelUp;
    }

    private void HandleOnUpgrade(Upgradable upgradable, int upgradeCount)
    {
        switch (upgradable)
        {
            case Upgradable.MAXHP:
            case Upgradable.HPREGEN:
            case Upgradable.MAXSHIELD:
            case Upgradable.SHIELDREGEN:
                healthSystem.Upgrade(upgradable);
                break;
            case Upgradable.MOVEMENTSPEED:
                playerMovementController.speed = playerStatsManager.GetCurrentStats(PlayerStats.MOVEMENTSPEED);
                break;
            default:
                break;
        }
    }

    private void HandleOnLevelUp(int level, int upgradesLeft)
    {
        Camera.main.fieldOfView = playerStatsManager.GetCurrentStats(PlayerStats.FOV);
        this.gameObject.transform.localScale = Vector3.one * playerStatsManager.GetCurrentStats(PlayerStats.SIZE);
    }

    private void OnCollisionStay(Collision collision)
    {
        HealthSystem healthSystemOther = collision.gameObject.GetComponent<HealthSystem>();
        if (healthSystemOther)
        {
            switch (healthSystemOther.GetHealthType)
            {
                case HealthSystem.HealthType.Player:
                case HealthSystem.HealthType.Enemy:
                case HealthSystem.HealthType.Food:
                    healthSystemOther.TakeDamage(this.gameObject, playerStatsManager.GetCurrentStats(PlayerStats.BODYDAMAGE), true);
                    break;

                case HealthSystem.HealthType.Bullet:
                    // Don't do anything?
                    break;
                default:
                    break;
            }
        }
    }
}
