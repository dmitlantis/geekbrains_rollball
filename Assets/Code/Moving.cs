using UnityEngine;

namespace Code
{
    internal sealed class Moving : IMoving
    {
        public void Move()
        {
            Debug.Log("Move");
        }
    }
}
