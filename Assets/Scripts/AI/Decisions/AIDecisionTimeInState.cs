namespace AI.Decisions
{
    public class AIDecisionTimeInState : Decision
    {
        public int timeInState;

        public override bool DoDecide()
        {
            if (Brain.timeInState > timeInState)
            {
                return true;
            }
            return false;
        }
    }
}