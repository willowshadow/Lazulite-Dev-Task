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
        }
        public override void ProcessAbility()
        {
            base.ProcessAbility();
            Jump(_inputManager.jump);
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

        private void Jump(bool shouldJump)
        {
            if (!shouldJump || _isJumping || !_playerController.grounded)
            {
                return;
            }

            Debug.Log("Jumping");
            _isJumping = true;
        }
    }
}