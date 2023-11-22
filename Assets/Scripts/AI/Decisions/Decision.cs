using UnityEngine;

namespace AI.Decisions
{
    public abstract class Decision : MonoBehaviour
    {
        public AIBrain Brain { get; private set; }

        public virtual void Initialize(AIBrain brain)
        {
            Brain = brain;
        }

        public virtual void Reset()
        {
            
        }

        public abstract bool DoDecide();
    }
}