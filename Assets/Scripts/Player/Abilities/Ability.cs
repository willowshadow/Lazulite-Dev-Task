using Player.Controllers;
using UnityEngine;

namespace Player.Abilities
{
    public abstract class Ability : MonoBehaviour
    {
        protected PlayerController _playerController;
        protected AnimationController _animator;
        protected InputManager _inputManager;
        
        public virtual void ProcessAbility()
        {
            
        }
        
        public virtual void UpdateAnimator()
        {
            
        }
        public virtual void Initialize(PlayerController playerController)
        {
            _playerController = playerController;
            _inputManager = _playerController.inputManager;
            _animator = _playerController.animationController;
        }
    }
}