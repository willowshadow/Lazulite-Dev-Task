namespace Player.Actions.Attack
{
    public abstract class Attack : ICommand
    {
        public abstract void Execute();
    }
}