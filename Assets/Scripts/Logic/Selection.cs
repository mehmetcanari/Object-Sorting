using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.WindowsRuntime;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace Kozar.Science
{
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public sealed class Selection : Carrier
    {
        #region INSPECTOR FIELDS

        private RaycastHit _hit;
        private Slot _selectedSlot;
        
        [SerializeField] private float maxDistance;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private Transform followTransform;
        [SerializeField] private AudioSource releaseSound;
        [SerializeField] private StateManager stateManager;
        private Item _item;
        
        private int _placeableLayer = 8;
        private int _pickableLayer = 6;

        #endregion

        #region UNITY METHODS

        private void Update()
        {
            switch (stateManager.gameState)
            {
                case GameState.Play:
                    SelectItem();
                    ReleaseItem(_item);
                    break;
            }
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
            if (_selectedSlot) return;
            
            _selectedSlot = _hit.collider.TryGetComponent(out Slot slot) ? slot : null;
            _item = _selectedSlot?.item;
            if (_item is null) return;

            if (_selectedSlot.transform.parent.TryGetComponent(out ObjectsVault vault))
                vault.RemoveItem(_item);

            slot.gameObject.layer = _placeableLayer;
            slot.RemoveItem(_item);
            
            var grab = new Grab(_item, followTransform, 0.1f);
            
            grab.SetParent(_item.transform, followTransform);
            grab.DisableCollider(_item);
            grab.GrabItem();
        }
        
        private void ReleaseItem(Item item)
        {
            if(_selectedSlot is null) return;
            if (!IsReleased()) return;
            if (!item) return;
            
            var release = new Release(0.1f, releaseSound);
            
            if (release.CheckLayerWithRaycast() == _placeableLayer)
                HasItemPlacingAction(release, item);
            
            else if (release.CheckLayerWithRaycast() == _pickableLayer && item.type == release.GettedSlot().item.type)
                HasSwitchingItemAction(release, item);
            
            else
                ReleaseInitiliaze(release, item, _selectedSlot, false, null);
        }
        
        #endregion

        #region RELEASE LOGIC METHODS

        private void HasItemPlacingAction(Release release, Item item)
        {
            if (release.GetRaycastHit().transform.parent.TryGetComponent(out ObjectsVault vault))
            {
                if (vault.CheckAnySameType(item))
                    ReleaseInitiliaze(release, item, _selectedSlot, false, null);
                else
                    ReleaseInitiliaze(release, item, release.GettedSlot(), true, vault);
            }
            else
                ReleaseInitiliaze(release, item, release.GettedSlot(), false, null);
        }

        private void HasSwitchingItemAction(Release release, Item item)
        {
            if (release.GetRaycastHit().transform.parent.TryGetComponent(out ObjectsVault vault))
            {
                vault.RemoveItem(release.GettedSlot().item);
                
                Swap swap = new Swap(item, release.GettedSlot(), 0.1f, release);
                swap.SwapItems(release.GettedSlot().item, item.PreviousSlot);
                
                ReleaseInitiliaze(release, item, release.GettedSlot(), true, vault);
            }
            else
                ReleaseInitiliaze(release, item, _selectedSlot, false, null);
        }

        #endregion

        #region HELPER METHODS

        private void ReleaseInitiliaze(Release release, Item item, Slot slot, bool isVault, [CanBeNull] ObjectsVault vault)
        {
            release.ReleaseItem(item, slot);
            ReleaseActions(release, item);

            if (isVault)
            {
                vault.AddItem(item);
            }
        }
        
        private void ReleaseActions(Release release, Item item)
        {
            releaseSound.Play();
            release.EnableCollider(item);
            _item = null;
            _selectedSlot = null;
        }

        #endregion
    }
}