using UnityEngine;

namespace AI.Decisions
{
    public abstract class Decision : MonoBehaviour
    {
        public AIBrain Brain { get; set; }

        public virtual void Initialize()
        {
            
        }

        public virtual void Reset()
        {
            
        }

        public abstract bool DoDecide();
    }
}