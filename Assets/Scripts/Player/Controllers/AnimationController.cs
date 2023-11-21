using System;
using UnityEngine;

namespace Player.Controllers
{
    public class AnimationController : MonoBehaviour
    {
        public Animator animator;

        public int jump = Animator.StringToHash("jump");
        public int moveSpeed = Animator.StringToHash("speed");
        public int rotVal = Animator.StringToHash("rotVal");
        public int fire = Animator.StringToHash("fire");
        public int tail = Animator.StringToHash("tail");
        public int death = Animator.StringToHash("death");
        public int attackL = Animator.StringToHash("attackL");
        public int attackR = Animator.StringToHash("attackR");

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void Jump()
        {
            animator.SetTrigger(jump);
        }
        public void Move(float speed)
        {
            animator.SetFloat(moveSpeed,speed);
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
            animator.SetTrigger(death);
        }
        public void AttackL()
        {
            animator.SetTrigger(attackL);
        }
        public void AttackR()
        {
            animator.SetTrigger(attackR);
        }
    }
}