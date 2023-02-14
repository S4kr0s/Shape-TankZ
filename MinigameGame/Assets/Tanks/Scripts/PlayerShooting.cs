using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private TurretBase[] turrets;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            foreach (TurretBase turret in turrets)
            {
                if (turret == null)
                    return;

                if (!turret.gameObject.activeSelf)
                    return;

                turret.AttemptShoot();
            }
        }
    }
}
