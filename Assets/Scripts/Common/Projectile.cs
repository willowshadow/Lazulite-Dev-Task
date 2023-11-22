using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Common
{
    public class Projectile : MonoBehaviour
    {
        public Rigidbody rb;
        public float force = 100;
        public GameObject onHitEffect;
        public DamageOnContact damageOnContact;

        private void Awake()
        {
            damageOnContact = GetComponent<DamageOnContact>();
        }

        public void Shoot(Vector3 direction)
        {
            rb.AddForce(direction * force);
            Destroy(gameObject, 5f);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(onHitEffect != null)
                Instantiate(onHitEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}