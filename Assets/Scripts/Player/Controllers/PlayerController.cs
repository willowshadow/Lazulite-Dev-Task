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
        public bool grounded;
        public bool isAI;


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
                ability.Initialize(this);
            }
        }

        private void ProcessAbilities()
        {
            if(isAI) return;
            foreach (var ability in abilities)
            {
                ability.ProcessAbility();
            }
        }
        
        private void UpdateAnimator()
        {
            foreach (var ability in abilities)
            {
                ability.UpdateAnimator();
            }
        }
        
        private void GroundCheck()
        {
            grounded = Physics.Raycast(transform.position, Vector3.down, .1f);
        }

        #region Unity Events
        private void Update()
        {
            ProcessAbilities();
            UpdateAnimator();
        }

        private void FixedUpdate()
        {
            GroundCheck();
        }

        #endregion
    }
}