using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.WindowsRuntime;
using DG.Tweening;
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
        [SerializeField] private Slot selectedSlot;
        [SerializeField] private Transform followTransform;
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

            var hovering = new Hovering(selectedItem, followTransform, 0.1f);
            hovering.HoverItem();
            hovering.SetParent(selectedItem.transform, followTransform);
        }
        
        private void ReleaseItem(Item item)
        {
            if (!IsReleased()) return;
            if (!item) return;
            
            var savedSlot = item.Slot;
            
            item.transform.parent = null;
            item.gameObject.transform.DORotate(item.Rotation.eulerAngles, 0.1f)
                .SetLink(item.gameObject)
                .SetEase(Ease.InOutBack);
            
            item.gameObject.transform.DOMove(savedSlot.transform.position, 0.1f)
                .SetLink(item.gameObject)
                .SetEase(Ease.InOutBack)
                .OnComplete(() =>
                {
                    selectedSlot.SetItem(item);
                    item.transform.parent = selectedSlot.transform;
                    _item = null;
                    selectedSlot = null;
                });
        }

        #endregion
    }
}