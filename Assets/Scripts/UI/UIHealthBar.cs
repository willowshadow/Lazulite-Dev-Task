using System;
using CHARK.ScriptableEvents.Events;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIHealthBar : MonoBehaviour
    {
        public FloatScriptableEvent onHealthChange;
        public FloatScriptableEvent onMaxHealth;

        public Slider healthBar;
        
        private float health,maxHealth;
        private void Awake()
        {
            onMaxHealth.AddListener(SetHealthBarMax);
            onHealthChange.AddListener(SetHealthBar);
        }

        [Button]
        private void SetHealthBarMax(float maxHealth)
        {
            this.maxHealth = maxHealth;
            healthBar.maxValue = maxHealth;
            healthBar.value = maxHealth;
        }
        [Button]
        private void SetHealthBar(float health)
        {
            this.health = health;
            healthBar.DOValue(health, 0.5f);
        }
        
    }
}