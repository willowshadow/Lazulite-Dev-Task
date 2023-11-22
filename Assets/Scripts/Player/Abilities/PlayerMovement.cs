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
            if(_playerController.isAI) return;
            HandledInput();
            SetMovement();
        }

        public void SetInput(Vector2 input)
        {
            inputVector = Vector2.MoveTowards(inputVector, input, Time.deltaTime);;
        }
        private void HandledInput()
        {
            var newValue = _inputManager.inputVector;
            SetInput(newValue);
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

        public void SetMovement()
        {
            Vector3 moveVector = new Vector3(inputVector.x, 0, inputVector.y);
            characterController.Move(moveVector * (speed * Time.deltaTime));
        }
    }
}