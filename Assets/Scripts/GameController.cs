﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Geekbrains
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        private List<InteractiveObject> _interactiveObjects;

        private void Awake()
        {
            _interactiveObjects = FindObjectsOfType<InteractiveObject>().ToList();
            
            foreach (var interactiveObject in _interactiveObjects)
            {
                
                interactiveObject.OnDestroyChange += InteractiveObjectOnOnDestroyAudio;
                interactiveObject.OnDestroyChange += InteractiveObjectOnOnDestroyChange;
            }
        }

        private void InteractiveObjectOnOnDestroyAudio(InteractiveObject value)
        {
            try
            {
                Camera.main.GetComponent<AudioSource>().Play();
            }
            catch (NullReferenceException e)
            {
                Debug.Log("Camera not found!");
            }
        }
        

        private void InteractiveObjectOnOnDestroyChange(InteractiveObject value)
        {
            value.OnDestroyChange -= InteractiveObjectOnOnDestroyChange;
            _interactiveObjects.Remove(value);
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObjects.Count; i++)
            {
                var interactiveObject = _interactiveObjects[i];

                if (interactiveObject == null)
                {
                    continue;
                }

                if (interactiveObject is IFlay flay)
                {
                    flay.Flay();
                }
                if (interactiveObject is IFlicker flicker)
                {
                    flicker.Flicker();
                }
                if (interactiveObject is IRotation rotation)
                {
                    rotation.Rotation();
                }
            }
        }

        public void Dispose()
        {
            foreach (var o in _interactiveObjects)
            {
                Destroy(o.gameObject);
            }
        }
    }
}
