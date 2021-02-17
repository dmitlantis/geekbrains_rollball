using UnityEngine;

namespace Code
{
    internal sealed class HeadEnemy : MonoBehaviour, IApplyDamage, ILogger
    {
        public float Armor;
        
        public void ApplyDamage()
        {
            Debug.Log($"{nameof(ApplyDamage)} - {typeof(HeadEnemy)}");
        }

        public void Log()
        {
            Debug.Log($"{nameof(Log)} - {typeof(HeadEnemy)}");
        }
    }
}
