using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Geekbrains
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        private List<InteractiveObject> _interactiveObjects;
        private int _pickedObjects = 0;
        private GameObject _winText;
        public event Action OnReset;

        private void Awake()
        {
            _interactiveObjects = FindObjectsOfType<InteractiveObject>().ToList();
            _winText = GameObject.Find("WinText");
            
            foreach (var interactiveObject in _interactiveObjects)
            {
                
                interactiveObject.OnDestroyChange += InteractiveObjectOnOnDestroyAudio;
                interactiveObject.OnDestroyChange += InteractiveObjectOnOnDestroyChange;
                OnReset += interactiveObject.OnReset;

            }

            GameObject butt = GameObject.Find("Reset");
            butt.GetComponent<Button>().onClick.AddListener(ResetLevel);

            Player player = FindObjectOfType<Player>();
            OnReset += player.OnReset;
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
            _pickedObjects++;
            if (_pickedObjects == _interactiveObjects.Count)
            {
                _winText.SetActive(true);
            }
        }
        

        private void ResetLevel()
        {
            OnReset?.Invoke();
            _pickedObjects = 0;
            _winText.SetActive(false);
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
