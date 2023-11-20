using Player.Actions;

namespace AI.Actions
{
    public class AIWalk : AIAction
    {
        private Walk _playerWalk;

        public float walkSpeed;

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Reset()
        {
            base.Reset();
        }

        public override void DoActions()
        {
            throw new System.NotImplementedException();
        }
    }
}