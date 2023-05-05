using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Serialization;

namespace Kozar.Science
{
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class Selection : Carrier
    {
        #region INSPECTOR FIELDS

        private RaycastHit _hit;
        [SerializeField] private float maxDistance;
        [SerializeField] private LayerMask layerMask;
        [FormerlySerializedAs("selectedItem")] [SerializeField] private Slot selectedSlot;
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
            if(selectedSlot) return;
            
            selectedSlot = _hit.collider.TryGetComponent(out Slot slot) ? slot : null;
            var selectedItem = selectedSlot?.item;
            selectedSlot.RemoveItem(selectedItem);
            
            var hovering = new Hovering(selectedItem, followTransform, 0.25f);
            hovering.HoverItem();
            hovering.SetParent(selectedItem.transform, followTransform);
        }

        #endregion
    }
}