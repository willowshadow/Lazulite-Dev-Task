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
        private Vector2 _lastDirection;

        public override void Initialize(AIBrain aiBrain)
        {
            base.Initialize(aiBrain);
            playerMovement = Brain.GetComponent<PlayerMovement>();
        }
        public override void DoActions()
        {
            if(isMoving)
            {
                timeSinceMovement += Time.deltaTime;
                playerMovement.SetInput(_lastDirection);
                playerMovement.SetMovement();
                if (timeSinceMovement > maximumTime)
                {
                    isMoving = false;
                }
                
                return;
            }

            timeSinceMovement = 0;
            var randomVertical = Random.Range(0, 1f);
            var randomHorizontal = Random.Range(0, 1f);
            _lastDirection = new Vector2(randomHorizontal, randomVertical);
            isMoving = true;
        }

        public override void Reset()
        {
            base.Reset();
            playerMovement.SetInput(Vector2.zero);
            playerMovement.SetMovement();
        }
    }
}