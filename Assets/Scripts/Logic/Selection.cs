using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.WindowsRuntime;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace Kozar.Science
{
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public sealed class Selection : Carrier
    {
        #region INSPECTOR FIELDS

        private RaycastHit _hit;
        [SerializeField] private float maxDistance;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private Slot selectedSlot;
        [SerializeField] private Transform followTransform;
        [SerializeField] private AudioSource releaseSound;
        private Item _item;

        #endregion

        #region UNITY METHODS

        private void Update()
        {
            SelectItem();
            ReleaseItem(_item);
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
            if (!IsClicked()) return;
            if (!GetRaycastHit().collider) return;
            if (selectedSlot) return;
            
            selectedSlot = _hit.collider.TryGetComponent(out Slot slot) ? slot : null;
            var selectedItem = selectedSlot?.item;
            _item = selectedItem;

            var hovering = new Grab(selectedItem, followTransform, 0.1f);
            hovering.HoverItem();
            hovering.SetParent(selectedItem.transform, followTransform);
            hovering.DisableCollider(selectedItem);
        }
        
        private void ReleaseItem(Item item)
        {
            if (!IsReleased()) return;
            if (!item) return;
            
            var release = new Release(selectedSlot, item.Slot.transform.position, 0.1f, releaseSound);
            release.ReleaseItem(item,selectedSlot);
            release.EnableCollider(item);
            selectedSlot = null;
        }

        #endregion
    }
}