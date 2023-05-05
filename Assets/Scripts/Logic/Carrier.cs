using System;
using UnityEngine;
using DG.Tweening;

namespace Kozar.Science
{
    public class Carrier : Input { }
    
    internal class Grab
    {
        protected readonly Item HoveredItem;
        protected readonly Transform followTransform;
        protected readonly float hoverSpeed;

        internal Grab(Item hoveredItem, Transform followTransform, float hoverSpeed)
        {
            HoveredItem = hoveredItem;
            this.followTransform = followTransform;
            this.hoverSpeed = hoverSpeed;
        }

        internal void HoverItem()
        {
            HoveredItem.transform.DOMove(followTransform.position, hoverSpeed)
                .SetLink(HoveredItem.gameObject)
                .SetEase(Ease.InOutBack);
        }
        
        internal void SetParent(Transform obj,Transform parent)
        {
            obj.transform.SetParent(parent);
        }
        
        internal void DisableCollider(Item item)
        {
            item.GetComponent<Collider>().enabled = false;
        }
    }
    
    internal class Release
    {
        private readonly Slot _slot;
        private Vector3 _targetPosition;
        private float _easeTime;
        private Input _input;
        private AudioSource _audioSource;
        
        internal Release(Slot slot, Vector3 targetPosition, float easeTime, AudioSource audioSource)
        {
            _slot = slot;
            _targetPosition = targetPosition;
            _easeTime = easeTime;
            _audioSource = audioSource;
        }

        internal void ReleaseItem(Item item,Slot slot)
        {
            if (!item) return;
            _audioSource.Play();
            
            CheckLayerMaskWithReleaseCast();

            item.transform.parent = null;
            item.gameObject.transform.DORotate(item.Rotation.eulerAngles, _easeTime)
                .SetLink(item.gameObject)
                .SetEase(Ease.InOutBack);
            
            item.gameObject.transform.DOMove(_targetPosition, _easeTime)
                .SetLink(item.gameObject)
                .SetEase(Ease.InOutBack)
                .OnComplete(() =>
                {
                    slot.SetItem(item);
                    item.transform.parent = slot.transform;
                    item = null;
                    slot = null;
                });
        }
        
        internal void EnableCollider(Item item)
        {
            item.GetComponent<Collider>().enabled = true;
        }
        
        internal RaycastHit ReleaseCast()
        {
            var ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
            Physics.Raycast(ray, out var hit, 10);
            return hit;
        }
        
        internal void CheckLayerMaskWithReleaseCast()
        {
            if (ReleaseCast().collider is null) return;
            Debug.Log(ReleaseCast().collider.gameObject.layer);
        }
    }
}