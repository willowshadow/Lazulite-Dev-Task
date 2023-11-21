using Player.Controllers;
using UnityEngine;

namespace Player.Abilities
{
    public class PlayerMovement : Ability
    {
        public CharacterController characterController;
        public float speed;
        public Vector2 inputVector;

        public override void Initialize(PlayerController playerController )
        {
            base.Initialize(playerController);
            characterController = playerController.characterController;
        }
        public override void ProcessAbility()
        {
            base.ProcessAbility();
            HandledInput();
            SetMovement(inputVector);
        }

        private void HandledInput()
        { 
            inputVector = Vector2.MoveTowards(inputVector, _inputManager.inputVector, Time.deltaTime);
        }

        override public void UpdateAnimator()
        {
            base.UpdateAnimator();
            _animator.MoveHorizontal(inputVector.x);
            _animator.MoveVertical(inputVector.y*4);
            if (inputVector.magnitude > 0)
            {
                _animator.State(inputVector.magnitude > 0 ? 1 : 0);
           
            }
        }

        public void SetMovement(Vector2 input)
        {
            Vector3 moveVector = new Vector3(input.x, 0, input.y);
            characterController.Move(moveVector * (speed * Time.deltaTime));
        }
    }
}