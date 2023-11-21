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

        public override void Initialize()
        {
            base.Initialize();
            playerMovement=Brain.GetAbility<PlayerMovement>();
        }
    }
}