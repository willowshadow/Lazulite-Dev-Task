using UnityEngine;
using UnityEngine.Serialization;

namespace AI.Decisions
{
    public class AIDecisionDistanceToTarget : Decision
    {
        public float range;

        public override bool DoDecide()
        {
            if(Brain.target == null)
            {
                return false;
            }
            if (Vector3.Distance(Brain.target.position, transform.position) < range)
            {
                return true;
            }
            return false;
        }
    }
}