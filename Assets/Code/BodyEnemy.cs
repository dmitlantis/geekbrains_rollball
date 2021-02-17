using UnityEngine;

namespace Code
{
    internal sealed class BodyEnemy : MonoBehaviour, IApplyDamage, IMoving
    {
        private IMoving _moving = new MovingRigidbody();
        
        public void ApplyDamage()
        {
            Debug.Log($"{nameof(ApplyDamage)} - {typeof(BodyEnemy)}");
        }

        public void Move()
        {
            _moving.Move();
        }
    }
}
