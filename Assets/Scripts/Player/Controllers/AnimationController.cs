using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player.Controllers
{
    public class AnimationController : MonoBehaviour
    {
        public Animator animator;

        public int jump = Animator.StringToHash("jump");
        public int moveSpeedH = Animator.StringToHash("Horizontal");
        public int moveSpeedV = Animator.StringToHash("Vertical");
        public int rotVal = Animator.StringToHash("rotVal");
        public int fire = Animator.StringToHash("fire");
        public int tail = Animator.StringToHash("tail");
        public int death = Animator.StringToHash("death");
        public int attackL = Animator.StringToHash("attackL");
        public int attackR = Animator.StringToHash("attackR");
        public int stateOn = Animator.StringToHash("StateOn");
        public int state = Animator.StringToHash("State");
        public int modeOn = Animator.StringToHash("ModeOn");
        public int mode = Animator.StringToHash("Mode");

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void Jump()
        { 
            StateOn();
            State(2);
        }
        public void MoveHorizontal(float speed)
        {
            animator.SetFloat(moveSpeedH,speed);
        }
        public void MoveVertical(float speed)
        {
            animator.SetFloat(moveSpeedV,speed);
        }
        public void Rotate(float rotVal)
        {
            animator.SetFloat(this.rotVal,rotVal);
        }
        public void Fire()
        {
            animator.SetTrigger(fire);
        }
        public void Tail()
        {
            animator.SetTrigger(tail);
        }
        public void Death()
        {
            StateOn();
            State(10);
        }
        public void AttackL()
        {
            animator.SetTrigger(attackL);
        }
        public void AttackR()
        {
            animator.SetTrigger(attackR);
        }

        public void StateOn()
        {
            animator.SetTrigger(stateOn);
        }
        public void State(int state)
        {
            animator.SetInteger(this.state,state);
        }
        public void ModeOn()
        {
            animator.SetTrigger(modeOn);
        }
        public void Mode(int mode)
        {
            animator.SetInteger(this.mode,mode);
        }
    }
}