using System;
using Player.Controllers;
using UnityEngine;

namespace Player.Abilities
{
    public class PlayerJump : Ability
    {
        public Rigidbody rigidBody;
        private bool _isJumping;


        public override void Initialize(PlayerController playerController)
        {
            base.Initialize(playerController);
            rigidBody = playerController.rigidBody;
            if(playerController.isAI) return;
            _inputManager.OnJump += Jump;
        }


        public override void ProcessAbility()
        {
            base.ProcessAbility();
        }
        
        public override void UpdateAnimator()
        {
            base.UpdateAnimator();
            if (_isJumping)
            {
                _animator.Jump();
                _isJumping = false;
            }
        }
        
        private void Jump()
        {
            if (_playerController.grounded)
            {
                _isJumping = true; 
            }
        }

        private void OnDestroy()
        {
            _inputManager.OnJump -= Jump;
        }
    }
}