using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStatsController : MonoBehaviour
{
    public float Health => health;
    public float Damage => damage;
    public float MovementSpeed => movementSpeed;
    public float Lifetime => lifetime;
    public float Size => size;

    [SerializeField] private float health;
    [SerializeField] private float damage;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float lifetime;
    [SerializeField] private float size;
}
