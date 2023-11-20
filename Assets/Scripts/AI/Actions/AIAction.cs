using System;
using UnityEngine;

namespace AI.Actions
{
    public abstract class AIAction : MonoBehaviour
    {
        private AIBrain _brain;

        public AIBrain Brain
        {
            get => _brain;
            set => _brain = value;
        }
        
        public virtual void Initialize()
        {
            
        }

        public virtual void Reset()
        {
            
        }

        public abstract void DoActions();
    }
}