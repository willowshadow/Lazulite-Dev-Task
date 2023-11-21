using Player.Controllers;
using UnityEngine;

namespace Player.Abilities
{
    public class PlayerMovement : Ability
    {
        public CharacterController characterController;
        public float speed;
        

        public override void Initialize(PlayerController playerController, InputManager inputManager)
        {
            base.Initialize(playerController, inputManager);
            characterController = playerController.characterController;
        }
        public override void ProcessAbility()
        {
            base.ProcessAbility();
            SetMovement(_inputManager.inputVector);
        }

        private void SetMovement(Vector2 input)
        {
            Vector3 moveVector = new Vector3(input.x, 0, input.y);
            characterController.Move(moveVector * (speed * Time.deltaTime));
        }
    }
}