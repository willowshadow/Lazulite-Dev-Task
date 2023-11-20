namespace Player.Actions.Attack
{
    public abstract class IAttack : ICommand
    {
        public abstract void Execute();
    }
}