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
                primary = true;
            }
            else
            {
                primary = false;
            }
        }
        public void SecondaryAttack(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                secondary = true;
            }
            else
            {
                secondary = false;
            }
        }
        public void Ability1(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                ability1 = true;
            }
            else
            {
                ability1 = false;
            }
        }
        public void Ability2(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                ability2 = true;
            }
            else
            {
                ability2 = false;
            }
        }
        public void Ability3(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                ability3 = true;
            }
            else
            {
                ability3 = false;
            }
        }

        public void Jump(InputAction.CallbackContext context)
        {
            if(context.performed){
                jump = true;
            }
            else if(context.canceled)
            {
                jump = false;
            }
        }
    }
}