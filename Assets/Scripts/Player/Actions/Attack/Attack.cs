using System;
using System.Collections.Generic;
using Player.Controllers;
using UnityEngine;

namespace Player.Actions.Attack
{
    public abstract class Attack : MonoBehaviour
    {
        public AnimationController animationController;

        private void Awake()
        {
            animationController = GetComponent<AnimationController>();
        }

        public List<int> modeRange;
        public abstract void ExecuteAttack();
    }
}