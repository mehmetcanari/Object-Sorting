using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Kozar.Science
{
    public sealed class DoorSelection : Input
    {
        #region INSPECTOR FIELDS

        [SerializeField] private int maxDistance;
        [SerializeField] private LayerMask layerMask;

        #endregion
        
        #region PRIVATE FIELDS
        
        private UIManager _uiManager;

        #endregion

        #region UNITY METHODS

        private void Awake()
        {
            _uiManager = FindObjectOfType<UIManager>();
        }

        private void Update()
        {
            Selection();
        }

        #endregion
        
        #region PRIVATE METHODS

        private RaycastHit GetRaycastHit()
        {
            var ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
            Physics.Raycast(ray, out var hit, maxDistance, layerMask);
            return hit;
        }
        
        private void Selection()
        {
            if (!IsClicked()) return;
            if (!GetRaycastHit().collider) return;
            if(!GetRaycastHit().collider.TryGetComponent(out Door door)) return;
            
            _uiManager.OnEndGame?.Invoke();
        }

        #endregion       
    }
}