using Player.Abilities;
using UnityEngine;

namespace AI.Actions
{
    public class AIActionLookAtTarget : AIAction
    {
        public PlayerMovement playerMovement;
        public override void Initialize(AIBrain aiBrain)
        {
            base.Initialize(aiBrain);
            playerMovement = Brain.GetComponent<PlayerMovement>();
        }
        public override void DoActions()
        {
            if(Brain.target == null)
            {
                return;
            }
            var directionToTarget = Brain.target.position - Brain.transform.position;

            // Remove Y axis value from direction to target.
            directionToTarget.y = 0;

            // Create a new rotation based on the direction to the target.
            Quaternion desiredRotation = Quaternion.LookRotation(directionToTarget);

            // Rotate the player gradually to that rotation.
            Brain.transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, 100 * Time.deltaTime);
        }
    }
}