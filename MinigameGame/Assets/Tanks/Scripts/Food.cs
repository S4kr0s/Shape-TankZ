using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float FoodValue => foodValue;
    [SerializeField] private float foodValue;
    [SerializeField] private HealthSystem healthSystem;

    void Start()
    {
        healthSystem = HealthSystem.CreateComponent(this.gameObject, HealthSystem.HealthType.Food, foodValue, false);
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
                case HealthSystem.HealthType.Bullet:
                    healthSystemOther.TakeDamage(this.gameObject, foodValue, true);
                    break;

                case HealthSystem.HealthType.Food:
                    // Don't do anything.
                    break;
                default:
                    break;
            }
        }
    }
}
