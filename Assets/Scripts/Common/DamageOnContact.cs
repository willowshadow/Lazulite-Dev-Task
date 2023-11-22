using System;
using DG.Tweening;
using Player.Abilities;
using UnityEngine;

namespace Common
{
    public class DamageOnContact : MonoBehaviour
    {
        public GameObject owner;
        public int damage;
        public float coolDown;
        
        private void Start()
        {
            owner ??= transform.root.gameObject;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(owner == other.gameObject) return;
            if(other.gameObject.transform.IsChildOf(owner.transform)) return;
            if (coolDown > 0) return;
            Debug.Log("OnTriggerEnter " + other.gameObject.name,this);
            var health = other.GetComponent<IDamageable>();
            if (health != null)
            {
                health.TakeDamage(damage);
                coolDown = 1;
                DOVirtual.DelayedCall(coolDown, () => { coolDown = 0; });
            }
        }
    }
}