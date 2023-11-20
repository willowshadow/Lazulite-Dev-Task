using UnityEngine;

namespace AI.Decisions
{
    public abstract class Decision : MonoBehaviour
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

        public abstract bool DoDecide();
    }
}