using Player.Controllers;
using UnityEngine;

namespace AI.Actions
{
    public class AIActionSwipeAttackTarget : AIAction
    {
        public AttackManager attackManager;

        public override void Initialize(AIBrain aiBrain)
        {
            base.Initialize(Brain);
            attackManager = Brain.GetComponent<AttackManager>();
        }

        public override void DoActions()
        {
            if (Brain.target == null)
            {
                return;
            }
            attackManager.SwipeAttack();
            
        }

        public override void Reset()
        {
            base.Reset();
        }
    }
}