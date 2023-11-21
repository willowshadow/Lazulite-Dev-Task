using UnityEngine;

namespace AI.Decisions
{
    public class AIDecisionRandom : Decision
    {
        public float max;
        public float trueChance;
        public override bool DoDecide()
        {
            var random = Random.Range(0, max);
            
            return random < trueChance;
        }
    }
}