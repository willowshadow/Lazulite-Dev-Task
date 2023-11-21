using UnityEngine;

namespace AI.Actions
{
    public class AIActionRandomAttackTarget : AIAction
    {
        public override void Initialize()
        {
            base.Initialize();
        }

        public override void DoActions()
        {
            if (Brain.target == null)
            {
                return;
            }
            
            
        }

        public override void Reset()
        {
            base.Reset();
        }
    }
}