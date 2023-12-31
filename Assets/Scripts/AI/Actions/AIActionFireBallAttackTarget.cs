using Player.Controllers;
using UnityEngine;

namespace AI.Actions
{
    public class AIActionFireBallAttackTarget : AIAction
    {
        public AttackManager attackManager;
        public override void Initialize(AIBrain aiBrain)
        {
            base.Initialize(aiBrain);
            attackManager = Brain.GetComponent<AttackManager>();
        }

        public override void DoActions()
        {
            if (Brain.target == null)
            {
                return;
            }
            attackManager.FireBallAttack();
        }
    }
}