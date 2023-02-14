using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Todo: Add Bullet Type
    // Todo: How to handle different mats? + Outline Color

    // VERY UNSAFE FIX IMMEDIATELY
    public string Identifier;

    [SerializeField] private HealthSystem healthSystem;
    [SerializeField] private Rigidbody rigidbody;

    [SerializeField] private PlayerExperienceManager playerExperienceManager;
    [SerializeField] private Color color;
    [SerializeField] private float health;
    [SerializeField] private float damage;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float lifetime;
    [SerializeField] private float size;

    private GameObject lastHit;
    private float invulnerableTimer = 0.5f;
    private float currentInvulnerableTimer;

    public void SetParameters(float _health, float _movementSpeed, float _lifetime, float _size, Color _color, float _damage)
    {
        SetParameters(health, _movementSpeed, _lifetime, _size, _color, _damage, false, null);
    }

    public void SetParameters(float _health, float _movementSpeed, float _lifetime, float _size, Color _color, float _damage, bool _isFromPlayer, PlayerExperienceManager _playerExperienceManager)
    {
        health = _health;
        movementSpeed = _movementSpeed;
        lifetime = _lifetime;
        size = _size;
        color = _color;
        damage = _damage;
        if (_isFromPlayer)
            playerExperienceManager = _playerExperienceManager;
    }

    void Start()
    {
        healthSystem = HealthSystem.CreateComponent(this.gameObject, HealthSystem.HealthType.Bullet, health, false, 0, Identifier);
        rigidbody = GetComponent<Rigidbody>();

        this.gameObject.GetComponent<MeshRenderer>().material.color = color;

        this.gameObject.GetComponent<Outline>().OutlineColor = ColorBrightness.ChangeColorBrightness(color);

        this.gameObject.transform.localScale *= size;

        Destroy(this.gameObject, lifetime);
    }

    private void Update()
    {
        if (lastHit == null)
            return;

        if (currentInvulnerableTimer > 0)
        {
            currentInvulnerableTimer -= Time.deltaTime;
            return;
        }

        lastHit = null;
    }

    private void FixedUpdate()
    {
        // Gotta go fast, magic number movement speed
        Vector3 movingPosition = rigidbody.position + transform.up * (movementSpeed * Time.deltaTime);
        rigidbody.MovePosition(movingPosition);
    }

    private void OnTriggerStay(Collider collider)
    {
        HealthSystem healthSystemOther = collider.gameObject.GetComponent<HealthSystem>();
        if (healthSystemOther)
        {
            switch (healthSystemOther.GetHealthType)
            {
                case HealthSystem.HealthType.Player:
                case HealthSystem.HealthType.Enemy:
                case HealthSystem.HealthType.Bullet:
                case HealthSystem.HealthType.Food:

                    if (lastHit != null && lastHit == healthSystemOther.gameObject)
                        return;

                    healthSystemOther.OnDeath += OnKill;
                    // TODO: MAKE BULLETS NON-MELEE, DAMAGE SOMETIMES TRIGGERS TWICE OR THRICE
                    healthSystemOther.TakeDamage(playerExperienceManager.gameObject, damage, false);
                    healthSystemOther.OnDeath -= OnKill;
                    healthSystem.TakeDamage(healthSystemOther.gameObject, healthSystemOther.Health + damage, false);

                    currentInvulnerableTimer = invulnerableTimer;
                    lastHit = healthSystemOther.gameObject;
                    break;

                default:
                    break;
            }
        }
    }

    private void OnKill(GameObject killer, double experience)
    {
        if (killer == null)
            return;

        if (killer != playerExperienceManager.gameObject)
            return;

        playerExperienceManager.AddExperience(experience);
    }
}
