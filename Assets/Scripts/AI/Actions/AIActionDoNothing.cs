using Player.Abilities;
using Player.Controllers;
using UnityEngine;

namespace AI.Actions
{
    public class AIActionDoNothing : AIAction
    {
        public PlayerMovement playerController;
        public override void Initialize(AIBrain aiBrain)
        {
            base.Initialize(aiBrain);
            playerController = Brain.GetComponent<PlayerMovement>();
        }

        public override void DoActions()
        {
            playerController.SetInput(Vector2.zero);
            playerController.SetMovement();
        }
    }
}