using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Player.Controllers
{
    public class InputManager : MonoBehaviour
    {
        public Vector2 inputVector;
        public Vector2 mousePosition;
        public bool primary;
        public bool secondary;
        public bool ability1;
        public bool ability2;
        public bool ability3;
        public bool jump;
        private Camera _camera;

        public Transform lookPoint;


        public event Action OnJump;
        public event Action OnPrimaryAttack;
        public event Action OnSecondaryAttack;
        public event Action OnAbility1;
        public event Action OnAbility2;
        public event Action OnAbility3;
        
        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            LookPosition();
        }

        private void LookPosition()
        {
            var ray = _camera.ScreenPointToRay(mousePosition);
            
            if (Physics.Raycast(ray, out var hitInfo))
            {
                lookPoint.position = hitInfo.point;
            }
            else
            {
                lookPoint.position = ray.origin + ray.direction * 100;
            }
        }
        public void OnMove(InputAction.CallbackContext context)
        {
            inputVector = context.ReadValue<Vector2>();
        }

        public void MousePosition(InputAction.CallbackContext context)
        {
            mousePosition = context.ReadValue<Vector2>();
        }

        public void PrimaryAttack(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                OnPrimaryAttack?.Invoke();
            
            }
        }
        public void SecondaryAttack(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                OnSecondaryAttack?.Invoke();
            }
        }
        public void Ability1(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                OnAbility1?.Invoke();
            }
        }
        public void Ability2(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                OnAbility2?.Invoke();
            }
        }
        public void Ability3(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                OnAbility3?.Invoke();
            }
        }

        public void Jump(InputAction.CallbackContext context)
        {
            if(context.performed){
                OnJump?.Invoke();
            }
        }
    }
}