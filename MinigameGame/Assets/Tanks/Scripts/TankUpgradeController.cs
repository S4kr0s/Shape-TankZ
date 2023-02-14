using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankUpgradeController : MonoBehaviour
{
    public GameObject[] AvailableUpgrades => availableUpgrades;

    [SerializeField] private GameObject[] availableUpgrades;
}
