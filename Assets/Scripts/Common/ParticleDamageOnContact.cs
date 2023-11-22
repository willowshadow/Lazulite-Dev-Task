using System;
using Player.Abilities;
using UnityEngine;

namespace Common
{
    public class ParticleDamageOnContact : MonoBehaviour
    {
        public LayerMask damageLayer;
        public float damage;

        private void OnParticleTrigger()
        {
            var health = GetComponent<IDamageable>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }
}