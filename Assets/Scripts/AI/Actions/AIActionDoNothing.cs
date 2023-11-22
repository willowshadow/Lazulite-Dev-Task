using UnityEngine;

namespace AI.Actions
{
    public class AIActionDoNothing : AIAction
    {
        public override void Initialize(AIBrain aiBrain)
        {
            base.Initialize(aiBrain);
        }

        public override void DoActions()
        {
            return;       
        }
    }
}