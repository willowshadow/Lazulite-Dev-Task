using Player.Controllers;
using UnityEngine;

namespace Player.Abilities
{
    public class PlayerJump : Ability
    {
        public Rigidbody rigidBody;
        public float speed;
        private bool _isJumping;


        public override void Initialize(PlayerController playerController, InputManager inputManager)
        {
            base.Initialize(playerController, inputManager);
            rigidBody = playerController.rigidBody;
        }
        public override void ProcessAbility()
        {
            base.ProcessAbility();
            Jump(_inputManager.jump);
        }

        private void Jump(bool shouldJump)
        {
            if(_isJumping) return;
            if(!shouldJump) return;
            _isJumping = true;
            _playerController.animationController.Jump();
        }
    }
}