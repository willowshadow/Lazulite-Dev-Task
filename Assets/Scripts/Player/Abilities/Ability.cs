using Player.Controllers;
using UnityEngine;

namespace Player.Abilities
{
    /// <summary>
    /// Base class for Abilities, can be used to create custom abilities
    /// </summary>
    public abstract class Ability : MonoBehaviour
    {
        protected PlayerController _playerController;
        protected AnimationController _animator;
        protected InputManager _inputManager;
        
        /// <summary>
        /// Process the ability
        /// </summary>
        public virtual void ProcessAbility()
        {
            
        }
        
        public virtual void UpdateAnimator()
        {
            
        }
        public virtual void Initialize(PlayerController playerController)
        {
            _playerController = playerController;
            _animator = _playerController.animationController;
            if(_playerController.isAI) return;
            _inputManager = _playerController.inputManager;
        }
    }
}