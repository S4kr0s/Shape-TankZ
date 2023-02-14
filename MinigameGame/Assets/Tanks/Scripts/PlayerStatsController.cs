using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsController : MonoBehaviour
{
    // Non-Specific Stats
    public string Name => name;
    public Color Color => color;
    public Dictionary<PlayerStats, float> BaseStats => baseStats;
    public Dictionary<PlayerStats, float> StatsPerLevel => statsPerLevel;

    [SerializeField] private string name;
    [SerializeField] private Color color;

    private Dictionary<PlayerStats, float> baseStats = new Dictionary<PlayerStats, float>()
    {
        { PlayerStats.MAXHP,                    100f },
        { PlayerStats.HP,                       100f },
        { PlayerStats.HPREGEN,                  0.5f },
        { PlayerStats.MAXSHIELD,                50f },
        { PlayerStats.SHIELD,                   50f },
        { PlayerStats.SHIELDREGEN,              0.5f },
        { PlayerStats.SIZE,                     1 },
        { PlayerStats.MOVEMENTSPEED,            5 },
        { PlayerStats.BODYDAMAGE,               10 },
        { PlayerStats.FOV,                      5 },
        { PlayerStats.BULLETDAMAGEMODIFIER,     1 },
        { PlayerStats.TURRETFIRERATEMODIFIER,   1 },
        { PlayerStats.TURRETACCURACYMODIFIER,   1 },
        { PlayerStats.BULLETPENETRATIONMODIFIER,1 },
        { PlayerStats.BULLETSPEEDMODIFIER,      1 },
    };

    private Dictionary<PlayerStats, float> statsPerLevel = new Dictionary<PlayerStats, float>()
    {
        { PlayerStats.MAXHP,                    50f },
        { PlayerStats.HP,                       50f },
        { PlayerStats.HPREGEN,                  0.5f },
        { PlayerStats.MAXSHIELD,                25f },
        { PlayerStats.SHIELD,                   25f },
        { PlayerStats.SHIELDREGEN,              0.5f },
        { PlayerStats.SIZE,                     0.01f },
        { PlayerStats.MOVEMENTSPEED,            0.1f },
        { PlayerStats.BODYDAMAGE,               10 },
        { PlayerStats.FOV,                      0.5f },
        { PlayerStats.BULLETDAMAGEMODIFIER,     0.25f },
        { PlayerStats.TURRETFIRERATEMODIFIER,   -0.05f },
        { PlayerStats.TURRETACCURACYMODIFIER,   -0.05f },
        { PlayerStats.BULLETPENETRATIONMODIFIER,0.25f },
        { PlayerStats.BULLETSPEEDMODIFIER,      0.1f },
    };

    public enum PlayerStats
    {
        MAXHP,
        HP,
        HPREGEN,
        MAXSHIELD,
        SHIELD,
        SHIELDREGEN,
        SIZE,
        MOVEMENTSPEED,
        BODYDAMAGE,
        FOV,
        BULLETDAMAGEMODIFIER,
        TURRETFIRERATEMODIFIER,
        TURRETACCURACYMODIFIER,
        BULLETPENETRATIONMODIFIER,
        BULLETSPEEDMODIFIER
    }
}