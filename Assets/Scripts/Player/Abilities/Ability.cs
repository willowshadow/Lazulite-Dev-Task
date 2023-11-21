using Player.Controllers;
using UnityEngine;

namespace Player.Abilities
{
    public abstract class Ability : MonoBehaviour
    {
        protected PlayerController _playerController;
        protected InputManager _inputManager;
        
        public virtual void ProcessAbility()
        {
            
        }

        public virtual void Initialize(PlayerController playerController,InputManager inputManager)
        {
            _playerController = playerController;
            _inputManager = inputManager;
        }
    }
}