using System;
using CHARK.ScriptableEvents.Events;
using DG.Tweening;
using Player.Controllers;
using UnityEngine;

namespace Player.Abilities
{
    public class Health : MonoBehaviour
    {
        public int health;
        public int maxHealth;
        public PlayerController playerController;
        public FloatScriptableEvent onHealthChange;
        public FloatScriptableEvent onMaxHealth;

        private void Awake()
        {
            playerController = GetComponent<PlayerController>();
            health = maxHealth;
            onMaxHealth.Raise(maxHealth);
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            onHealthChange.Raise(health);
            if (health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            playerController.animationController.Death();
            DOVirtual.DelayedCall(2f, () =>
            {
                Destroy(gameObject);
            });
        }
    }
}