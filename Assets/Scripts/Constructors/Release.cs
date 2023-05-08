using DG.Tweening;
using UnityEngine;

namespace Kozar.Science
{
    internal class Release
    {
        private Vector3 _targetPosition;
        private float _easeTime;
        private ClickInputHandler _clickInputHandler;

        internal Release(float easeTime)
        {
            _easeTime = easeTime;
        }

        internal void ReleaseItem(Item item,Slot slot)
        {
            if (!item) return;
            item.transform.parent = null;
            item.gameObject.transform.DORotate(item.Rotation.eulerAngles, _easeTime)
                .SetLink(item.gameObject)
                .SetEase(Ease.InOutBack);
            
            item.gameObject.transform.DOMove(slot.transform.position, _easeTime)
                .SetLink(item.gameObject)
                .SetEase(Ease.InOutBack)
                .OnComplete(() =>
                {
                    slot.SetItem(item);
                    slot.gameObject.layer = 6;
                });
        }
        
        internal void EnableCollider(Item item)
        {
            item.GetComponent<Collider>().enabled = true;
        }
        
        internal RaycastHit GetRaycastHit()
        {
            var ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
            Physics.Raycast(ray, out var hit, 100f);
            return hit;
        }
        
        internal LayerMask CheckLayerWithRaycast()
        {
            var hit = GetRaycastHit();
            if (!hit.collider) return 0;
            return hit.collider.gameObject.layer;
        }
        
        internal virtual Slot GettedSlot()
        {
            var hit = GetRaycastHit();
            if (!hit.collider) return null;
            return hit.collider.gameObject.GetComponent<Slot>();
        }
    }
}