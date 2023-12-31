using Player.Abilities;
using UnityEngine;
using UnityEngine.Serialization;

namespace AI.Actions
{
    public class AIActionMoveAwayFromTarget : AIAction
    {
        public PlayerMovement playerMovement;
        [SerializeField] private float speed;
        [SerializeField] private double maximumDistance;

        public override void DoActions()
        {
            if (Brain.target == null)
            {
                return;
            }
            
            var directionToTarget = transform.position - Brain.target.position;
            var movementVector = Vector2.zero;
            movementVector.x = directionToTarget.x;
            movementVector.y = directionToTarget.z;
            playerMovement.SetInput(-movementVector);
            playerMovement.SetMovement();


            if (Mathf.Abs(transform.position.x - Brain.target.position.x) > maximumDistance)
            {
                movementVector.x = 0f;
                playerMovement.SetInput(-movementVector);
                playerMovement.SetMovement();
            }

            if (Mathf.Abs(transform.position.z - Brain.target.position.z) > maximumDistance)
            {
                movementVector.y = 0f;
                playerMovement.SetInput(-movementVector);
                playerMovement.SetMovement();
            }
        }

        public override void Initialize(AIBrain aiBrain)
        {
            base.Initialize(aiBrain);
            playerMovement=Brain.GetAbility<PlayerMovement>();
        }

        public override void Reset()
        {
            base.Reset();
            playerMovement.SetInput(Vector2.zero);
            playerMovement.SetMovement();
        }
    }
}