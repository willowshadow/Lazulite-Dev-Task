using UnityEngine;

namespace Player.Actions.Attack
{
    public class TailAttack : Attack
    {
        public override void ExecuteAttack()
        {
            var random = Random.Range(0, modeRange.Count);
            var mode = modeRange[random];
            animationController.AttackWithParameter(mode);
        }
    }
}