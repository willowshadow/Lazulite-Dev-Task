using Common;
using UnityEngine;

namespace Player.Actions.Attack
{
    public class FireBallAttack : Attack
    {
        public Projectile damageParticle;
        public Transform mouth;
        public override void ExecuteAttack()
        {
            var random = Random.Range(0, modeRange.Count);
            var mode = modeRange[random];
            animationController.AttackWithParameter(mode);
            
            var projectile = Instantiate(damageParticle, mouth.position, Quaternion.identity);
            var t = transform;
            projectile.Shoot(t.forward,t.root);
        }
    }
}