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
            if (selectedItem is null) return;
            
            _item = selectedItem;
            slot.gameObject.layer = 8;
            slot.RemoveItem(selectedItem);
            
            var hovering = new Grab(selectedItem, followTransform, 0.1f);
            hovering.SetParent(selectedItem.transform, followTransform);
            hovering.DisableCollider(selectedItem);
            hovering.HoverItem();
        }
        
        private void ReleaseItem(Item item)
        {
            if(selectedSlot == null) return;
            if (!IsReleased()) return;
            if (!item) return;
            
            var release = new Release(selectedSlot, 0.1f, releaseSound);
            if (release.CheckLayerWithRaycast() == 8)
            {
                release.ReleaseItem(item,release.GettedSlot());
                ReleaseActions(release, item);
            }
            else
            {
                release.ReleaseItem(item, selectedSlot);
                ReleaseActions(release, item);
            }
        }

        private void ReleaseActions(Release release, Item item)
        {
            releaseSound.Play();
            release.EnableCollider(item);
            _item = null;
            selectedSlot = null;

        }

        #endregion
    }
}