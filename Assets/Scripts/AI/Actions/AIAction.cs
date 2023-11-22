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
        /// <summary>
        /// Gets or sets the components
        /// </summary>
        /// <param name="aiBrain"></param>
        public virtual void Initialize(AIBrain aiBrain)
        {
            _brain = aiBrain;
        }

        /// <summary>
        /// Resets the actions
        /// </summary>
        public virtual void Reset()
        {
            
        }

        /// <summary>
        /// Performs the actions
        /// </summary>
        public abstract void DoActions();
    }
}