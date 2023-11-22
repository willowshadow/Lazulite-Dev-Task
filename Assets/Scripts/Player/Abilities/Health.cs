using System;
using CHARK.ScriptableEvents.Events;
using DG.Tweening;
using Player.Controllers;
using UnityEngine;

namespace Player.Abilities
{
    public interface IDamageable
    {
        bool TakeDamage(float damage);
    }

    public class Health : MonoBehaviour, IDamageable
    {
        public float health;
        public int maxHealth;
        public PlayerController playerController;
        public FloatScriptableEvent onHealthChange;
        public FloatScriptableEvent onMaxHealth;

        public static event Action onDeath;
        private void Awake()
        {
            playerController = GetComponent<PlayerController>();
            health = maxHealth;
            onMaxHealth.Raise(maxHealth);
        }

        public bool TakeDamage(float damage)
        {
            health -= damage;
            onHealthChange.Raise(health);
            if (health <= 0)
            {
                Die();
                return true;
            }
            return false;
        }

        private void Die()
        {
            playerController.animationController.Death();
            playerController.isDead = true;
            onDeath?.Invoke();
            DOVirtual.DelayedCall(2f, () =>
            {
                Destroy(gameObject);
            });
        }
    }
}