using UnityEngine;

namespace AI.Decisions
{
    public abstract class Decision : MonoBehaviour
    {
        public AIBrain Brain { get; private set; }

        /// <summary>
        /// Initializes the decision
        /// </summary>
        /// <param name="brain"></param>
        public virtual void Initialize(AIBrain brain)
        {
            Brain = brain;
        }

        /// <summary>
        /// Resets the decision
        /// </summary>
        public virtual void Reset()
        {
            
        }

        /// <summary>
        /// Core logic of the decision
        /// </summary>
        /// <returns></returns>
        public abstract bool DoDecide();
    }
}