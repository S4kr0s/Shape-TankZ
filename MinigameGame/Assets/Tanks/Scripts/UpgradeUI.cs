using Michsky.MUIP;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private PlayerExperienceManager playerExperienceManager;
    [SerializeField] private TankUpgradeManager tankUpgradeManager;
    [SerializeField] private ProgressBar[] progressBars;
    [SerializeField] private GameObject transformationUpgradePanel;
    [SerializeField] private GameObject transformationUpgradeButtonPrefab;

    private void Start()
    {
        playerExperienceManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerExperienceManager>();
        tankUpgradeManager = GameObject.FindGameObjectWithTag("Player").GetComponent<TankUpgradeManager>();
        playerExperienceManager.OnUpgrade += HandleOnUpgrade;
        playerExperienceManager.OnLevelUp += HandleOnLevelUp;
        playerExperienceManager.OnTransformationUpgradeGained += HandleTransformationUpgradeGained;
    }

    public void Upgrade(int upgradable)
    {
        playerExperienceManager.Upgrade((PlayerExperienceManager.Upgradable)upgradable);
    }

    private void HandleOnUpgrade(PlayerExperienceManager.Upgradable upgradable, int upgradeCount)
    {
        progressBars[(int)upgradable].ChangeValue(upgradeCount);
    }

    private void HandleOnLevelUp(int level, int upgradesLeft)
    {
        // Todo: Activate Upgrade Buttons.
    }

    private void HandleTransformationUpgradeGained(int level, int transformationUpgradeCount)
    {
        if (tankUpgradeManager.GetPossibleTanks() == null)
            return;

        if (tankUpgradeManager.GetPossibleTanks().Length == 0)
            return;

        for (int i = 0; i < tankUpgradeManager.GetPossibleTanks().Length; i++)
        {
            GameObject UpgradingTank = tankUpgradeManager.GetPossibleTanks()[i];
            GameObject instance = Instantiate(transformationUpgradeButtonPrefab, transformationUpgradePanel.transform);
            instance.GetComponentInChildren<TMP_Text>().text = UpgradingTank.name;
            int a = new int(); a = i;
            instance.GetComponent<Button>().onClick.AddListener(() => OnClickTransformationUpgrade(a));
        }

        transformationUpgradePanel.SetActive(true);
    }

    private void OnClickTransformationUpgrade(int indexTransformationUpgrade)
    {
        GameObject upgradeTo = tankUpgradeManager.GetPossibleTanks()[indexTransformationUpgrade];
        tankUpgradeManager.UpgradeToTank(upgradeTo);
        
        foreach (Transform child in transformationUpgradePanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        transformationUpgradePanel.SetActive(false);
        playerExperienceManager.RemoveOneTransformationUpgade();

        if (playerExperienceManager.TransformationUpgradesLeft > 0)
            HandleTransformationUpgradeGained(playerExperienceManager.Level, playerExperienceManager.TransformationUpgradesLeft);
    }
}
