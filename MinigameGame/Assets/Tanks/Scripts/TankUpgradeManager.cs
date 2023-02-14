using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankUpgradeManager : MonoBehaviour
{
    // ONLY PUBLIC FOR GAMEMANAGER TEMPORARY CLASS:
    public GameObject[] AllTanks => allTanks;

    // TODO: DO IT SOME OTHER WAY
    [SerializeField] private GameObject[] allTanks;
    [SerializeField] private TankUpgradeController currentController;

    private void Start()
    {
        foreach (var tank in allTanks)
        {
            tank.SetActive(false);
        }

        allTanks[0].SetActive(true);
    }

    public GameObject GetCurrentTank()
    {
        return currentController.gameObject;
    }

    public GameObject[] GetPossibleTanks()
    {
        return currentController.AvailableUpgrades;
    }

    public void UpgradeToTank(GameObject upgradeTo)
    {
        // ToDo: Checks if Upgrade is valid.

        currentController.gameObject.SetActive(false);
        upgradeTo.SetActive(true);
        currentController = upgradeTo.GetComponent<TankUpgradeController>();
    }
}
