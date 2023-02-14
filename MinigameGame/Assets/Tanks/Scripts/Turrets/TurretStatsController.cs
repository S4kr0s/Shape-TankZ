using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretStatsController : MonoBehaviour
{
    public float Spread => spread;
    public float FireRate => fireInterval;
    public TurretVariant TurretVariant => turretVariant;

    // 0 >= 360 (degrees). On 0, the shots have total accuracy.
    [SerializeField] private float spread;
    // The higher, the longer it takes to shoot.
    [SerializeField] private float fireInterval;
    [SerializeField] private TurretVariant turretVariant;
}

public enum TurretVariant
{
    NONE,
    AUTOAIM,
    CURSORAIM
}
