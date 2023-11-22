using System;
using System.Collections.Generic;
using CHARK.ScriptableEvents.Events;
using DG.Tweening;
using Player.Abilities;
using Player.Controllers;
using UI;
using UnityEngine;

namespace Utils
{
    public class MatchController : MonoBehaviour
    {
        
        public PlayerController player,enemy;
        public TransformScriptableEvent winner;

        public void Awake()
        {
            PlayerController.onPlayerSpawn += OnPlayerSpawn;
            PlayerController.onAISpawn += OnAISpawn;
            Health.onDeath += OnDeath;

        }

        private void OnDeath()
        {
            CheckWinner();
        }

        private void OnAISpawn(PlayerController obj)
        {
              enemy = obj;   
        }

        private void OnPlayerSpawn(PlayerController obj)
        {
            player = obj;
        }

        private void CheckWinner()
        {
            DOVirtual.DelayedCall(1f, (() =>
            {
                if(enemy.isDead)
                    winner.Raise(player.transform);
                else if(player.isDead)
                    winner.Raise(enemy.transform);
            }));
        }
    }
}