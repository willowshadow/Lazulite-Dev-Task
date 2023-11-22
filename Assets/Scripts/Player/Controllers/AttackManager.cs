using System;
using DG.Tweening;
using Player.Actions.Attack;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Player.Controllers
{
    public class AttackManager : MonoBehaviour
    {
        public PlayerController playerController;
        public Attack fireAttack; 
        public Attack swipeAttack; 
        public Attack fireBallAttack;
        public Attack tailAttack;

        public InputManager inputManager;

        public float coolDownMax;
        public float coolDownTimer;

        private void Awake()
        {
            playerController = GetComponent<PlayerController>();
            fireAttack = GetComponentInChildren<FireAttack>();
            swipeAttack = GetComponentInChildren<MeleeAttack>();
            fireBallAttack = GetComponentInChildren<FireBallAttack>();
            tailAttack = GetComponentInChildren<TailAttack>();
            
            if(playerController.isAI) return;
            inputManager.OnPrimaryAttack += SwipeAttack;
            inputManager.OnSecondaryAttack += ExecuteSecondaryAttack;
            inputManager.OnAbility1 += FireBallAttack;
            inputManager.OnAbility2 += TailAttack;
            inputManager.OnAbility3 += FireAttack;
        }
        
        public void CoolDown()
        {
            coolDownTimer = 1;
            DOVirtual.DelayedCall(coolDownMax, () =>
            {
                coolDownTimer = 0;
            });
        }
     
        public void TailAttack()
        {
            if(coolDownTimer > 0) return;
            tailAttack.ExecuteAttack();
            CoolDown();
        }

        public void FireBallAttack()
        {
            if(coolDownTimer > 0) return;
            fireBallAttack.ExecuteAttack();
            CoolDown();
        }
        public void FireAttack()
        {
            if(coolDownTimer > 0) return;
            fireAttack.ExecuteAttack();
            CoolDown();
        }

        public void ExecuteSecondaryAttack()
        {
            //throw new NotImplementedException();
        }

        public void SwipeAttack()
        {
            if(coolDownTimer > 0) return;
            swipeAttack.ExecuteAttack();
            CoolDown();
        }

        private void OnDestroy()
        {
            if(playerController.isAI) return;
            inputManager.OnPrimaryAttack -= SwipeAttack;
            inputManager.OnSecondaryAttack -= ExecuteSecondaryAttack;
            inputManager.OnAbility1 -= FireBallAttack;
            inputManager.OnAbility2 -= TailAttack;
            inputManager.OnAbility3 -= FireAttack;
        }
    }
}