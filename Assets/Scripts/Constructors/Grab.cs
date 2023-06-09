﻿using DG.Tweening;
using UnityEngine;

namespace Kozar.Science
{
    internal class Grab
    {
        private readonly Item HoveredItem;
        private readonly Transform followTransform;
        private readonly float hoverSpeed;

        internal Grab(Item hoveredItem, Transform followTransform, float hoverSpeed)
        {
            HoveredItem = hoveredItem;
            this.followTransform = followTransform;
            this.hoverSpeed = hoverSpeed;
        }

        internal void GrabItem()
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
}