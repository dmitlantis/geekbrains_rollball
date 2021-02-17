using System;
using UnityEngine;

namespace Code
{
    internal sealed class Weapon : MonoBehaviour
    {
        private Camera _camera;

        private void Start()
        {
            _camera = GetComponent<Camera>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hint))
                {
                    if (hint.collider.TryGetComponent(out IEnemy enemy))
                    {
                        if (enemy is IApplyDamage applyDamage)
                        {
                            applyDamage.ApplyDamage();
                        }

                        if (enemy is ILogger logger)
                        {
                            logger.Log();
                        }
                    }
                }
            }
        }
    }
}
