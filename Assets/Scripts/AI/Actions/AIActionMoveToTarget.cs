using Player.Abilities;
using UnityEngine;
using UnityEngine.AI;

namespace AI.Actions
{
    public class AIActionMoveToTarget : AIAction
    {
        public PlayerMovement playerMovement;
        [SerializeField] private double maximumDistance;
        public override void Initialize(AIBrain aiBrain)
        {
            base.Initialize(Brain);
            playerMovement=Brain.GetAbility<PlayerMovement>();
        }

        public override void DoActions()
        {
            if (Brain.target == null)
            {
                return;
            }
            var directionToTarget = Brain.target.position - transform.position;
            var movementVector = Vector2.zero;
            movementVector.x = directionToTarget.x;
            movementVector.y = directionToTarget.z;
            playerMovement.SetMovement(-movementVector);


            if (Mathf.Abs(transform.position.x - Brain.target.position.x) > maximumDistance)
            {
                movementVector.x = 0f;
                playerMovement.SetMovement(-movementVector);
            }

            if (Mathf.Abs(transform.position.z - Brain.target.position.z) > maximumDistance)
            {
                movementVector.y = 0f;
                playerMovement.SetMovement(-movementVector);
            }
        }

        public override void Reset()
        {
            base.Reset();
            playerMovement.SetMovement(Vector2.zero);
        }
    }
}