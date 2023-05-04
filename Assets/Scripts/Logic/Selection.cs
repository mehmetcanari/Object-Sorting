using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace Kozar.Science
{
    public class Selection : Carrier
    {
        #region INSPECTOR FIELDS

        private RaycastHit _hit;
        [SerializeField] private float maxDistance;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private Item selectedItem;
        [SerializeField] private Transform followTransform;

        #endregion

        #region UNITY METHODS

        private void Update()
        {
            SelectItem();
        }

        #endregion
        
        #region PRIVATE METHODS

        private RaycastHit GetRaycastHit()
        {
            var ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
            Physics.Raycast(ray, out _hit, maxDistance, layerMask);

            return _hit;
        }

        private void SelectItem()
        {
            if(!IsClicked()) return;
            if (!GetRaycastHit().collider) return;
            if(selectedItem) return;
            
            selectedItem = _hit.collider.TryGetComponent(out Item item) ? item : null;
            var hovering = new Hovering(selectedItem, followTransform, 0.25f);
            hovering.HoverItem();
            SetParent(selectedItem.transform, followTransform);
        }
        
        private void SetParent(Transform obj,Transform parent)
        {
            obj.transform.SetParent(parent);
        }

        #endregion
    }
}