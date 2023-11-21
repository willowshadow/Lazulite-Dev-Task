using UnityEngine;
using UnityEngine.AI;

namespace AI.Actions
{
    public class AIActionMoveToTarget : AIAction
    {
        public NavMeshAgent agent;
        public float minDistance;
        public override void Initialize()
        {
            base.Initialize();
            agent = Brain.GetComponent<NavMeshAgent>();
            agent.stoppingDistance = minDistance;
        }

        public override void DoActions()
        {
            if (Brain.target == null)
            {
                return;
            }
            if(agent.hasPath) return;
            agent.SetDestination(Brain.target.position);
        }

        public override void Reset()
        {
            base.Reset();
            agent.ResetPath();
        }
    }
}