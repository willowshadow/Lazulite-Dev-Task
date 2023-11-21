using System;
using Player.Abilities;
using UnityEngine;

namespace Common
{
    public class ParticleDamageOnContact : MonoBehaviour
    {
        public LayerMask damageLayer;
        public int damage;

        private void OnParticleTrigger()
        {
            var health = GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }
}