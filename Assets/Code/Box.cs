using UnityEngine;

namespace Code
{
    internal sealed class Box : MovingBehaviour, ILogger
    {
        public void Log()
        {
            Debug.Log($"{nameof(Log)} - {typeof(Box)}");
        }

        public void Move()
        {
            Debug.Log("Move");
        }
    }
}
