using System;
using Player.Abilities;
using UnityEngine;

namespace Player.Controllers
{
    [RequireComponent(
        typeof(Rigidbody),
        typeof(AnimationController),
        typeof(CharacterController))
    ]
    public class PlayerController : MonoBehaviour
    {
        public CharacterController characterController;
        public Ability[] abilities;
        public InputManager inputManager;
        public Rigidbody rigidBody;
        public AnimationController animationController;


        private void Awake()
        {
            InitializeComponents();
            InitializeAbilities();
        }

        private void InitializeComponents()
        {
            characterController = GetComponent<CharacterController>();
            rigidBody = GetComponent<Rigidbody>();
            animationController = GetComponent<AnimationController>();
        }

        private void InitializeAbilities()
        {
            abilities = GetComponents<Ability>();
            foreach (var ability in abilities)
            {
                ability.Initialize(this,inputManager);
            }
        }

        private void ProcessAbilities()
        {
            foreach (var ability in abilities)
            {
                ability.ProcessAbility();
            }
        }

        #region Unity Events
        private void Update()
        {
            ProcessAbilities();
        }
        #endregion
    }
}