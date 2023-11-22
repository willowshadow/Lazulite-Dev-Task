using System;
using DG.Tweening;
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
        
        public void Death()
        {
            StateOn();
            State(10);
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

        public void AttackWithParameter(int i)
        {
            ModeOn();
            Mode(i);
            DOVirtual.DelayedCall(1f, () =>
            {
                Mode(0);
            });
        }
    }
}