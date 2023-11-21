using System;
using Player.Abilities;
using UnityEngine;

namespace Common
{
    public class DamageOnContact : MonoBehaviour
    {
        public LayerMask damageLayer;
        public int damage;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == damageLayer.value)
            {
                var health = other.GetComponent<Health>();
                if (health != null)
                {
                    health.TakeDamage(damage);
                }
            }
        }
    }
}