using Player.Abilities;
using UnityEngine;

namespace AI.Actions
{
    public class AIActionMoveRandom : AIAction
    {
        public PlayerMovement playerMovement;
        public float maximumTime;
        public float timeSinceMovement;
        public bool isMoving;
        public override void Initialize(AIBrain aiBrain)
        {
            base.Initialize(aiBrain);
            playerMovement = Brain.GetComponent<PlayerMovement>();
        }
        public override void DoActions()
        {
            if(isMoving && timeSinceMovement < maximumTime)
            {
                timeSinceMovement += Time.deltaTime;
                return;
            }

            isMoving = false;
            timeSinceMovement = 0;
            var randomVertical = Random.Range(0, 1f);
            var randomHorizontal = Random.Range(0, 1f);
            playerMovement.SetMovement(new Vector2(randomHorizontal, randomVertical));
        }

        public override void Reset()
        {
            base.Reset();
            playerMovement.SetMovement(Vector2.zero);
        }
    }
}