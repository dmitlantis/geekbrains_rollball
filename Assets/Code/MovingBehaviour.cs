using UnityEngine;

namespace Code
{
    internal class MovingBehaviour : MonoBehaviour, IMoving
    {
        public void Move()
        {
            Debug.Log("Move");
        }
    }
}
