using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExperienceManager : MonoBehaviour
{
    public double Experience => experience;
    public double ExperienceNeeded => experienceNeeded;
    public int Level => level;
    public int UpgradesLeft => upgradesLeft;
    public int TransformationUpgradesLeft => transformationUpgradesLeft;
    public Dictionary<Upgradable, int> Upgrades => upgradeValues;

    [SerializeField] private double experience;
    [SerializeField] private double experienceNeeded = 100;
    [SerializeField] private double lastExperienceNeeded = 0;
    [SerializeField] private int level;
    [SerializeField] private int upgradesLeft;
    [SerializeField] private int transformationUpgradesLeft;

    [SerializeField]
    private Dictionary<Upgradable, int> upgradeValues = new Dictionary<Upgradable, int>()
    {
        { Upgradable.MAXHP, 0 },
        { Upgradable.HPREGEN, 0 },
        { Upgradable.MAXSHIELD, 0 },
        { Upgradable.SHIELDREGEN, 0 },
        { Upgradable.MOVEMENTSPEED, 0 },
        { Upgradable.BODYDAMAGE, 0 },
        { Upgradable.BULLETDAMAGE, 0 },
        { Upgradable.TURRETFIRERATE, 0 },
        { Upgradable.TURRETACCURACY, 0 },
        { Upgradable.BULLETPENETRATION, 0 },
        { Upgradable.BULLETSPEED, 0 },
    };

    // Arg1: Upgradable
    // Arg2: Current Level of Upgradable
    public event Action<Upgradable, int> OnUpgrade;

    // Arg1: Current Level
    // Arg2: Upgrades Left
    public event Action<int, int> OnLevelUp;

    // Arg1: Current Level
    // Arg2: Transformation Upgrade Count
    public event Action<int, int> OnTransformationUpgradeGained;

    // Arg1: Last Experience Threshold
    // Arg2: Experience Needed
    // Arg3: Current Experience
    public event Action<double, double, double> OnExperienceGained;

    public void AddExperience(double _experience)
    {
        experience += _experience;
        OnExperienceGained(GetCurrentLevelRequirement(), GetNextLevelRequirement(), experience);

        if (experience >= experienceNeeded)
        {
            LevelUp();
        }
    }

    public double GetNextLevelRequirement()
    {
        if (level == 0)
            return 100;

        return 35 * Mathf.Pow(level + (int)(level / 10) + 1, 2);
    }

    public double GetCurrentLevelRequirement()
    {
        return lastExperienceNeeded;
    }

    private void LevelUp()
    {
        level++;
        upgradesLeft++;
        lastExperienceNeeded = experienceNeeded;
        experienceNeeded = GetNextLevelRequirement();
        OnLevelUp?.Invoke(level, upgradesLeft);

        if (experience >= experienceNeeded)
            LevelUp();

        if (level % 10 == 0)
        {
            transformationUpgradesLeft++;
            OnTransformationUpgradeGained?.Invoke(level, transformationUpgradesLeft);
        }
    }

    public void Upgrade(Upgradable whatToUpgrade)
    {
        if (upgradesLeft <= 0)
            return;

        upgradeValues[whatToUpgrade] += 1;
        upgradesLeft--;
        OnUpgrade?.Invoke(whatToUpgrade, upgradeValues[whatToUpgrade]);
    }

    public void RemoveOneTransformationUpgade()
    {
        transformationUpgradesLeft--;
    }

    public enum Upgradable
    {
        // TANK-SPECIFIC:
        MAXHP = 0,
        HPREGEN = 1,
        MAXSHIELD = 2,
        SHIELDREGEN = 3,
        MOVEMENTSPEED = 4,
        BODYDAMAGE = 5,

        // PROJECTILE-SPECIFIC:
        BULLETDAMAGE = 6,
        TURRETFIRERATE = 7,
        TURRETACCURACY = 8,
        BULLETPENETRATION = 9,
        BULLETSPEED = 10,
    }
}
