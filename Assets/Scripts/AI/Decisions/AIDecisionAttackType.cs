namespace AI.Decisions
{
    public class AIDecisionAttackType: Decision
    {
        public override bool DoDecide()
        {
            return true;
        }
    }

    public enum AttackType
    {
        Swipe,
        Fire,
        FireBall
        
    }
}